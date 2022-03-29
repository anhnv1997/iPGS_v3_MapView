using Futech.Tools;
using iParking.Enums;
using iParking.UserControls;
using MapView.Databases;
using MapView.Forms;
using MapView.Object;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using TableDependency.SqlClient;
using TableDependency.SqlClient.Base.Enums;

namespace MapView
{
    public partial class Form1 : Form
    {
        private SqlTableDependency<tblZone> depZone;
        private SqlTableDependency<tblMapDetail> depMapDetail;
        private SqlTableDependency<tblFloor> depFLoor;
        private SqlTableDependency<tblZCU> depZCU;
        private SqlTableDependency<tblMAP> depMap;
        private string connectStr = $"data source=171.244.0.161;initial Catalog =iParking_ThienVan; user id =adminLogin;password=kztek123456";
        private string mapID = Properties.Settings.Default.selectedMAP;
        public Form1()
        {
            InitializeComponent();
            UISync.Init(this);
        }
        SQLConn[] sqls = null;
        #region:Form
        private async void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                if (File.Exists(Application.StartupPath + "\\SQLConn.xml"))
                {
                    FileXML.ReadXMLSQLConn(Application.StartupPath + "\\SQLConn.xml", ref sqls);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmConnectionConfig: " + ex.Message);
            }
            string cbSQLServerName = sqls[0].SQLServerName;
            string cbSQLDatabaseName = sqls[0].SQLDatabase;
            string cbSQLAuthentication = sqls[0].SQLAuthentication;
            string txtSQLUserName = sqls[0].SQLUserName;
            string txtSQLPassword = CryptorEngine.Decrypt(sqls[0].SQLPassword, true);
            connectStr = $"data source={cbSQLServerName};initial Catalog ={cbSQLDatabaseName}; user id ={txtSQLUserName};password={txtSQLPassword}";
            AssignRealtimeDBCheck();

            if (Properties.Settings.Default.selectedMAP == "")
            {
                if (StaticPool.mapCollection.Count > 0)
                {
                    Properties.Settings.Default.selectedMAP = StaticPool.mapCollection[0].ID;
                    Properties.Settings.Default.Save();
                    mapID = Properties.Settings.Default.selectedMAP;
                }
            }
            panelMainContent.Enabled = false;
            if (frmLoading.isLoadingSuccess)
            {
                this.Cursor = Cursors.WaitCursor;
                await Task.Run(() =>
                {
                    LoadData();
                });
                panelMainContent.Enabled = true;
                this.Cursor = Cursors.Default;
            }

            depZone.Start();

            depMapDetail.Start();
            depFLoor.Start();
            depZCU.Start();
            depMap.Start();
        }
        private void Form1_Resize(object sender, EventArgs e)
        {
            foreach (Control control in panelMap.Controls.OfType<ucZoneInMap>())
            {
                ucZoneInMap _ucZoneInMap = (ucZoneInMap)control;
                MapDetail mapDetail = StaticPool.mapDetailCollection.GetMapDetail(_ucZoneInMap.MapID, _ucZoneInMap.ZoneID);
                if (mapDetail != null)
                {
                    int posX = (int)mapDetail.PosX;
                    int posY = (int)mapDetail.PosY;
                    int zoneWidth = mapDetail.zoneWidth;
                    int zoneHeight = mapDetail.zoneHeight;

                    StandardizedLocation(ref posX, ref posY, ref zoneWidth, ref zoneHeight, mapDetail.picMapWidth, mapDetail.picMapHeight);
                    _ucZoneInMap.Location = new Point(posX, posY);
                    _ucZoneInMap.Size = new Size(zoneWidth, zoneHeight);
                }
            }
        }
        #endregion

        public void AssignRealtimeDBCheck()
        {
            using (depZone = new SqlTableDependency<tblZone>(connectStr))
            {
                depZone.OnChanged += DepZone_OnChanged;
            }
            using (depMapDetail = new SqlTableDependency<tblMapDetail>(connectStr))
            {
                depMapDetail.OnChanged += DepMapDetail_OnChanged;
            }
            using (depFLoor = new SqlTableDependency<tblFloor>(connectStr))
            {
                depFLoor.OnChanged += DepFLoor_OnChanged;
            }
            using (depZCU = new SqlTableDependency<tblZCU>(connectStr))
            {
                depZCU.OnChanged += DepZCU_OnChanged;
            }
            using (depMap = new SqlTableDependency<tblMAP>(connectStr))
            {
                depMap.OnChanged += DepMap_OnChanged;
            }
        }

