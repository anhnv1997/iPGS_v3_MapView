using iParking.Enums;
using iParking.Events;
using Kztek.Cameras;
using MapView.Object;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MapView
{
    public partial class ucZoneInMap : UserControl
    {
        #region:Properties
        private string zoneName;
        public bool MouseInLeftEdge, MouseInRightEdge, MouseInTopEdge, MouseInBottomEdge;
        bool LeftEdge, RightEdge, TopEdge, BottomEdge, TopLeftCorner, BottomLeftCorner, TopRighttCorner, BottomRightCorner;
        bool isResizing, isMoving;
        private static Point _cursorStartPoint;
        private string mapID = "";
        private string zoneID = "";
        public event ShowMapDetailInfor ShowMapDetailInforEvent;

        #endregion

        #region:Getter, Setter
        public string MapID { get => mapID; set => mapID = value; }
        public string ZoneID { get => zoneID; set => zoneID = value; }
        #endregion

        #region:Contructor
        public ucZoneInMap(string _zoneName)
        {
            InitializeComponent();
            UISync.Init(this);
            this.zoneName = _zoneName;
        }

        private void UcZoneInMap_SizeChanged(object sender, EventArgs e)
        {
        }

        private void lblZoneName_DoubleClick(object sender, EventArgs e)
        {
            ZONE zone = StaticPool.zoneCollection.GetZONE(this.zoneID);
            if (zone != null)
            {
                ZCU zcu = StaticPool.zcuCollection.GetZCUById(zone.ZCUId);
                if (zcu != null)
                {
                    if (zcu.IPAddress != "")
                    {
                        Camera cam = new Camera();
                        cam.ID = "1";
                        cam.Name = "Cam1";
                        cam.VideoSource = zcu.IPAddress;
                        cam.HttpPort = 80;
                        cam.ServerPort = 0;
                        cam.Chanel = 1;
                        cam.Login = zcu.Username;
                        cam.Password = zcu.Password;
                        cam.CameraType = CameraTypes.GetType("Hanse");
                        cam.StreamType = StreamType.H264;
                        cam.Resolution = "1920x1080";
                        cam.LPRRegions = "";
                        cam.UsingPlugins = 0;
                        cam.Description = "";

                        cam.Start();
                        if (cam != null && cam.videoSourcePlayer != null)
                        {
                            ((Control)cam.videoSourcePlayer).Name = "camera_videoSourcePlayer";
                            ((Control)cam.videoSourcePlayer).Dock = DockStyle.Fill;
                            frmShowZoneDetail frm = new frmShowZoneDetail(zone, cam);
                            frm.ShowDialog();
                        }
                    }
                }
            }
        }
        #endregion

        #region:Event
        void GetZoneDetail(ZCU zcu, ref string imagePath)
        {


        }
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
        public static void ScaleLabel(Label label, float stepSize = 0.5f)
        {
            if (label.Width == 0)
            {
                return;
            }
            if (label.Width * label.Height > label.Font.Size * label.Text.Length)
            {
                while (label.Width * label.Height > label.Font.Size * label.Text.Length * label.Font.Height)
                {
                    label.Font = new Font(label.Font.FontFamily, label.Font.Size + stepSize, label.Font.Style);
                }

            }
            else
            {
                while (label.Font.Size > 0.5 && label.Width * label.Height < label.Font.Size * label.Text.Length * label.Font.Height)
                {
                    label.Font = new Font(label.Font.FontFamily, label.Font.Size - stepSize, label.Font.Style);
                }
            }
            while ((label.Width) < label.Font.Size * 1.2 && label.Font.Size > 0.5)
            {
                label.Font = new Font(label.Font.FontFamily, label.Font.Size - stepSize, label.Font.Style);
            }

            int textInRow = (int)((label.Width) / label.Font.Size);

            int textLine = (label.Text.Length / textInRow) - (int)(label.Text.Length / textInRow) > 0 ? (int)(label.Text.Length / textInRow) + 1 : (int)(label.Text.Length / textInRow);
            while (label.Height < (label.Font.Height * 1.2) * (textLine + 2) && label.Font.Size > 0.5)
            {
                textInRow = (int)((label.Width) / label.Font.Size);
                if (textInRow == 0)
                {
                    return;
                }
                textLine = (label.Text.Length / textInRow) - (int)(label.Text.Length / textInRow) > 0 ? (int)(label.Text.Length / textInRow) + 1 : (int)(label.Text.Length / textInRow);
                label.Font = new Font(label.Font.FontFamily, label.Font.Size - stepSize, label.Font.Style);
            }
            //if (label.Font.Size > 2 && label.Height>1.5 * label.Height)
            //{
            //    label.Font = new Font(label.Font.FontFamily, label.Font.Size - 2, label.Font.Style);
            //}
        }
        //public static void ScaleLabel(Label label, float stepSize = 0.5f)
        //{

        //    if (label.Width * label.Height > label.Font.Size * label.Text.Length)
        //    {
        //        while (label.Width * label.Height > label.Font.Size * label.Text.Length * label.Font.Height)
        //        {
        //            label.Font = new Font(label.Font.FontFamily, label.Font.Size + stepSize, label.Font.Style);
        //        }

        //    }
        //    else
        //    {
        //        while (label.Font.Size > 0.5 && label.Width * label.Height < label.Font.Size * label.Text.Length * label.Font.Height)
        //        {
        //            label.Font = new Font(label.Font.FontFamily, label.Font.Size - stepSize, label.Font.Style);
        //        }
        //    }
        //    while ((label.Width) < label.Font.Size * 1.5 && label.Font.Size > 0.5)
        //    {
        //        label.Font = new Font(label.Font.FontFamily, label.Font.Size - stepSize, label.Font.Style);
        //    }
        //    int textInRow = (int)((label.Width) / label.Font.Size);

        //    int textLine = (label.Text.Length / textInRow) - (int)(label.Text.Length / textInRow) > 0 ? (int)(label.Text.Length / textInRow) + 1 : (int)(label.Text.Length / textInRow);
        //    while (label.Height < (label.Font.Height * 1.5) * (textLine + 2) && label.Font.Size > 0.5)
        //    {
        //        textInRow = (int)((label.Width) / label.Font.Size);
        //        if (textInRow == 0)
        //        {
        //            return;
        //        }
        //        textLine = (label.Text.Length / textInRow) - (int)(label.Text.Length / textInRow) > 0 ? (int)(label.Text.Length / textInRow) + 1 : (int)(label.Text.Length / textInRow);
        //        label.Font = new Font(label.Font.FontFamily, label.Font.Size - stepSize, label.Font.Style);
        //    }
        //    //11111111111
        //    //if (label.Width * label.Height > label.Font.Size * label.Text.Length)
        //    //{
        //    //    while (label.Width * label.Height > label.Font.Size * label.Text.Length * label.Font.Height)
        //    //    {
        //    //        label.Font = new Font(label.Font.FontFamily, label.Font.Size + stepSize, label.Font.Style);
        //    //    }
        //    //}
        //    //else
        //    //{
        //    //    while (label.Width * label.Height < label.Font.Size * label.Text.Length * label.Font.Height && label.Font.Size > 0.5)
        //    //    {
        //    //        label.Font = new Font(label.Font.FontFamily, label.Font.Size - stepSize, label.Font.Style);
        //    //    }
        //    //}
        //    //int textLine = (label.Font.Size * label.Text.Length / label.Width) - (int)(label.Font.Size * label.Text.Length / label.Width) > 0 ? (int)(label.Font.Size * label.Text.Length / label.Width) + 1 : (int)(label.Font.Size * label.Text.Length / label.Width);
        //    //while (label.Height < (label.Font.Height + 3) * textLine && label.Font.Size > 0.5)
        //    //{
        //    //    textLine = (label.Font.Size * label.Text.Length / label.Width) - (int)(label.Font.Size * label.Text.Length / label.Width) > 0 ? (int)(label.Font.Size * label.Text.Length / label.Width) + 1 : (int)(label.Font.Size * label.Text.Length / label.Width);
        //    //    label.Font = new Font(label.Font.FontFamily, label.Font.Size - stepSize, label.Font.Style);
        //    //}
        //    //while (label.Width < label.Font.Size && label.Font.Size > 0.5)
        //    //{
        //    //    label.Font = new Font(label.Font.FontFamily, label.Font.Size - stepSize, label.Font.Style);
        //    //}
        //    //if (label.Font.Size > 1)
        //    //    label.Font = new Font(label.Font.FontFamily, label.Font.Size - 1, label.Font.Style);
            
        //    //if(Screen.PrimaryScreen.Bounds.Width == 3840)
        //    //{
        //    //    if (label.Font.Size > 16)
        //    //        label.Font = new Font(label.Font.FontFamily, 16, label.Font.Style);
        //    //}
        //    //else
        //    //{
        //    //    if (label.Font.Size > 12)
        //    //        label.Font = new Font(label.Font.FontFamily, 12, label.Font.Style);
        //    //}
        //    //if (label.Font.Size > 1.5)
        //    //    label.Font = new Font(label.Font.FontFamily, label.Font.Size - 1.5f, label.Font.Style);
        //}

        private void lblZoneName_TextChanged(object sender, EventArgs e)
        {
            ScaleLabel(lblZoneName);
        }

        private void ucZoneInMap_SizeChanged_1(object sender, EventArgs e)
        {
            string data = lblZoneName.Text;
            if (lblZoneName.Text != "")
            {
                ScaleLabel(lblZoneName);
            }
        }

        public void AssignHover()
        {
            lblZoneName.MouseHover += lblZoneName_MouseHover;
        }
        public void AsignAllowDrag()
        {
            lblZoneName.MouseMove += picZoneStatus_MouseMove;
            lblZoneName.MouseDown += picZoneStatus_MouseDown;
            lblZoneName.MouseUp += picZoneStatus_MouseUp;
        }
        public void AssignBlink()
        {
            timerBlink.Enabled = true;
        }
        #endregion

        #region:Form
        private void ucZoneInMap_Load(object sender, EventArgs e)
        {
            lblZoneName.Text = this.zoneName;
            ZONE zone = StaticPool.zoneCollection.GetZONE(this.zoneID);
            if (zone != null)
            {
                switch (zone.Status)
                {
                    case (int)EM_ZoneStatusType.UN_OCCUPIED:
                        lblZoneName.BackColor = Color.DarkGreen;
                        lblZoneName.ForeColor = SystemColors.ControlLightLight;
                        break;
                    case (int)EM_ZoneStatusType.DISCONNECT:
                        lblZoneName.BackColor = Color.Gray;
                        lblZoneName.ForeColor = SystemColors.ControlLightLight;
                        break;
                    case (int)EM_ZoneStatusType.ORDER:
                        lblZoneName.BackColor = Color.DarkGreen;
                        lblZoneName.ForeColor = SystemColors.ControlLightLight;
                        break;
                    case (int)EM_ZoneStatusType.OCCUPIED:
                        lblZoneName.BackColor = Color.DarkRed;
                        lblZoneName.ForeColor = SystemColors.ControlLightLight;
                        break;
                    default:
                        lblZoneName.BackColor = SystemColors.Control;
                        break;
                }
            }
            this.SizeChanged += UcZoneInMap_SizeChanged;

        }
        #endregion

        #region:Control In Form
        private void picZoneStatus_MouseMove(object sender, MouseEventArgs e)
        {
            if (!isResizing && !isMoving)
            {
                MouseInLeftEdge = Math.Abs(e.X) <= 2;
                MouseInRightEdge = Math.Abs(e.X - this.Width) <= 5;
                MouseInTopEdge = Math.Abs(e.Y) <= 2;
                MouseInBottomEdge = Math.Abs(e.Y - this.Height) <= 5;
                LeftEdge = MouseInLeftEdge == true && MouseInTopEdge == false && MouseInBottomEdge == false;
                RightEdge = MouseInRightEdge == true && MouseInTopEdge == false && MouseInBottomEdge == false;
                TopEdge = MouseInLeftEdge == false && MouseInRightEdge == false && MouseInTopEdge == true;
                BottomEdge = MouseInBottomEdge == true && MouseInLeftEdge == false && MouseInRightEdge == false;
                TopLeftCorner = MouseInLeftEdge == true && MouseInTopEdge == true;
                BottomLeftCorner = MouseInLeftEdge == true && MouseInBottomEdge == true;
                TopRighttCorner = MouseInRightEdge == true && MouseInTopEdge == true;
                BottomRightCorner = MouseInRightEdge == true && MouseInBottomEdge == true;
                if (LeftEdge)
                {
                    this.Cursor = Cursors.SizeWE;
                }
                else if (RightEdge) { this.Cursor = Cursors.SizeWE; }
                else if (TopEdge) { this.Cursor = Cursors.SizeNS; }
                else if (BottomEdge) { this.Cursor = Cursors.SizeNS; }
                else if (TopLeftCorner) { this.Cursor = Cursors.SizeNWSE; }
                else if (BottomLeftCorner) { this.Cursor = Cursors.SizeNESW; }
                else if (TopRighttCorner) { this.Cursor = Cursors.SizeNESW; }
                else if (BottomRightCorner) { this.Cursor = Cursors.SizeNWSE; }
                else { this.Cursor = Cursors.Hand; }
                _cursorStartPoint = new Point(e.X, e.Y);
            }
            else
            {
                int X = this.Width;
                int Y = this.Height;
                if (isResizing)
                {
                    if (LeftEdge)
                    {
                        this.Location = new Point(e.X + this.Location.X, this.Location.Y);
                        this.Size = new Size(this.Width - e.X, this.Height);
                    }
                    else if (RightEdge)
                    {
                        this.Size = new Size(e.X, this.Height);
                    }
                    else if (TopEdge)
                    {
                        this.Location = new Point(this.Location.X, e.Y + this.Location.Y);
                        this.Size = new Size(this.Width, this.Height - e.Y);
                    }
                    else if (BottomEdge)
                    {
                        this.Size = new Size(this.Width, e.Y);
                    }
                    else if (TopLeftCorner)
                    {
                        this.Location = new Point(e.X + this.Location.X, e.Y + this.Location.Y);
                        this.Size = new Size(this.Width - e.X, this.Height - e.Y);
                    }
                    else if (BottomLeftCorner)
                    {
                        this.Location = new Point(e.X + this.Location.X, this.Location.Y);
                        this.Size = new Size(this.Width - e.X, e.Y);
                    }
                    else if (TopRighttCorner)
                    {
                        this.Location = new Point(this.Location.X, e.Y + this.Location.Y);
                        this.Size = new Size(e.X, this.Height - e.Y);
                    }
                    else if (BottomRightCorner)
                    {
                        this.Location = new Point(this.Location.X, this.Location.Y);
                        this.Size = new Size(e.X, e.Y);
                    }
                }
                else if (isMoving)
                {
                    int x = (e.X - _cursorStartPoint.X) + this.Left;
                    int y = (e.Y - _cursorStartPoint.Y) + this.Top;
                    this.Location = new Point(x, y);
                }
            }

        }
        private void picZoneStatus_MouseUp(object sender, MouseEventArgs e)
        {
            bool isExist = false;
            isResizing = false;
            isMoving = false;
        }
        private void picZoneStatus_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (MouseInLeftEdge || MouseInRightEdge || MouseInTopEdge || MouseInBottomEdge)
                {
                    isResizing = true;
                    isMoving = false;
                }
                else
                {
                    isResizing = false;
                    isMoving = true;
                }
            }
        }

        private void lblZoneName_MouseHover(object sender, EventArgs e)
        {
            ZONE zone = StaticPool.zoneCollection.GetZONE(this.zoneID);
            if (zone != null)
            {
                ZoneGroup zoneGroup = StaticPool.zoneGroupCollection.GetzgById(zone.ZoneGroupId);
                if (zoneGroup != null)
                {
                    Floor floor = StaticPool.floorCollection.GetFloor(zoneGroup.FloorID);
                    string floorName = "";
                    if (floor != null)
                    {
                        floorName = floor.Name;
                        toolTip1.Show($"Floor: {floorName}\r\nGroup: {zoneGroup.Name}\r\nZone : {zone.zoneName}", lblZoneName);
                    }
                }
            }
        }
        #endregion

        #region :Timer
        private void timerBlink_Tick(object sender, EventArgs e)
        {
            if (this.Visible == true)
            {
                this.Visible = false;
                return;
            }
            this.Visible = true;
        }
        #endregion

        #region:Internal
        public void SetStatus(Color color)
        {
            lblZoneName.BackColor = color;
        }
        public void SetStatus(Color color, string zoneName)
        {
            lblZoneName.BackColor = color;
            if (color == Color.DarkGreen || color == Color.DarkRed || color == Color.Gray)
                lblZoneName.ForeColor = SystemColors.ControlLightLight;
            else
                lblZoneName.ForeColor = Color.Black;
            lblZoneName.Text = zoneName;
        }
        #endregion
    }
}
