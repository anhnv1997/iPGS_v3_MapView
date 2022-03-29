
namespace MapView
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panelMap = new System.Windows.Forms.Panel();
            this.lbMAPName = new System.Windows.Forms.Label();
            this.picMAP = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.btnFirstMap = new FontAwesome.Sharp.IconButton();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.lblMaxMapPage = new System.Windows.Forms.Label();
            this.txtMapPage = new System.Windows.Forms.TextBox();
            this.btnPreviusMap = new FontAwesome.Sharp.IconButton();
            this.btnLastMap = new FontAwesome.Sharp.IconButton();
            this.btnNextMap = new FontAwesome.Sharp.IconButton();
            this.panelMainContent = new System.Windows.Forms.TableLayoutPanel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabSlotTable = new System.Windows.Forms.TabPage();
            this.panelSlotTable = new System.Windows.Forms.TableLayoutPanel();
            this.panelSlotTableTittle = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.panelSlotTableContent = new System.Windows.Forms.FlowLayoutPanel();
            this.tableLayoutPanel1.SuspendLayout();
            this.panelMap.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picMAP)).BeginInit();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.panelMainContent.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabSlotTable.SuspendLayout();
            this.panelSlotTable.SuspendLayout();
            this.panelSlotTableTittle.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panelMap, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(384, 581);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // panelMap
            // 
            this.panelMap.Controls.Add(this.lbMAPName);
            this.panelMap.Controls.Add(this.picMAP);
            this.panelMap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMap.Location = new System.Drawing.Point(0, 0);
            this.panelMap.Margin = new System.Windows.Forms.Padding(0);
            this.panelMap.Name = "panelMap";
            this.panelMap.Size = new System.Drawing.Size(384, 551);
            this.panelMap.TabIndex = 2;
            // 
            // lbMAPName
            // 
            this.lbMAPName.AutoSize = true;
            this.lbMAPName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbMAPName.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbMAPName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lbMAPName.Location = new System.Drawing.Point(0, 0);
            this.lbMAPName.Name = "lbMAPName";
            this.lbMAPName.Size = new System.Drawing.Size(92, 23);
            this.lbMAPName.TabIndex = 3;
            this.lbMAPName.Text = "MapName";
            // 
            // picMAP
            // 
            this.picMAP.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.picMAP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picMAP.Location = new System.Drawing.Point(0, 0);
            this.picMAP.Margin = new System.Windows.Forms.Padding(0);
            this.picMAP.Name = "picMAP";
            this.picMAP.Size = new System.Drawing.Size(384, 551);
            this.picMAP.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picMAP.TabIndex = 2;
            this.picMAP.TabStop = false;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 7;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.btnFirstMap, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel4, 3, 0);
            this.tableLayoutPanel3.Controls.Add(this.btnPreviusMap, 2, 0);
            this.tableLayoutPanel3.Controls.Add(this.btnLastMap, 5, 0);
            this.tableLayoutPanel3.Controls.Add(this.btnNextMap, 4, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 551);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(384, 30);
            this.tableLayoutPanel3.TabIndex = 3;
            // 
            // btnFirstMap
            // 
            this.btnFirstMap.FlatAppearance.BorderSize = 0;
            this.btnFirstMap.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFirstMap.IconChar = FontAwesome.Sharp.IconChar.AngleDoubleLeft;
            this.btnFirstMap.IconColor = System.Drawing.Color.Black;
            this.btnFirstMap.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnFirstMap.IconSize = 32;
            this.btnFirstMap.Location = new System.Drawing.Point(96, 3);
            this.btnFirstMap.Name = "btnFirstMap";
            this.btnFirstMap.Padding = new System.Windows.Forms.Padding(0, 4, 0, 0);
            this.btnFirstMap.Size = new System.Drawing.Size(21, 24);
            this.btnFirstMap.TabIndex = 4;
            this.btnFirstMap.UseVisualStyleBackColor = true;
            this.btnFirstMap.Click += new System.EventHandler(this.btnFirstMap_Click);
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel4.ColumnCount = 3;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 55F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.tableLayoutPanel4.Controls.Add(this.label1, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.lblMaxMapPage, 2, 0);
            this.tableLayoutPanel4.Controls.Add(this.txtMapPage, 0, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(143, 0);
            this.tableLayoutPanel4.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(90, 30);
            this.tableLayoutPanel4.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(38, 1);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 28);
            this.label1.TabIndex = 0;
            this.label1.Text = "/";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblMaxMapPage
            // 
            this.lblMaxMapPage.AutoSize = true;
            this.lblMaxMapPage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMaxMapPage.Enabled = false;
            this.lblMaxMapPage.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblMaxMapPage.Location = new System.Drawing.Point(59, 1);
            this.lblMaxMapPage.Margin = new System.Windows.Forms.Padding(0);
            this.lblMaxMapPage.Name = "lblMaxMapPage";
            this.lblMaxMapPage.Size = new System.Drawing.Size(30, 28);
            this.lblMaxMapPage.TabIndex = 2;
            this.lblMaxMapPage.Text = "99";
            this.lblMaxMapPage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtMapPage
            // 
            this.txtMapPage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtMapPage.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.txtMapPage.Location = new System.Drawing.Point(1, 1);
            this.txtMapPage.Margin = new System.Windows.Forms.Padding(0);
            this.txtMapPage.Name = "txtMapPage";
            this.txtMapPage.Size = new System.Drawing.Size(36, 29);
            this.txtMapPage.TabIndex = 3;
            this.txtMapPage.Text = "99";
            this.txtMapPage.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnPreviusMap
            // 
            this.btnPreviusMap.FlatAppearance.BorderSize = 0;
            this.btnPreviusMap.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPreviusMap.IconChar = FontAwesome.Sharp.IconChar.AngleLeft;
            this.btnPreviusMap.IconColor = System.Drawing.Color.Black;
            this.btnPreviusMap.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnPreviusMap.IconSize = 32;
            this.btnPreviusMap.Location = new System.Drawing.Point(123, 3);
            this.btnPreviusMap.Name = "btnPreviusMap";
            this.btnPreviusMap.Padding = new System.Windows.Forms.Padding(0, 4, 0, 0);
            this.btnPreviusMap.Size = new System.Drawing.Size(17, 24);
            this.btnPreviusMap.TabIndex = 4;
            this.btnPreviusMap.UseVisualStyleBackColor = true;
            this.btnPreviusMap.Click += new System.EventHandler(this.btnPreviusMap_Click);
            // 
            // btnLastMap
            // 
            this.btnLastMap.FlatAppearance.BorderSize = 0;
            this.btnLastMap.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLastMap.IconChar = FontAwesome.Sharp.IconChar.AngleDoubleRight;
            this.btnLastMap.IconColor = System.Drawing.Color.Black;
            this.btnLastMap.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnLastMap.IconSize = 32;
            this.btnLastMap.Location = new System.Drawing.Point(263, 3);
            this.btnLastMap.Name = "btnLastMap";
            this.btnLastMap.Padding = new System.Windows.Forms.Padding(0, 4, 0, 0);
            this.btnLastMap.Size = new System.Drawing.Size(24, 24);
            this.btnLastMap.TabIndex = 4;
            this.btnLastMap.UseVisualStyleBackColor = true;
            this.btnLastMap.Click += new System.EventHandler(this.btnLastMap_Click);
            // 
            // btnNextMap
            // 
            this.btnNextMap.FlatAppearance.BorderSize = 0;
            this.btnNextMap.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNextMap.IconChar = FontAwesome.Sharp.IconChar.AngleRight;
            this.btnNextMap.IconColor = System.Drawing.Color.Black;
            this.btnNextMap.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnNextMap.IconSize = 32;
            this.btnNextMap.Location = new System.Drawing.Point(236, 3);
            this.btnNextMap.Name = "btnNextMap";
            this.btnNextMap.Padding = new System.Windows.Forms.Padding(0, 4, 0, 0);
            this.btnNextMap.Size = new System.Drawing.Size(21, 24);
            this.btnNextMap.TabIndex = 4;
            this.btnNextMap.UseVisualStyleBackColor = true;
            this.btnNextMap.Click += new System.EventHandler(this.btnNextMap_Click);
            // 
            // panelMainContent
            // 
            this.panelMainContent.ColumnCount = 2;
            this.panelMainContent.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelMainContent.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 420F));
            this.panelMainContent.Controls.Add(this.tableLayoutPanel1, 0, 0);
            this.panelMainContent.Controls.Add(this.tabControl1, 1, 0);
            this.panelMainContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMainContent.Location = new System.Drawing.Point(0, 0);
            this.panelMainContent.Name = "panelMainContent";
            this.panelMainContent.RowCount = 1;
            this.panelMainContent.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelMainContent.Size = new System.Drawing.Size(804, 581);
            this.panelMainContent.TabIndex = 2;
            // 
            // tabControl1
            // 
            this.tabControl1.Appearance = System.Windows.Forms.TabAppearance.Buttons;
            this.tabControl1.Controls.Add(this.tabSlotTable);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(384, 0);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.Padding = new System.Drawing.Point(0, 0);
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(420, 581);
            this.tabControl1.TabIndex = 2;
            // 
            // tabSlotTable
            // 
            this.tabSlotTable.Controls.Add(this.panelSlotTable);
            this.tabSlotTable.Location = new System.Drawing.Point(4, 27);
            this.tabSlotTable.Name = "tabSlotTable";
            this.tabSlotTable.Padding = new System.Windows.Forms.Padding(3);
            this.tabSlotTable.Size = new System.Drawing.Size(412, 550);
            this.tabSlotTable.TabIndex = 1;
            this.tabSlotTable.Text = "Slot Table";
            this.tabSlotTable.UseVisualStyleBackColor = true;
            // 
            // panelSlotTable
            // 
            this.panelSlotTable.ColumnCount = 1;
            this.panelSlotTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelSlotTable.Controls.Add(this.panelSlotTableTittle, 0, 0);
            this.panelSlotTable.Controls.Add(this.panelSlotTableContent, 0, 1);
            this.panelSlotTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelSlotTable.Location = new System.Drawing.Point(3, 3);
            this.panelSlotTable.Margin = new System.Windows.Forms.Padding(0);
            this.panelSlotTable.Name = "panelSlotTable";
            this.panelSlotTable.RowCount = 2;
            this.panelSlotTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.panelSlotTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelSlotTable.Size = new System.Drawing.Size(406, 544);
            this.panelSlotTable.TabIndex = 1;
            // 
            // panelSlotTableTittle
            // 
            this.panelSlotTableTittle.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset;
            this.panelSlotTableTittle.ColumnCount = 4;
            this.panelSlotTableTittle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 59F));
            this.panelSlotTableTittle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 95F));
            this.panelSlotTableTittle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 97F));
            this.panelSlotTableTittle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelSlotTableTittle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.panelSlotTableTittle.Controls.Add(this.label2, 0, 0);
            this.panelSlotTableTittle.Controls.Add(this.label4, 1, 0);
            this.panelSlotTableTittle.Controls.Add(this.label5, 2, 0);
            this.panelSlotTableTittle.Controls.Add(this.label6, 3, 0);
            this.panelSlotTableTittle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelSlotTableTittle.Location = new System.Drawing.Point(0, 0);
            this.panelSlotTableTittle.Margin = new System.Windows.Forms.Padding(0);
            this.panelSlotTableTittle.Name = "panelSlotTableTittle";
            this.panelSlotTableTittle.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.panelSlotTableTittle.RowCount = 1;
            this.panelSlotTableTittle.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelSlotTableTittle.Size = new System.Drawing.Size(406, 40);
            this.panelSlotTableTittle.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(9, 2);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 36);
            this.label2.TabIndex = 0;
            this.label2.Text = "Slot Name";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(70, 2);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 36);
            this.label4.TabIndex = 2;
            this.label4.Text = "Status";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(167, 2);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(91, 36);
            this.label5.TabIndex = 3;
            this.label5.Text = "Start Time";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(266, 2);
            this.label6.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(138, 36);
            this.label6.TabIndex = 4;
            this.label6.Text = "Parking Time";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelSlotTableContent
            // 
            this.panelSlotTableContent.AutoScroll = true;
            this.panelSlotTableContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelSlotTableContent.Location = new System.Drawing.Point(0, 40);
            this.panelSlotTableContent.Margin = new System.Windows.Forms.Padding(0);
            this.panelSlotTableContent.Name = "panelSlotTableContent";
            this.panelSlotTableContent.Size = new System.Drawing.Size(406, 504);
            this.panelSlotTableContent.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(804, 581);
            this.Controls.Add(this.panelMainContent);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "iParking";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panelMap.ResumeLayout(false);
            this.panelMap.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picMAP)).EndInit();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.panelMainContent.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabSlotTable.ResumeLayout(false);
            this.panelSlotTable.ResumeLayout(false);
            this.panelSlotTableTittle.ResumeLayout(false);
            this.panelSlotTableTittle.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.PictureBox picMAP;
        private System.Windows.Forms.TableLayoutPanel panelMainContent;
        private System.Windows.Forms.Panel panelMap;
        private System.Windows.Forms.Label lbMAPName;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblMaxMapPage;
        private System.Windows.Forms.TextBox txtMapPage;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabSlotTable;
        private System.Windows.Forms.FlowLayoutPanel panelSlotTableContent;
        private System.Windows.Forms.TableLayoutPanel panelSlotTable;
        private System.Windows.Forms.TableLayoutPanel panelSlotTableTittle;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private FontAwesome.Sharp.IconButton btnFirstMap;
        private FontAwesome.Sharp.IconButton btnPreviusMap;
        private FontAwesome.Sharp.IconButton btnNextMap;
        private FontAwesome.Sharp.IconButton btnLastMap;
    }
}

