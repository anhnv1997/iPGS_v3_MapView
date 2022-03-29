using System;
using System.Collections.Generic;
using MapView.Object;
using MapView.Database;
using MapView.Databases;
using System.Windows.Forms;

namespace MapView
{
    public static class StaticPool
    {
        #region:Properties
        // CSDL
        public static MDB mdb = null;
        
        public static bool isChangeCCU = false;
        public static bool isChangeFloor = false;
        public static bool isChangeLed = false;
        public static bool isChangeLedDetail = false;
        public static bool isChangeMap = false;
        public static bool isChangeMapDetail = false;
        public static bool isChangeOutput = false;
        public static bool isChangeOutputDetail = false;
        public static bool isChangeTMA = false;
        public static bool isChangeVehicleType = false;
        public static bool isChangeZoneGroup = false;
        public static bool isChangeZone = false;
        public static bool isChangeZcu = false;

        public static string selectedMAPID =  Properties.Settings.Default.selectedMAP;
        public static int zoneWidth = Properties.Settings.Default.zoneWidth;
        public static int zoneHeight = Properties.Settings.Default.zoneHeight;

        public static bool isChangeSetting = false;

        public static ZONECollection zoneCollection = new ZONECollection();
        public static ZoneGroupCollection zoneGroupCollection = new ZoneGroupCollection();
        public static FloorCollection floorCollection = new FloorCollection();
        public static MapCollection mapCollection = new MapCollection();
        public static MapDetailCollection mapDetailCollection = new MapDetailCollection();
        public static ZCUCollection zcuCollection = new ZCUCollection();

        #endregion
        #region:Datagridview
        public static string Id(DataGridView dgv)
        {
            string _lcma = "";
            DataGridViewRow _drv = dgv.CurrentRow;
            try
            {
                _lcma = _drv.Cells["_ID"].Value.ToString();
            }
            catch
            {
                _lcma = "";
            }
            return _lcma;
        }
        #endregion

        #region:Load
        public static void LoadGroupData(ComboBox comboBox)
        {
            foreach (ZoneGroup group in StaticPool.zoneGroupCollection)
            {
                ListItem listGroup = new ListItem();
                listGroup.Value = group.Id;
                listGroup.Name = group.Name;
                comboBox.Items.Add(listGroup);
            }
            comboBox.DisplayMember = "Name";
            if (comboBox.Items.Count > 0)
            {
                comboBox.SelectedIndex = 0;
            }
        }
        public static void LoadFloorData(ComboBox comboBox)
        {
            foreach (Floor floor in StaticPool.floorCollection)
            {
                ListItem listFloor = new ListItem();
                listFloor.Value = floor.Id;
                listFloor.Name = floor.Name;
                comboBox.Items.Add(listFloor);
            }
            comboBox.DisplayMember = "Name";
            if (comboBox.Items.Count > 0)
            {
                comboBox.SelectedIndex = 0;
            }
        }
        #endregion

        #region:Math
        public static long HexToDec(string hexNumber)
        {
            return Convert.ToInt64(hexNumber, 16);
        }
        public static string HexToBin(string hexNumber, int binaryLength)
        {
            string binData = Convert.ToString(HexToDec(hexNumber), 2);
            while (binData.Length < 8)
            {
                binData = "0" + binData;
            }
            return binData;
        }
        #endregion
        public static MapSettingInfor mapSettingInfor = new MapSettingInfor();

    }
}
