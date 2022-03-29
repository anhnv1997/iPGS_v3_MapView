using Futech.Tools;
using MapView.Database;
using MapView.Databases;
using System;
using System.Data;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MapView.Forms
{
    public partial class frmLoading : Form
    {
        public static bool isLoadingSuccess = false;
        SQLConn[] sqls = null;
        public frmLoading()
        {
            InitializeComponent();
        }

        public async void LoadingData()
        {

        }
        public void SetText(string text)
        {
            lblStatus?.Invoke(new Action(() =>
            {
                lblStatus.Text = text;
            }));
        }
        public void SetProgressValue(int value)
        {
            progressBarLoading?.Invoke(new Action(() =>
            {
                progressBarLoading.Value = value;
            }));
        }
        private async void frmLoading_Load(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            await Task.Run(() =>
            {
                SetProgressValue(progressBarLoading.Minimum);
                SetText("Connect to SQL Server...");
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

                ConnectToSQLServer();

                if (!StaticPool.mdb.OpenMDB())
                {
                    if (MessageBox.Show("Connect To Database Error, Do you want continue", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                    {
                        Environment.Exit(0);
                    }
                    else
                    {
                        this.DialogResult = DialogResult.OK;
                    }
                }
                SetProgressValue(progressBarLoading.Value + 10);

                SetText("Load Floor...");
                tblFloor.LoadDataFloor(StaticPool.floorCollection);
                SetProgressValue(progressBarLoading.Value + 10);

                SetText("Load Map...");
                tblMAP.LoadDataMap(StaticPool.mapCollection);
                SetProgressValue(progressBarLoading.Value + 10);

                SetText("Load Zone Group...");
                tblZoneGroup.LoadDataGroup(StaticPool.zoneGroupCollection);
                SetProgressValue(progressBarLoading.Value + 10);

                SetText("Load Zone...");
                tblZone.LoadDataZone(StaticPool.zoneCollection);
                SetProgressValue(progressBarLoading.Value + 10); 
                
                SetText("Load ZCU...");
                tblZCU.LoadDataZCU(StaticPool.zcuCollection);
                SetProgressValue(progressBarLoading.Value + 10);

                SetText("Load Map Detail...");
                tblMapDetail.LoadMapDetailData(StaticPool.mapDetailCollection);
                SetProgressValue(progressBarLoading.Value + 10);

                SetText("Load Map Setting...");
                LoadMapSettingInfor();
                SetProgressValue(progressBarLoading.Value + 10);


                isLoadingSuccess = true;
                this.DialogResult = DialogResult.OK;
            });

        }
        void LoadMapSettingInfor()
        {
            DataTable dtMapSettingInfor = StaticPool.mdb.FillData("Select Width, Height, PosX,Posy from tblMapSettingInfo");
            if (dtMapSettingInfor != null)
            {
                if (dtMapSettingInfor.Rows.Count > 0)
                {
                    StaticPool.mapSettingInfor.Width = Convert.ToInt32(dtMapSettingInfor.Rows[0]["Width"].ToString());
                    StaticPool.mapSettingInfor.Height = Convert.ToInt32(dtMapSettingInfor.Rows[0]["Height"].ToString());
                    StaticPool.mapSettingInfor.PosX = Convert.ToInt32(dtMapSettingInfor.Rows[0]["PosX"].ToString());
                    StaticPool.mapSettingInfor.PosY = Convert.ToInt32(dtMapSettingInfor.Rows[0]["Posy"].ToString());
                }
            }
        }
        private void ConnectToSQLServer()
        {
            if (sqls != null && sqls.Length > 0)
            {
                string cbSQLServerName = sqls[0].SQLServerName;
                string cbSQLDatabaseName = sqls[0].SQLDatabase;
                string cbSQLAuthentication = sqls[0].SQLAuthentication;
                string txtSQLUserName = sqls[0].SQLUserName;
                string txtSQLPassword = CryptorEngine.Decrypt(sqls[0].SQLPassword, true);
                StaticPool.mdb = new MDB(cbSQLServerName, cbSQLDatabaseName, cbSQLAuthentication, txtSQLUserName, txtSQLPassword);
            }
        }
    }
}