        private void DepMap_OnChanged(object sender, TableDependency.SqlClient.Base.EventArgs.RecordChangedEventArgs<tblMAP> e)
        {
            var entry = e.Entity;
            switch (e.ChangeType)
            {
                case ChangeType.Insert:
                    Map insertMap = new Map()
                    {
                        ID = entry.ID,
                        Name = entry.Name,
                        Code = entry.Code,
                        Description = entry.Description,
                        ImagePath = entry.ImagePath
                    };
                    StaticPool.mapCollection.Add(insertMap);
                    lblMaxMapPage?.Invoke(new Action(() => {
                        lblMaxMapPage.Text = (Convert.ToInt32(lblMaxMapPage.Text) + 1).ToString();
                    }));
                    break;
                case ChangeType.Update:
                    Map updateMap = StaticPool.mapCollection.GetMap(entry.ID);
                    if (updateMap != null)
                    {
                        updateMap.ID = entry.ID;
                        if (updateMap.ImagePath != entry.ImagePath)
                        {
                            if (this.mapID == entry.ID)
                            {
                                picMAP?.Invoke(new Action(() =>
                                {
                                    picMAP.Image = Image.FromFile(entry.ImagePath);
                                }));
                            }
                            updateMap.ImagePath = entry.ImagePath;
                            //RefreshMap
                        }
                        if (updateMap.Name != entry.Name)
                        {
                            if (this.mapID == entry.ID)
                            {
                                lbMAPName?.Invoke(new Action(() => {
                                    lbMAPName.Text = entry.Name;
                                }));
                            }
                            updateMap.Name = entry.Name;
                            //RefreshMap
                        }
                        updateMap.Code = entry.Code;
                        updateMap.Description = entry.Description;
                    }
                    break;
                case ChangeType.Delete:
                    Map deleteMap = StaticPool.mapCollection.GetMap(entry.ID);
                    if (deleteMap != null)
                    {
                        StaticPool.mapCollection.Remove(deleteMap);
                    }
                    lblMaxMapPage?.Invoke(new Action(() => {
                        lblMaxMapPage.Text = (Convert.ToInt32(lblMaxMapPage.Text) - 1).ToString();
                    }));
                    break;
            }
        }

        private void DepZCU_OnChanged(object sender, TableDependency.SqlClient.Base.EventArgs.RecordChangedEventArgs<tblZCU> e)
        {
            var entry = e.Entity;
            switch (e.ChangeType)
            {
                case ChangeType.Insert:
                    ZCU insertZCU = new ZCU()
                    {
                        Id = entry.ID,
                        IPAddress = entry.Name,
                        Port = entry.Port,
                        Username = entry._Username,
                        Password = entry._Password,
                        TMA_Cam_Type = entry.TMA_Cam_Type,
                    };
                    StaticPool.zcuCollection.Add(insertZCU);
                    break;
                case ChangeType.Update:
                    ZCU updateZCU = StaticPool.zcuCollection.GetZCUById(entry.ID);
                    if (updateZCU != null)
                    {
                        updateZCU.Id = entry.ID;
                        updateZCU.IPAddress = entry.IPAddress;
                        updateZCU.Port = entry.Port;
                        updateZCU.Username = entry._Username;
                        updateZCU.Password = entry._Password;
                        updateZCU.TMA_Cam_Type = entry.TMA_Cam_Type;
                    }
                    break;
                case ChangeType.Delete:
                    ZCU deleteZCU = StaticPool.zcuCollection.GetZCUById(entry.ID);
                    if (deleteZCU != null)
                    {
                        StaticPool.zcuCollection.Remove(deleteZCU);
                    }
                    break;
            }
        }

