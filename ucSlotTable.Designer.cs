
namespace iParking.UserControls
{
    partial class ucSlotTable
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lbZoneName = new System.Windows.Forms.Label();
            this.lbZoneStatus = new System.Windows.Forms.Label();
            this.lbStartTime = new System.Windows.Forms.Label();
            this.lbParkingTimeCount = new System.Windows.Forms.Label();
            this.timerParkingTimeCount = new System.Windows.Forms.Timer(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset;
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 59F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 95F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 97F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.lbZoneName, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lbZoneStatus, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lbStartTime, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.lbParkingTimeCount, 3, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(400, 38);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // lbZoneName
            // 
            this.lbZoneName.AutoSize = true;
            this.lbZoneName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbZoneName.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lbZoneName.Location = new System.Drawing.Point(5, 2);
            this.lbZoneName.Name = "lbZoneName";
            this.lbZoneName.Size = new System.Drawing.Size(53, 34);
            this.lbZoneName.TabIndex = 0;
            this.lbZoneName.Text = "Slot Name";
            this.lbZoneName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbZoneStatus
            // 
            this.lbZoneStatus.AutoSize = true;
            this.lbZoneStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbZoneStatus.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lbZoneStatus.Location = new System.Drawing.Point(63, 2);
            this.lbZoneStatus.Margin = new System.Windows.Forms.Padding(0);
            this.lbZoneStatus.Name = "lbZoneStatus";
            this.lbZoneStatus.Size = new System.Drawing.Size(95, 34);
            this.lbZoneStatus.TabIndex = 2;
            this.lbZoneStatus.Text = "UnOccupied";
            this.lbZoneStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbZoneStatus.TextChanged += new System.EventHandler(this.lbZoneStatus_TextChanged);
            // 
            // lbStartTime
            // 
            this.lbStartTime.AutoSize = true;
            this.lbStartTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbStartTime.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lbStartTime.Location = new System.Drawing.Point(163, 2);
            this.lbStartTime.Name = "lbStartTime";
            this.lbStartTime.Size = new System.Drawing.Size(91, 34);
            this.lbStartTime.TabIndex = 3;
            this.lbStartTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbParkingTimeCount
            // 
            this.lbParkingTimeCount.AutoSize = true;
            this.lbParkingTimeCount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbParkingTimeCount.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lbParkingTimeCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.lbParkingTimeCount.Location = new System.Drawing.Point(262, 2);
            this.lbParkingTimeCount.Name = "lbParkingTimeCount";
            this.lbParkingTimeCount.Size = new System.Drawing.Size(133, 34);
            this.lbParkingTimeCount.TabIndex = 4;
            this.lbParkingTimeCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timerParkingTimeCount
            // 
            this.timerParkingTimeCount.Interval = 1000;
            this.timerParkingTimeCount.Tick += new System.EventHandler(this.timerParkingTimeCount_Tick);
            // 
            // ucSlotTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "ucSlotTable";
            this.Size = new System.Drawing.Size(400, 38);
            this.Load += new System.EventHandler(this.ucSlotTable_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lbZoneName;
        private System.Windows.Forms.Label lbZoneStatus;
        private System.Windows.Forms.Label lbStartTime;
        private System.Windows.Forms.Label lbParkingTimeCount;
        private System.Windows.Forms.Timer timerParkingTimeCount;
    }
}
