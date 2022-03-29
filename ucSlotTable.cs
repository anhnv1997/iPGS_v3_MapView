using iParking.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iParking.UserControls
{
    public partial class ucSlotTable : UserControl
    {
        public string ZoneID { get; set; }
        public string ZoneName { get; set; }
        public string FloorName { get; set; }
        public int Status { get; set; }
        public ucSlotTable(string zoneID, string zoneName, string floorName, int status)
        {
            InitializeComponent();
            CreateUcName(zoneID);
            this.ZoneID = ZoneID;
            this.ZoneName = zoneName;
            this.FloorName = floorName;
            this.Status = status;
        }

        private void CreateUcName(string zoneID)
        {
            this.Name = $"SlotTable_Zone:{zoneID}";
        }

        private void ucSlotTable_Load(object sender, EventArgs e)
        {
            lbZoneName.Text = this.ZoneName;
            lbZoneStatus.Text = Enum.GetName(typeof(EM_ZoneStatusType), this.Status);
        }

        private void lbZoneStatus_TextChanged(object sender, EventArgs e)
        {
            if (lbZoneStatus.Text == EM_ZoneStatusType.UN_OCCUPIED.ToString())
            {
                lbZoneStatus.BackColor = Color.DarkGreen;
                lbZoneStatus.ForeColor = SystemColors.ControlLightLight;
                timerParkingTimeCount.Enabled = false;
                lbStartTime.Text = "";
                lbParkingTimeCount.Text = "";
            }
            else if (lbZoneStatus.Text == EM_ZoneStatusType.ORDER.ToString())
            {
                lbZoneStatus.BackColor = Color.DarkGreen;
                lbZoneStatus.ForeColor = SystemColors.ControlLightLight;
            }
            else if (lbZoneStatus.Text == EM_ZoneStatusType.DISCONNECT.ToString())
            {
                lbZoneStatus.BackColor = SystemColors.GrayText;
                lbZoneStatus.ForeColor = SystemColors.ControlLightLight;
                lbStartTime.Text = "";
                lbParkingTimeCount.Text = "";
                timerParkingTimeCount.Enabled = false;
            }
            else if (lbZoneStatus.Text == ""|| lbZoneStatus.Text == "UNKNOWN")
            {
                lbZoneStatus.BackColor = SystemColors.GrayText;
                lbZoneStatus.ForeColor = SystemColors.ControlLightLight;
                lbZoneStatus.Text = "UNKNOWN";
                lbStartTime.Text = "";
                lbParkingTimeCount.Text = "";
                timerParkingTimeCount.Enabled = false;
            }
            else
            {
                lbZoneStatus.BackColor = Color.DarkRed;
                lbZoneStatus.ForeColor = SystemColors.ControlLightLight;
                lbStartTime.Text = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                lbParkingTimeCount.Text = "00:00:00";
                timerParkingTimeCount.Enabled = true;
            }
        }
        public void UpdateStatus(int status)
        {
            lbZoneStatus?.Invoke(new Action(() =>
            {
                lbZoneStatus.Text = Enum.GetName(typeof(EM_ZoneStatusType), status);
            }));
        }
        private void timerParkingTimeCount_Tick(object sender, EventArgs e)
        {
            string endTime = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
            TimeSpan duration = DateTime.Parse(endTime).Subtract(DateTime.Parse(lbStartTime.Text));
            lbParkingTimeCount.Text = duration.Hours.ToString("00") + ":" + duration.Minutes.ToString("00") + ":" + duration.Seconds.ToString("00");
        }
        public void Refresh(int status, string zoneName, string floorName)
        {
            this.ZoneName = zoneName;
            this.FloorName = floorName;
            this.Status = status;
            lbZoneName.Text = this.ZoneName;
            lbZoneStatus.Text = Enum.GetName(typeof(EM_ZoneStatusType), this.Status);
        }
    }
}
