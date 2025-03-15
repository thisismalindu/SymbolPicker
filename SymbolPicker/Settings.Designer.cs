namespace SymbolPicker
{
    partial class Settings
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
            tabControl1 = new TabControl();
            tabPage_window = new TabPage();
            flowLayoutPanel1 = new FlowLayoutPanel();
            label1 = new Label();
            trackBar_intrans = new TrackBar();
            label_intrans_value = new Label();
            checkBox_tray = new CheckBox();
            tabPage_start = new TabPage();
            flowLayoutPanel2 = new FlowLayoutPanel();
            label2 = new Label();
            checkBox_reg_hotkey = new CheckBox();
            flowLayoutPanel3 = new FlowLayoutPanel();
            label3 = new Label();
            textBox_hotkey = new TextBox();
            button_save = new Button();
            tabControl1.SuspendLayout();
            tabPage_window.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)trackBar_intrans).BeginInit();
            tabPage_start.SuspendLayout();
            flowLayoutPanel2.SuspendLayout();
            flowLayoutPanel3.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage_window);
            tabControl1.Controls.Add(tabPage_start);
            tabControl1.Dock = DockStyle.Top;
            tabControl1.Location = new Point(0, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(407, 307);
            tabControl1.TabIndex = 0;
            // 
            // tabPage_window
            // 
            tabPage_window.Controls.Add(flowLayoutPanel1);
            tabPage_window.Location = new Point(4, 26);
            tabPage_window.Name = "tabPage_window";
            tabPage_window.Padding = new Padding(3);
            tabPage_window.Size = new Size(399, 277);
            tabPage_window.TabIndex = 0;
            tabPage_window.Text = "Window";
            tabPage_window.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.Controls.Add(label1);
            flowLayoutPanel1.Controls.Add(trackBar_intrans);
            flowLayoutPanel1.Controls.Add(label_intrans_value);
            flowLayoutPanel1.Controls.Add(checkBox_tray);
            flowLayoutPanel1.Dock = DockStyle.Fill;
            flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel1.Location = new Point(3, 3);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(393, 271);
            flowLayoutPanel1.TabIndex = 0;
            flowLayoutPanel1.WrapContents = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(3, 0);
            label1.Name = "label1";
            label1.Size = new Size(146, 17);
            label1.TabIndex = 3;
            label1.Text = "Intransparency (50-100)";
            // 
            // trackBar_intrans
            // 
            trackBar_intrans.LargeChange = 1;
            trackBar_intrans.Location = new Point(3, 20);
            trackBar_intrans.Maximum = 100;
            trackBar_intrans.Minimum = 50;
            trackBar_intrans.Name = "trackBar_intrans";
            trackBar_intrans.Size = new Size(383, 45);
            trackBar_intrans.TabIndex = 4;
            trackBar_intrans.Value = 70;
            trackBar_intrans.ValueChanged += trackBar_intrans_ValueChanged;
            // 
            // label_intrans_value
            // 
            label_intrans_value.AutoSize = true;
            label_intrans_value.Location = new Point(3, 68);
            label_intrans_value.Name = "label_intrans_value";
            label_intrans_value.Size = new Size(22, 17);
            label_intrans_value.TabIndex = 6;
            label_intrans_value.Text = "70";
            // 
            // checkBox_tray
            // 
            checkBox_tray.Checked = true;
            checkBox_tray.CheckState = CheckState.Checked;
            checkBox_tray.Location = new Point(3, 88);
            checkBox_tray.Name = "checkBox_tray";
            checkBox_tray.Size = new Size(383, 41);
            checkBox_tray.TabIndex = 5;
            checkBox_tray.Text = "Rather than close the app, minimize the app to tray when click \"close\"";
            checkBox_tray.UseVisualStyleBackColor = true;
            // 
            // tabPage_start
            // 
            tabPage_start.Controls.Add(flowLayoutPanel2);
            tabPage_start.Location = new Point(4, 26);
            tabPage_start.Name = "tabPage_start";
            tabPage_start.Padding = new Padding(3);
            tabPage_start.Size = new Size(399, 277);
            tabPage_start.TabIndex = 1;
            tabPage_start.Text = "Start";
            tabPage_start.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanel2
            // 
            flowLayoutPanel2.AutoScroll = true;
            flowLayoutPanel2.Controls.Add(label2);
            flowLayoutPanel2.Controls.Add(checkBox_reg_hotkey);
            flowLayoutPanel2.Controls.Add(flowLayoutPanel3);
            flowLayoutPanel2.Dock = DockStyle.Fill;
            flowLayoutPanel2.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel2.Location = new Point(3, 3);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.Size = new Size(393, 271);
            flowLayoutPanel2.TabIndex = 1;
            flowLayoutPanel2.WrapContents = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(3, 0);
            label2.Name = "label2";
            label2.Size = new Size(49, 17);
            label2.TabIndex = 3;
            label2.Text = "Hotkey";
            // 
            // checkBox_reg_hotkey
            // 
            checkBox_reg_hotkey.AutoSize = true;
            checkBox_reg_hotkey.Checked = true;
            checkBox_reg_hotkey.CheckState = CheckState.Checked;
            checkBox_reg_hotkey.Location = new Point(3, 20);
            checkBox_reg_hotkey.Name = "checkBox_reg_hotkey";
            checkBox_reg_hotkey.Size = new Size(118, 21);
            checkBox_reg_hotkey.TabIndex = 4;
            checkBox_reg_hotkey.Text = "Register hotkey";
            checkBox_reg_hotkey.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanel3
            // 
            flowLayoutPanel3.Controls.Add(label3);
            flowLayoutPanel3.Controls.Add(textBox_hotkey);
            flowLayoutPanel3.Location = new Point(3, 47);
            flowLayoutPanel3.Name = "flowLayoutPanel3";
            flowLayoutPanel3.Size = new Size(387, 30);
            flowLayoutPanel3.TabIndex = 5;
            // 
            // label3
            // 
            label3.Location = new Point(3, 0);
            label3.Name = "label3";
            label3.Size = new Size(46, 30);
            label3.TabIndex = 0;
            label3.Text = "Ctrl + ";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // textBox_hotkey
            // 
            textBox_hotkey.Location = new Point(55, 3);
            textBox_hotkey.Name = "textBox_hotkey";
            textBox_hotkey.ReadOnly = true;
            textBox_hotkey.Size = new Size(100, 23);
            textBox_hotkey.TabIndex = 1;
            textBox_hotkey.Text = "B";
            textBox_hotkey.KeyPress += textBox_hotkey_KeyPress;
            // 
            // button_save
            // 
            button_save.Dock = DockStyle.Bottom;
            button_save.Location = new Point(0, 306);
            button_save.Name = "button_save";
            button_save.Size = new Size(407, 30);
            button_save.TabIndex = 1;
            button_save.Text = "Save settings (need to restart)";
            button_save.UseVisualStyleBackColor = true;
            button_save.Click += button_save_Click;
            // 
            // Settings
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(407, 336);
            Controls.Add(button_save);
            Controls.Add(tabControl1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "Settings";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Settings";
            FormClosing += Settings_FormClosing;
            Load += Settings_Load;
            tabControl1.ResumeLayout(false);
            tabPage_window.ResumeLayout(false);
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)trackBar_intrans).EndInit();
            tabPage_start.ResumeLayout(false);
            flowLayoutPanel2.ResumeLayout(false);
            flowLayoutPanel2.PerformLayout();
            flowLayoutPanel3.ResumeLayout(false);
            flowLayoutPanel3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl1;
        private TabPage tabPage_window;
        private TabPage tabPage_start;
        private FlowLayoutPanel flowLayoutPanel1;
        private Label label1;
        private FlowLayoutPanel flowLayoutPanel2;
        private Label label2;
        private CheckBox checkBox2;
        private FlowLayoutPanel flowLayoutPanel3;
        private Label label3;
        private Button button_save;
        private Label label_intrans_value;
        public TrackBar trackBar_intrans;
        public CheckBox checkBox_tray;
        public CheckBox checkBox_reg_hotkey;
        public TextBox textBox_hotkey;
    }
}