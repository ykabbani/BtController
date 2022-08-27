namespace BTController
{
    partial class BTController
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.portToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparatorSelect = new System.Windows.Forms.ToolStripSeparator();
            this.refreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.baudRateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem9600 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem38400 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem115200 = new System.Windows.Forms.ToolStripMenuItem();
            this.gamepadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.refreshToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.logGroupBox = new System.Windows.Forms.GroupBox();
            this.logTextBox = new System.Windows.Forms.TextBox();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.fwdBtn = new System.Windows.Forms.Button();
            this.bwdBtn = new System.Windows.Forms.Button();
            this.leftBtn = new System.Windows.Forms.Button();
            this.rightBtn = new System.Windows.Forms.Button();
            this.controlsGroupBox = new System.Windows.Forms.GroupBox();
            this.rightLbl = new System.Windows.Forms.Label();
            this.bwdLbl = new System.Windows.Forms.Label();
            this.leftLbl = new System.Windows.Forms.Label();
            this.fwdLbl = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.noneRdioBtn = new System.Windows.Forms.RadioButton();
            this.controllerRdioBtn = new System.Windows.Forms.RadioButton();
            this.keyboardRdioBtn = new System.Windows.Forms.RadioButton();
            this.calibrateChkBox = new System.Windows.Forms.CheckBox();
            this.trackBarGroupBox = new System.Windows.Forms.GroupBox();
            this.speedTextBox = new System.Windows.Forms.TextBox();
            this.speedTrackBar = new System.Windows.Forms.TrackBar();
            this.controllerTimer = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1.SuspendLayout();
            this.logGroupBox.SuspendLayout();
            this.controlsGroupBox.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.trackBarGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.speedTrackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.portToolStripMenuItem,
            this.baudRateToolStripMenuItem,
            this.gamepadToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(277, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // portToolStripMenuItem
            // 
            this.portToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.selectToolStripMenuItem,
            this.openToolStripMenuItem,
            this.closeToolStripMenuItem});
            this.portToolStripMenuItem.Name = "portToolStripMenuItem";
            this.portToolStripMenuItem.Size = new System.Drawing.Size(41, 20);
            this.portToolStripMenuItem.Text = "Port";
            // 
            // selectToolStripMenuItem
            // 
            this.selectToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparatorSelect,
            this.refreshToolStripMenuItem});
            this.selectToolStripMenuItem.Name = "selectToolStripMenuItem";
            this.selectToolStripMenuItem.Size = new System.Drawing.Size(105, 22);
            this.selectToolStripMenuItem.Text = "Select";
            // 
            // toolStripSeparatorSelect
            // 
            this.toolStripSeparatorSelect.Name = "toolStripSeparatorSelect";
            this.toolStripSeparatorSelect.Size = new System.Drawing.Size(110, 6);
            // 
            // refreshToolStripMenuItem
            // 
            this.refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
            this.refreshToolStripMenuItem.Size = new System.Drawing.Size(113, 22);
            this.refreshToolStripMenuItem.Text = "Refresh";
            this.refreshToolStripMenuItem.Click += new System.EventHandler(this.refreshToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(105, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Enabled = false;
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(105, 22);
            this.closeToolStripMenuItem.Text = "Close";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // baudRateToolStripMenuItem
            // 
            this.baudRateToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem9600,
            this.toolStripMenuItem38400,
            this.toolStripMenuItem115200});
            this.baudRateToolStripMenuItem.Name = "baudRateToolStripMenuItem";
            this.baudRateToolStripMenuItem.Size = new System.Drawing.Size(72, 20);
            this.baudRateToolStripMenuItem.Text = "Baud Rate";
            // 
            // toolStripMenuItem9600
            // 
            this.toolStripMenuItem9600.Checked = true;
            this.toolStripMenuItem9600.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toolStripMenuItem9600.Name = "toolStripMenuItem9600";
            this.toolStripMenuItem9600.Size = new System.Drawing.Size(110, 22);
            this.toolStripMenuItem9600.Text = "9600";
            this.toolStripMenuItem9600.Click += new System.EventHandler(this.selectClickHandler);
            // 
            // toolStripMenuItem38400
            // 
            this.toolStripMenuItem38400.Name = "toolStripMenuItem38400";
            this.toolStripMenuItem38400.Size = new System.Drawing.Size(110, 22);
            this.toolStripMenuItem38400.Text = "38400";
            this.toolStripMenuItem38400.Click += new System.EventHandler(this.selectClickHandler);
            // 
            // toolStripMenuItem115200
            // 
            this.toolStripMenuItem115200.Name = "toolStripMenuItem115200";
            this.toolStripMenuItem115200.Size = new System.Drawing.Size(110, 22);
            this.toolStripMenuItem115200.Text = "115200";
            this.toolStripMenuItem115200.Click += new System.EventHandler(this.selectClickHandler);
            // 
            // gamepadToolStripMenuItem
            // 
            this.gamepadToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.refreshToolStripMenuItem1});
            this.gamepadToolStripMenuItem.Name = "gamepadToolStripMenuItem";
            this.gamepadToolStripMenuItem.Size = new System.Drawing.Size(70, 20);
            this.gamepadToolStripMenuItem.Text = "Gamepad";
            // 
            // refreshToolStripMenuItem1
            // 
            this.refreshToolStripMenuItem1.Name = "refreshToolStripMenuItem1";
            this.refreshToolStripMenuItem1.Size = new System.Drawing.Size(113, 22);
            this.refreshToolStripMenuItem1.Text = "Refresh";
            this.refreshToolStripMenuItem1.Click += new System.EventHandler(this.refreshToolStripMenuItem1_Click);
            // 
            // logGroupBox
            // 
            this.logGroupBox.Controls.Add(this.logTextBox);
            this.logGroupBox.Location = new System.Drawing.Point(12, 363);
            this.logGroupBox.Name = "logGroupBox";
            this.logGroupBox.Size = new System.Drawing.Size(256, 90);
            this.logGroupBox.TabIndex = 2;
            this.logGroupBox.TabStop = false;
            this.logGroupBox.Text = "Log";
            // 
            // logTextBox
            // 
            this.logTextBox.AcceptsReturn = true;
            this.logTextBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.logTextBox.Location = new System.Drawing.Point(7, 20);
            this.logTextBox.Multiline = true;
            this.logTextBox.Name = "logTextBox";
            this.logTextBox.ReadOnly = true;
            this.logTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.logTextBox.Size = new System.Drawing.Size(243, 64);
            this.logTextBox.TabIndex = 0;
            this.logTextBox.TabStop = false;
            // 
            // fwdBtn
            // 
            this.fwdBtn.BackColor = System.Drawing.SystemColors.ControlLight;
            this.fwdBtn.Enabled = false;
            this.fwdBtn.Location = new System.Drawing.Point(93, 136);
            this.fwdBtn.Name = "fwdBtn";
            this.fwdBtn.Size = new System.Drawing.Size(72, 48);
            this.fwdBtn.TabIndex = 3;
            this.fwdBtn.TabStop = false;
            this.fwdBtn.Tag = "f";
            this.fwdBtn.Text = "Forward";
            this.fwdBtn.UseVisualStyleBackColor = false;
            this.fwdBtn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.mouseDown);
            this.fwdBtn.MouseUp += new System.Windows.Forms.MouseEventHandler(this.mouseUp);
            // 
            // bwdBtn
            // 
            this.bwdBtn.Enabled = false;
            this.bwdBtn.Location = new System.Drawing.Point(93, 190);
            this.bwdBtn.Name = "bwdBtn";
            this.bwdBtn.Size = new System.Drawing.Size(72, 48);
            this.bwdBtn.TabIndex = 4;
            this.bwdBtn.TabStop = false;
            this.bwdBtn.Tag = "b";
            this.bwdBtn.Text = "Backward";
            this.bwdBtn.UseVisualStyleBackColor = true;
            this.bwdBtn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.mouseDown);
            this.bwdBtn.MouseUp += new System.Windows.Forms.MouseEventHandler(this.mouseUp);
            // 
            // leftBtn
            // 
            this.leftBtn.Enabled = false;
            this.leftBtn.Location = new System.Drawing.Point(15, 190);
            this.leftBtn.Name = "leftBtn";
            this.leftBtn.Size = new System.Drawing.Size(72, 48);
            this.leftBtn.TabIndex = 5;
            this.leftBtn.TabStop = false;
            this.leftBtn.Tag = "l";
            this.leftBtn.Text = "Left";
            this.leftBtn.UseVisualStyleBackColor = true;
            this.leftBtn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.mouseDown);
            this.leftBtn.MouseUp += new System.Windows.Forms.MouseEventHandler(this.mouseUp);
            // 
            // rightBtn
            // 
            this.rightBtn.Enabled = false;
            this.rightBtn.Location = new System.Drawing.Point(171, 190);
            this.rightBtn.Name = "rightBtn";
            this.rightBtn.Size = new System.Drawing.Size(72, 48);
            this.rightBtn.TabIndex = 6;
            this.rightBtn.TabStop = false;
            this.rightBtn.Tag = "r";
            this.rightBtn.Text = "Right";
            this.rightBtn.UseVisualStyleBackColor = true;
            this.rightBtn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.mouseDown);
            this.rightBtn.MouseUp += new System.Windows.Forms.MouseEventHandler(this.mouseUp);
            // 
            // controlsGroupBox
            // 
            this.controlsGroupBox.Controls.Add(this.rightLbl);
            this.controlsGroupBox.Controls.Add(this.bwdLbl);
            this.controlsGroupBox.Controls.Add(this.leftLbl);
            this.controlsGroupBox.Controls.Add(this.fwdLbl);
            this.controlsGroupBox.Controls.Add(this.groupBox1);
            this.controlsGroupBox.Controls.Add(this.fwdBtn);
            this.controlsGroupBox.Controls.Add(this.rightBtn);
            this.controlsGroupBox.Controls.Add(this.bwdBtn);
            this.controlsGroupBox.Controls.Add(this.leftBtn);
            this.controlsGroupBox.Location = new System.Drawing.Point(11, 89);
            this.controlsGroupBox.Name = "controlsGroupBox";
            this.controlsGroupBox.Size = new System.Drawing.Size(255, 268);
            this.controlsGroupBox.TabIndex = 7;
            this.controlsGroupBox.TabStop = false;
            this.controlsGroupBox.Text = "Controls";
            // 
            // rightLbl
            // 
            this.rightLbl.Location = new System.Drawing.Point(172, 241);
            this.rightLbl.Name = "rightLbl";
            this.rightLbl.Size = new System.Drawing.Size(72, 14);
            this.rightLbl.TabIndex = 20;
            this.rightLbl.Tag = "rightBtn";
            this.rightLbl.Text = "Unassigned";
            this.rightLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // bwdLbl
            // 
            this.bwdLbl.Location = new System.Drawing.Point(94, 241);
            this.bwdLbl.Name = "bwdLbl";
            this.bwdLbl.Size = new System.Drawing.Size(72, 14);
            this.bwdLbl.TabIndex = 19;
            this.bwdLbl.Tag = "bwdBtn";
            this.bwdLbl.Text = "Unassigned";
            this.bwdLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // leftLbl
            // 
            this.leftLbl.Location = new System.Drawing.Point(16, 241);
            this.leftLbl.Name = "leftLbl";
            this.leftLbl.Size = new System.Drawing.Size(72, 14);
            this.leftLbl.TabIndex = 18;
            this.leftLbl.Tag = "leftBtn";
            this.leftLbl.Text = "Unassigned";
            this.leftLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // fwdLbl
            // 
            this.fwdLbl.Location = new System.Drawing.Point(94, 119);
            this.fwdLbl.Name = "fwdLbl";
            this.fwdLbl.Size = new System.Drawing.Size(72, 14);
            this.fwdLbl.TabIndex = 17;
            this.fwdLbl.Tag = "fwdBtn";
            this.fwdLbl.Text = "Unassigned";
            this.fwdLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.noneRdioBtn);
            this.groupBox1.Controls.Add(this.controllerRdioBtn);
            this.groupBox1.Controls.Add(this.keyboardRdioBtn);
            this.groupBox1.Controls.Add(this.calibrateChkBox);
            this.groupBox1.Location = new System.Drawing.Point(7, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(242, 98);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            // 
            // noneRdioBtn
            // 
            this.noneRdioBtn.AutoSize = true;
            this.noneRdioBtn.Location = new System.Drawing.Point(8, 65);
            this.noneRdioBtn.Name = "noneRdioBtn";
            this.noneRdioBtn.Size = new System.Drawing.Size(51, 17);
            this.noneRdioBtn.TabIndex = 19;
            this.noneRdioBtn.TabStop = true;
            this.noneRdioBtn.Text = "None";
            this.noneRdioBtn.UseVisualStyleBackColor = true;
            this.noneRdioBtn.CheckedChanged += new System.EventHandler(this.noneRdioBtn_CheckedChanged);
            // 
            // controllerRdioBtn
            // 
            this.controllerRdioBtn.AutoSize = true;
            this.controllerRdioBtn.Location = new System.Drawing.Point(7, 42);
            this.controllerRdioBtn.Name = "controllerRdioBtn";
            this.controllerRdioBtn.Size = new System.Drawing.Size(69, 17);
            this.controllerRdioBtn.TabIndex = 17;
            this.controllerRdioBtn.TabStop = true;
            this.controllerRdioBtn.Text = "Controller";
            this.controllerRdioBtn.UseVisualStyleBackColor = true;
            this.controllerRdioBtn.CheckedChanged += new System.EventHandler(this.controllerRdioBtn_CheckedChanged);
            // 
            // keyboardRdioBtn
            // 
            this.keyboardRdioBtn.AutoSize = true;
            this.keyboardRdioBtn.Checked = true;
            this.keyboardRdioBtn.Location = new System.Drawing.Point(7, 19);
            this.keyboardRdioBtn.Name = "keyboardRdioBtn";
            this.keyboardRdioBtn.Size = new System.Drawing.Size(70, 17);
            this.keyboardRdioBtn.TabIndex = 15;
            this.keyboardRdioBtn.TabStop = true;
            this.keyboardRdioBtn.Text = "Keyboard";
            this.keyboardRdioBtn.UseVisualStyleBackColor = true;
            this.keyboardRdioBtn.CheckedChanged += new System.EventHandler(this.keyboardRdioBtn_CheckedChanged);
            // 
            // calibrateChkBox
            // 
            this.calibrateChkBox.Appearance = System.Windows.Forms.Appearance.Button;
            this.calibrateChkBox.Location = new System.Drawing.Point(92, 19);
            this.calibrateChkBox.Name = "calibrateChkBox";
            this.calibrateChkBox.Size = new System.Drawing.Size(145, 40);
            this.calibrateChkBox.TabIndex = 14;
            this.calibrateChkBox.Text = "Calibrate";
            this.calibrateChkBox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.calibrateChkBox.UseVisualStyleBackColor = true;
            this.calibrateChkBox.CheckedChanged += new System.EventHandler(this.cailbrateChkBox_CheckedChanged);
            // 
            // trackBarGroupBox
            // 
            this.trackBarGroupBox.Controls.Add(this.speedTextBox);
            this.trackBarGroupBox.Controls.Add(this.speedTrackBar);
            this.trackBarGroupBox.Location = new System.Drawing.Point(11, 27);
            this.trackBarGroupBox.Name = "trackBarGroupBox";
            this.trackBarGroupBox.Size = new System.Drawing.Size(256, 56);
            this.trackBarGroupBox.TabIndex = 15;
            this.trackBarGroupBox.TabStop = false;
            this.trackBarGroupBox.Text = "Speed";
            // 
            // speedTextBox
            // 
            this.speedTextBox.Location = new System.Drawing.Point(198, 19);
            this.speedTextBox.Name = "speedTextBox";
            this.speedTextBox.Size = new System.Drawing.Size(52, 20);
            this.speedTextBox.TabIndex = 16;
            this.speedTextBox.TabStop = false;
            this.speedTextBox.Text = "0";
            this.speedTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.speedTextBox_KeyPress);
            // 
            // speedTrackBar
            // 
            this.speedTrackBar.AutoSize = false;
            this.speedTrackBar.LargeChange = 10;
            this.speedTrackBar.Location = new System.Drawing.Point(6, 19);
            this.speedTrackBar.Maximum = 255;
            this.speedTrackBar.Name = "speedTrackBar";
            this.speedTrackBar.Size = new System.Drawing.Size(186, 31);
            this.speedTrackBar.SmallChange = 5;
            this.speedTrackBar.TabIndex = 15;
            this.speedTrackBar.TabStop = false;
            this.speedTrackBar.TickFrequency = 6000;
            this.speedTrackBar.Scroll += new System.EventHandler(this.speedTrackBar_Scroll);
            // 
            // controllerTimer
            // 
            this.controllerTimer.Interval = 40;
            this.controllerTimer.Tick += new System.EventHandler(this.controllerTimer_Tick);
            // 
            // BTController
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(277, 464);
            this.Controls.Add(this.trackBarGroupBox);
            this.Controls.Add(this.controlsGroupBox);
            this.Controls.Add(this.logGroupBox);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "BTController";
            this.Text = "BtC - By Yousuf K";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.BTController_Closing);
            this.Load += new System.EventHandler(this.BTController_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form_KeyUp);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.logGroupBox.ResumeLayout(false);
            this.logGroupBox.PerformLayout();
            this.controlsGroupBox.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.trackBarGroupBox.ResumeLayout(false);
            this.trackBarGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.speedTrackBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem portToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem selectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem baudRateToolStripMenuItem;
        private System.Windows.Forms.GroupBox logGroupBox;
        private System.Windows.Forms.TextBox logTextBox;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem9600;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem38400;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem115200;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparatorSelect;
        private System.Windows.Forms.ToolStripMenuItem refreshToolStripMenuItem;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Button fwdBtn;
        private System.Windows.Forms.Button bwdBtn;
        private System.Windows.Forms.Button leftBtn;
        private System.Windows.Forms.Button rightBtn;
        private System.Windows.Forms.GroupBox controlsGroupBox;
        private System.Windows.Forms.GroupBox trackBarGroupBox;
        private System.Windows.Forms.TrackBar speedTrackBar;
        private System.Windows.Forms.TextBox speedTextBox;
        private System.Windows.Forms.CheckBox calibrateChkBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton controllerRdioBtn;
        private System.Windows.Forms.RadioButton keyboardRdioBtn;
        private System.Windows.Forms.RadioButton noneRdioBtn;
        private System.Windows.Forms.Timer controllerTimer;
        private System.Windows.Forms.Label rightLbl;
        private System.Windows.Forms.Label bwdLbl;
        private System.Windows.Forms.Label leftLbl;
        private System.Windows.Forms.Label fwdLbl;
        private System.Windows.Forms.ToolStripMenuItem gamepadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem refreshToolStripMenuItem1;
    }
}