        private void DepFLoor_OnChanged(object sender, TableDependency.SqlClient.Base.EventArgs.RecordChangedEventArgs<tblFloor> e)
        {
            var entry = e.Entity;
            switch (e.ChangeType)
            {
                case ChangeType.Insert:
                    Floor insertFloo = new Floor()
                    {
                        Id = entry.ID,
                        Name = entry.Name,
                        Code = entry.Code,
                        Description = entry.Description,
                    };
                    StaticPool.floorCollection.Add(insertFloo);
                    break;
                case ChangeType.Update:
                    Floor updateFloor = StaticPool.floorCollection.GetFloor(entry.ID);
                    if (updateFloor != null)
                    {
                        updateFloor.Id = entry.ID;
                        updateFloor.Name = entry.Name;
                        updateFloor.Code = entry.Code;
                        updateFloor.Description = entry.Description;
                    }
                    break;
                case ChangeType.Delete:
                    Floor deleteZone = StaticPool.floorCollection.GetFloor(entry.ID);
                    if (deleteZone != null)
                    {
                        StaticPool.floorCollection.Remove(deleteZone);
                    }
                    break;
            }
        }

        private void DepMapDetail_OnChanged(object sender, TableDependency.SqlClient.Base.EventArgs.RecordChangedEventArgs<tblMapDetail> e)
        {
            var entry = e.Entity;
            switch (e.ChangeType)
            {
                case ChangeType.Insert:
                    MapDetail insertMapDetail = new MapDetail()
                    {
                        Id = entry.ID,
                        MapId = entry.MapID,
                        ZONEId = entry.ZoneID,
                        zoneWidth = entry.ZoneWidth,
                        zoneHeight = entry.ZoneHeight,
                        PosX = entry.ZonePosX,
                        PosY = entry.ZonePosY,
                        picMapWidth = entry.MapWidth,
                        picMapHeight = entry.MapHeight,
                    };
                    StaticPool.mapDetailCollection.Add(insertMapDetail);
                    AddZoneToMapPanel(insertMapDetail);
                    break;
                case ChangeType.Update:
                    MapDetail updateMapDetail = StaticPool.mapDetailCollection.GetMapDetail(entry.MapID, entry.ZoneID);
                    if (updateMapDetail != null)
                    {
                        updateMapDetail.Id = entry.ID;
                        updateMapDetail.MapId = entry.MapID;
                        updateMapDetail.ZONEId = entry.ZoneID;
                        updateMapDetail.PosX = entry.ZonePosX;
                        updateMapDetail.PosY = entry.ZonePosY;
                        updateMapDetail.zoneWidth = entry.ZoneWidth;
                        updateMapDetail.zoneHeight = entry.ZoneHeight;
                        updateMapDetail.picMapHeight = entry.MapHeight;
                        updateMapDetail.picMapWidth = entry.MapWidth;
                        UpdateZoneInMapPanel(updateMapDetail);
                    }
                    break;
                case ChangeType.Delete:
                    MapDetail mapDetail = StaticPool.mapDetailCollection.GetMapDetail(entry.MapID, entry.ZoneID);
                    if (mapDetail != null)
                    {
                        StaticPool.mapDetailCollection.Remove(mapDetail);
                    }
                    RemoveZoneFromMapPanel(mapDetail);
                    break;
            }
        }

        private void DepZone_OnChanged(object sender, TableDependency.SqlClient.Base.EventArgs.RecordChangedEventArgs<tblZone> e)
        {
            var entry = e.Entity;
            switch (e.ChangeType)
            {
                case ChangeType.Insert:
                    ZONE insertZone = new ZONE()
                    {
                        Id = entry.ID,
                        zoneName = entry.Name,
                        Code = entry.Code,
                        Description = entry.Description,
                        ZCUId = entry.ZCUID,
                        ZoneGroupId = entry.GroupID,
                        Status = entry.Status,
                        ImagePath = entry.ImageSavePath,
                        PlateNum = entry.plateNum,
                        ZcuIndex = entry.ZcuIndex,
                        OrderPlateNumber = entry.OrderPlateNumber,
                    };
                    StaticPool.zoneCollection.Add(insertZone);
                    AddZoneToSlotTable(insertZone);

                    break;
                case ChangeType.Update:
                    ZONE updateZone = StaticPool.zoneCollection.GetZONE(entry.ID);
                    if (updateZone != null)
                    {
                        updateZone.Id = entry.ID;
                        updateZone.zoneName = entry.Name;
                        updateZone.Code = entry.Code;
                        updateZone.Description = entry.Description;
                        updateZone.ZCUId = entry.ZCUID;
                        updateZone.ZoneGroupId = entry.GroupID;
                        updateZone.Status = entry.Status;
                        updateZone.ImagePath = entry.ImageSavePath;
                        updateZone.PlateNum = entry.plateNum;
                        updateZone.ZcuIndex = entry.ZcuIndex;
                        updateZone.OrderPlateNumber = entry.OrderPlateNumber;
                        UpdateZoneInSlotTableData(updateZone);
                    }
                    break;
                case ChangeType.Delete:
                    ZONE deleteZone = StaticPool.zoneCollection.GetZONE(entry.ID);
                    if (deleteZone != null)
                    {
                        StaticPool.zoneCollection.Remove(deleteZone);
                    }
                    StaticPool.isChangeZone = true;
                    StaticPool.isChangeMapDetail = true;
                    StaticPool.isChangeLedDetail = true;
                    StaticPool.isChangeOutputDetail = true;
                    RemoveZoneFromSlotTable(deleteZone);
                    break;
            }
        }


