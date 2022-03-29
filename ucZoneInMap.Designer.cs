
namespace MapView
{
    partial class ucZoneInMap
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lblZoneName = new System.Windows.Forms.Label();
            this.timerBlink = new System.Windows.Forms.Timer(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.imageZoneImage = new System.Windows.Forms.ImageList(this.components);
            this.SuspendLayout();
            // 
            // lblZoneName
            // 
            this.lblZoneName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblZoneName.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblZoneName.Location = new System.Drawing.Point(0, 0);
            this.lblZoneName.Name = "lblZoneName";
            this.lblZoneName.Size = new System.Drawing.Size(81, 117);
            this.lblZoneName.TabIndex = 0;
            this.lblZoneName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblZoneName.TextChanged += new System.EventHandler(this.lblZoneName_TextChanged);
            this.lblZoneName.DoubleClick += new System.EventHandler(this.lblZoneName_DoubleClick);
            // 
            // timerBlink
            // 
            this.timerBlink.Interval = 1000;
            this.timerBlink.Tick += new System.EventHandler(this.timerBlink_Tick);
            // 
            // imageZoneImage
            // 
            this.imageZoneImage.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageZoneImage.ImageSize = new System.Drawing.Size(16, 16);
            this.imageZoneImage.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // ucZoneInMap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.lblZoneName);
            this.Name = "ucZoneInMap";
            this.Size = new System.Drawing.Size(81, 117);
            this.Load += new System.EventHandler(this.ucZoneInMap_Load);
            this.SizeChanged += new System.EventHandler(this.ucZoneInMap_SizeChanged_1);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblZoneName;
        private System.Windows.Forms.Timer timerBlink;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ImageList imageZoneImage;
    }
}
