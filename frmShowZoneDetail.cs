using iParking.Enums;
using Kztek.Cameras;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MapView
{
    public partial class frmShowZoneDetail : Form
    {
        private Camera cam;
        public frmShowZoneDetail(ZONE _zone,Camera _cam)
        {
            InitializeComponent();
            this.Size = new Size(Screen.PrimaryScreen.Bounds.Width * 60 / 100, Screen.PrimaryScreen.Bounds.Height * 60 / 100);
            this.cam = _cam;
            if (_zone != null)
            {
                lblStatus.Text = Enum.GetName(typeof(EM_ZoneStatusType), _zone.Status);
                lblZoneName.Text = _zone.zoneName;
            }
            else
            {
                lblStatus.Text = "";
                lblZoneName.Text = "";
            }
            if (cam != null && cam.videoSourcePlayer != null)
            {
                ((Control)cam.videoSourcePlayer).Name = "camera_videoSourcePlayer";
                ((Control)cam.videoSourcePlayer).Dock = DockStyle.Fill;
                this.panelMap.Controls.Add((Control)cam.videoSourcePlayer);
            }
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private async void frmShowZoneDetail_FormClosing(object sender, FormClosingEventArgs e)
        {
            cam.Stop();
        }
    }
}