        #region:Zone Dependency
        private void RemoveZoneFromSlotTable(ZONE zone)
        {
            foreach (Control control in panelSlotTableContent.Controls.OfType<ucSlotTable>())
            {
                if (control.Name.Contains(zone.Id))
                {
                    panelSlotTableContent?.Invoke(new Action(() =>
                    {
                        panelSlotTableContent.Controls.Remove(control);
                    }));
                    break;
                }
            }
        }
        private void UpdateZoneInSlotTableData(ZONE zone)
        {
            foreach (Control control in panelMap.Controls.OfType<ucZoneInMap>())
            {
                ucZoneInMap _ucZoneInMap = (ucZoneInMap)control;
                if (_ucZoneInMap.ZoneID == zone.Id)
                {
                    switch (zone.Status)
                    {
                        case (int)EM_ZoneStatusType.UN_OCCUPIED:
                            _ucZoneInMap.Invoke(new Action(() =>
                            {
                                _ucZoneInMap.SetStatus(Color.DarkGreen, zone.zoneName);
                            }));
                            break;
                        case (int)EM_ZoneStatusType.OCCUPIED:
                            _ucZoneInMap.Invoke(new Action(() =>
                            {
                                _ucZoneInMap.SetStatus(Color.DarkRed, zone.zoneName);
                            }));
                            break;
                        case (int)EM_ZoneStatusType.ORDER:
                            _ucZoneInMap.Invoke(new Action(() =>
                            {
                                _ucZoneInMap.SetStatus(Color.DarkGreen, zone.zoneName);
                            }));
                            break;
                        case (int)EM_ZoneStatusType.DISCONNECT:
                            _ucZoneInMap.Invoke(new Action(() =>
                            {
                                _ucZoneInMap.SetStatus(Color.Gray, zone.zoneName);
                            }));
                            break;
                    }
                }
            }

            foreach (Control control in panelSlotTableContent.Controls.OfType<ucSlotTable>())
            {
                if (control.Name.Contains(zone.Id))
                {
                    ZoneGroup zoneGroup = StaticPool.zoneGroupCollection.GetzgById(zone.ZoneGroupId);
                    string floorName = "";
                    if (zoneGroup != null)
                    {
                        Floor floor = StaticPool.floorCollection.GetFloor(zoneGroup.FloorID);
                        if (floor != null)
                        {
                            floorName = floor.Name;
                        }
                    }
                    ucSlotTable uc = (ucSlotTable)control;
                    uc?.Invoke(new Action(() =>
                    {
                        uc.Refresh(zone.Status, zone.zoneName, floorName);
                    }));
                }
            }
        }
        private void AddZoneToSlotTable(ZONE zone)
        {
            ZoneGroup zoneGroup = StaticPool.zoneGroupCollection.GetzgById(zone.ZoneGroupId);
            string floorName = "";
            if (zoneGroup != null)
            {
                Floor floor = StaticPool.floorCollection.GetFloor(zoneGroup.FloorID);
                if (floor != null)
                {
                    floorName = floor.Name;
                }
            }
            panelSlotTableContent?.Invoke(new Action(() =>
            {
                panelSlotTableContent.Controls.Add(new ucSlotTable(zone.Id, zone.zoneName, floorName, zone.Status));
            }));
        }
        #endregion

        #region:mapDetail Dependency
        private void RemoveZoneFromMapPanel(MapDetail mapDetail)
        {
            ucZoneInMap _uc = null;
            foreach (Control control in panelMap.Controls.OfType<ucZoneInMap>())
            {
                ucZoneInMap _ucZoneInMap = (ucZoneInMap)control;
                if (_ucZoneInMap.Name == ("uc:Zone :" + mapDetail.ZONEId))
                {
                    _uc = _ucZoneInMap;
                    break;
                }
            }
            if (_uc != null)
            {
                panelMap?.Invoke(new Action(() =>
                {
                    panelMap.Controls.Remove(_uc);
                }));
            }
        }

        private void UpdateZoneInMapPanel(MapDetail mapDetail)
        {
            ucZoneInMap _uc = null;
            foreach (Control control in panelMap.Controls.OfType<ucZoneInMap>())
            {
                ucZoneInMap _ucZoneInMap = (ucZoneInMap)control;
                if (_ucZoneInMap.Name == ("uc:Zone :" + mapDetail.ZONEId))
                {
                    _uc = _ucZoneInMap;
                    break;
                }
            }
            if (_uc != null)
            {
                panelMap?.Invoke(new Action(() =>
                {
                    panelMap.Controls.Remove(_uc);
                    AddZoneToMapPanel(mapDetail);
                }));
            }
        }
        private void AddZoneToMapPanel(MapDetail mapDetail)
        {
            if (mapDetail.MapId == this.mapID)
            {
                ZONE zone = StaticPool.zoneCollection.GetZONE(mapDetail.ZONEId);
                if (zone != null)
                {
                    int posX = (int)mapDetail.PosX;
                    int posY = (int)mapDetail.PosY;
                    int zoneWidth = mapDetail.zoneWidth;
                    int zoneHeight = mapDetail.zoneHeight;
                    panelMap?.Invoke(new Action(() =>
                    {
                        StandardizedLocation(ref posX, ref posY, ref zoneWidth, ref zoneHeight,mapDetail.picMapWidth,mapDetail.picMapHeight);
                        CreateNewZoneInMap(zone, posX, posY, zoneWidth, zoneHeight);
                    }));
                }
            }
        }
        #endregion

        #region:ZCU Dependency
        #endregion

        #region:Floor Dependency
        #endregion

        #region:Load
        private void LoadData()
        {
            ShowMap(this.mapID);
            LoadSlotTable();
        }
        private void LoadSlotTable()
        {
            foreach (ZONE zone in StaticPool.zoneCollection)
            {
                ZoneGroup zoneGroup = StaticPool.zoneGroupCollection.GetzgById(zone.ZoneGroupId);
                string floorName = "";
                if (zoneGroup != null)
                {
                    Floor floor = StaticPool.floorCollection.GetFloor(zoneGroup.FloorID);
                    if (floor != null)
                    {
                        floorName = floor.Name;
                    }
                }
                ucSlotTable slot = new ucSlotTable(zone.Id, zone.zoneName, floorName, zone.Status);
                slot.Dock = DockStyle.Top;
                panelSlotTableContent?.Invoke(new Action(() =>
                {
                    panelSlotTableContent.Controls.Add(slot);
                }));
            }
        }
        #endregion

        #region:Load Zone In Map
        private void StandardizedLocation(ref int posX, ref int posY, ref int width, ref int height, int mapWidth, int mapHeight)
        {
            int mapDetailWidth = mapWidth;
            int mapDetailHeight = mapHeight;
            int mapDetailPosX = StaticPool.mapSettingInfor.PosX;
            int mapDetailPosY = StaticPool.mapSettingInfor.PosY;

            int mapMainWidth = picMAP.Width;
            int mapMainHeight = picMAP.Height;
            int mapMainPosX = picMAP.Location.X;
            int mapMainPosY = picMAP.Location.Y;

            //UISync.Execute(() =>
            //{
            //    Rectangle screenRectangle = this.RectangleToScreen(this.ClientRectangle);
            //    int titleHeight = screenRectangle.Top - this.Top;
            //});
            //posX = (posX - mapDetailPosX) * mapMainWidth / mapDetailWidth + mapMainPosX;
            //posY = (posY - mapDetailPosY) * mapMainHeight / mapDetailHeight + mapMainPosY;//+ mainMenuStrip.Height;
            //width = width * mapMainWidth / mapDetailWidth;
            //height = height * mapMainHeight / mapDetailHeight;

            posX = (posX - mapDetailPosX) * mapMainWidth / mapDetailWidth + mapMainPosX;
            posY = (posY - mapDetailPosY) * mapMainHeight / mapDetailHeight + mapMainPosY;//+ mainMenuStrip.Height;
            width = width * mapMainWidth / mapDetailWidth > 0 ? width * mapMainWidth / mapDetailWidth : 1;
            height = height * mapMainHeight / mapDetailHeight > 0 ? height * mapMainHeight / mapDetailHeight : 1;

        }
        private void SetUcZoneInMapInfor(ZONE zone, ucZoneInMap _ucZoneInMap)
        {
            _ucZoneInMap.Name = "uc:Zone :" + zone.Id;
            _ucZoneInMap.ZoneID = zone.Id;
            _ucZoneInMap.MapID = this.mapID;
        }
        private void LoadZoneInMap(string mapID)
        {
            Map selectedMap = StaticPool.mapCollection.GetMap(mapID);
            if (selectedMap != null)
            {
                foreach (MapDetail mapDetail in StaticPool.mapDetailCollection)
                {
                    if (mapDetail.MapId == selectedMap.ID)
                    {
                        ZONE zone = StaticPool.zoneCollection.GetZONE(mapDetail.ZONEId);
                        if (zone != null)
                        {
                            int posX = (int)mapDetail.PosX;
                            int posY = (int)mapDetail.PosY;
                            int zoneWidth = mapDetail.zoneWidth;
                            int zoneHeight = mapDetail.zoneHeight;
                            StandardizedLocation(ref posX, ref posY, ref zoneWidth, ref zoneHeight,mapDetail.picMapWidth,mapDetail.picMapHeight);
                            CreateNewZoneInMap(zone, posX, posY, zoneWidth, zoneHeight);
                        }
                    }
                }
            }
        }
        #region:Multi Thread
        private class UISync
        {
            private static ISynchronizeInvoke Sync;
            public static void Init(ISynchronizeInvoke sync)
            {
                Sync = sync;
            }
            public static void Execute(Action action)
            {
                Sync.BeginInvoke(action, null);
            }
        }
        #endregion
        private void CreateNewZoneInMap(ZONE zone, int posX, int posY, int width, int height)
        {
            ucZoneInMap _ucZoneInMap = new ucZoneInMap(zone.zoneName);
            //Name
            SetUcZoneInMapInfor(zone, _ucZoneInMap);
            //Information
            //Sizeinvo
            _ucZoneInMap.Size = new Size(width, height);
            //Locatiom
            _ucZoneInMap.Location = new Point(posX, posY);
            UISync.Execute(() =>
            {
                panelMap.Controls.Add(_ucZoneInMap);
                _ucZoneInMap.BringToFront();
                _ucZoneInMap.AssignHover();
                lbMAPName.BringToFront();
            });
        }



        public void ShowMap(string mapID)
        {
            LoadZoneInMap(mapID);
            Map selectedMap = StaticPool.mapCollection.GetMap(mapID);
            if (selectedMap != null)
            {
                if (File.Exists(selectedMap.ImagePath))
                {
                    picMAP?.Invoke(new Action(() =>
                    {
                        picMAP.Image = Image.FromFile(Path.GetFullPath(selectedMap.ImagePath,Application.StartupPath));
                    }));
                    lbMAPName?.Invoke(new Action(() =>
                    {
                        lbMAPName.Text = selectedMap.Name;
                        lbMAPName.BackColor = Color.White;
                    }));
                }
            }
            int currenMapIndex = GetMapIndex(mapID);
            UISync.Execute(() =>
            {
                txtMapPage.Text = (currenMapIndex + 1) + "";
                lblMaxMapPage.Text = (StaticPool.mapCollection.Count) + "";
            });
            if (StaticPool.mapCollection.Count > 1)
            {
                int lastMapIndex = StaticPool.mapCollection.Count - 1;
                if (currenMapIndex == lastMapIndex)
                {
                    SetLastMap_Direction();
                }
                else if (currenMapIndex == 0)
                {
                    SetFirstMap_Direction();
                }
                else if (currenMapIndex > 0 && currenMapIndex < lastMapIndex - 1)
                {
                    SetNormalMap_Direction();
                }
            }
            else
            {
                UISync.Execute(() =>
                {
                    btnNextMap.Enabled = false;
                    btnLastMap.Enabled = false;
                    btnPreviusMap.Enabled = false;
                    btnPreviusMap.Enabled = false;
                });
            }
            UISync.Execute(() =>
            {
                lbMAPName.BringToFront();
            });
        }
        private void SetNormalMap_Direction()
        {
            UISync.Execute(() =>
            {
                btnNextMap.Enabled = true;
                btnLastMap.Enabled = true;
                btnPreviusMap.Enabled = true;
                btnPreviusMap.Enabled = true;
            });
        }
        private void SetFirstMap_Direction()
        {
            UISync.Execute(() =>
            {
                btnNextMap.Enabled = true;
                btnLastMap.Enabled = true;
                btnPreviusMap.Enabled = false;
                btnFirstMap.Enabled = false;
            });
        }
        private void SetLastMap_Direction()
        {
            UISync.Execute(() =>
            {
                btnNextMap.Enabled = false;
                btnLastMap.Enabled = false;
                btnPreviusMap.Enabled = true;
                btnFirstMap.Enabled = true;
            });
        }
        public void ShowNextMap(string currentMapID)
        {
            ClearOldMapData();
            int currenMapIndex = GetMapIndex(currentMapID);
            int lastMapIndex = StaticPool.mapCollection.Count - 1;
            if (currenMapIndex + 1 == lastMapIndex)
            {
                SetLastMap_Direction();
            }
            else
            {
                SetNormalMap_Direction();
            }
            this.mapID = StaticPool.mapCollection[currenMapIndex + 1].ID;
            StaticPool.selectedMAPID = this.mapID;
            ShowMap(this.mapID);
        }
        public void ShowLastMap()
        {
            ClearOldMapData();
            SetLastMap_Direction();
            this.mapID = StaticPool.mapCollection[StaticPool.mapCollection.Count - 1].ID;
            StaticPool.selectedMAPID = this.mapID;
            ShowMap(this.mapID);
        }
        public void ShowPreviousMap(string currentMapID)
        {
            ClearOldMapData();
            int currenMapIndex = GetMapIndex(currentMapID);
            int firstMapIndex = 0;
            if (currenMapIndex - 1 == firstMapIndex)
            {
                SetFirstMap_Direction();
            }
            else
            {
                SetNormalMap_Direction();
            }
            this.mapID = StaticPool.mapCollection[currenMapIndex - 1].ID;
            StaticPool.selectedMAPID = this.mapID;
            ShowMap(this.mapID);
        }
        public void ShowFirstMap()
        {
            ClearOldMapData();
            SetFirstMap_Direction();
            this.mapID = StaticPool.mapCollection[0].ID;
            StaticPool.selectedMAPID = this.mapID;
            ShowMap(this.mapID);
        }
        List<Control> DeleteControls = new List<Control>();
        private void ClearOldMapData()
        {
            foreach (Control control in panelMap.Controls.OfType<ucZoneInMap>())
            {
                DeleteControls.Add(control);
            }
            foreach (Control deleteControl in DeleteControls)
            {
                panelMap.Controls.Remove(deleteControl);
            }
            DeleteControls.Clear();
            txtMapPage.Text = (GetMapIndex(this.mapID) + 1) + "";
        }
        public int GetMapIndex(string mapID)
        {
            for (int i = 0; i < StaticPool.mapCollection.Count; i++)
            {
                if (StaticPool.mapCollection[i].ID == mapID)
                {
                    return i;
                }
            }
            return -1;
        }
        #endregion

        private void btnNextMap_Click(object sender, EventArgs e)
        {
            ShowNextMap(this.mapID);
            Properties.Settings.Default.selectedMAP = this.mapID;
            Properties.Settings.Default.Save();
        }
        private void btnLastMap_Click(object sender, EventArgs e)
        {
            ShowLastMap();
            Properties.Settings.Default.selectedMAP = this.mapID;
            Properties.Settings.Default.Save();
        }
        private void btnPreviusMap_Click(object sender, EventArgs e)
        {
            ShowPreviousMap(this.mapID);
            Properties.Settings.Default.selectedMAP = this.mapID;
            Properties.Settings.Default.Save();
        }
        private void btnFirstMap_Click(object sender, EventArgs e)
        {
            ShowFirstMap();
            Properties.Settings.Default.selectedMAP = this.mapID;
            Properties.Settings.Default.Save();
        }
    }
}
