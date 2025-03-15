namespace SymbolPicker
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            textBox_search = new TextBox();
            flowLayoutPanel_all = new FlowLayoutPanel();
            textBox_opt = new TextBox();
            label_loading = new Label();
            flowLayoutPanel_recent = new FlowLayoutPanel();
            label1 = new Label();
            label2 = new Label();
            notifyIcon_tray = new NotifyIcon(components);
            contextMenuStrip_tray = new ContextMenuStrip(components);
            toolStripMenuItem_show = new ToolStripMenuItem();
            toolStripMenuItem_settings = new ToolStripMenuItem();
            toolStripMenuItem_exit = new ToolStripMenuItem();
            contextMenuStrip_tray.SuspendLayout();
            SuspendLayout();
            // 
            // textBox_search
            // 
            textBox_search.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            textBox_search.Location = new Point(4, 8);
            textBox_search.Name = "textBox_search";
            textBox_search.Size = new Size(236, 23);
            textBox_search.TabIndex = 2;
            textBox_search.TextChanged += textBox_search_TextChanged;
            textBox_search.Enter += textBox_search_Enter;
            textBox_search.KeyDown += textBox_KeyDown;
            textBox_search.Leave += textBox_search_Leave;
            // 
            // flowLayoutPanel_all
            // 
            flowLayoutPanel_all.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            flowLayoutPanel_all.AutoScroll = true;
            flowLayoutPanel_all.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            flowLayoutPanel_all.Location = new Point(4, 192);
            flowLayoutPanel_all.Name = "flowLayoutPanel_all";
            flowLayoutPanel_all.Size = new Size(236, 133);
            flowLayoutPanel_all.TabIndex = 1;
            // 
            // textBox_opt
            // 
            textBox_opt.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            textBox_opt.Location = new Point(4, 331);
            textBox_opt.Name = "textBox_opt";
            textBox_opt.Size = new Size(236, 23);
            textBox_opt.TabIndex = 0;
            // 
            // label_loading
            // 
            label_loading.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label_loading.BackColor = SystemColors.AppWorkspace;
            label_loading.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label_loading.Location = new Point(91, 220);
            label_loading.Margin = new Padding(0);
            label_loading.Name = "label_loading";
            label_loading.Size = new Size(52, 20);
            label_loading.TabIndex = 1;
            label_loading.Text = "Loading";
            label_loading.TextAlign = ContentAlignment.MiddleCenter;
            label_loading.Visible = false;
            // 
            // flowLayoutPanel_recent
            // 
            flowLayoutPanel_recent.AutoScroll = true;
            flowLayoutPanel_recent.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            flowLayoutPanel_recent.Location = new Point(4, 54);
            flowLayoutPanel_recent.Name = "flowLayoutPanel_recent";
            flowLayoutPanel_recent.Size = new Size(236, 116);
            flowLayoutPanel_recent.TabIndex = 2;
            // 
            // label1
            // 
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(4, 173);
            label1.Name = "label1";
            label1.Size = new Size(37, 16);
            label1.TabIndex = 3;
            label1.Text = "all";
            // 
            // label2
            // 
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(4, 34);
            label2.Name = "label2";
            label2.Size = new Size(41, 17);
            label2.TabIndex = 4;
            label2.Text = "recent";
            // 
            // notifyIcon_tray
            // 
            notifyIcon_tray.ContextMenuStrip = contextMenuStrip_tray;
            notifyIcon_tray.Icon = (Icon)resources.GetObject("notifyIcon_tray.Icon");
            notifyIcon_tray.Text = "Symbol Picker";
            notifyIcon_tray.Visible = true;
            notifyIcon_tray.Click += notifyIcon_tray_Click;
            // 
            // contextMenuStrip_tray
            // 
            contextMenuStrip_tray.Items.AddRange(new ToolStripItem[] { toolStripMenuItem_show, toolStripMenuItem_settings, toolStripMenuItem_exit });
            contextMenuStrip_tray.Name = "contextMenuStrip_tray";
            contextMenuStrip_tray.Size = new Size(181, 92);
            // 
            // toolStripMenuItem_show
            // 
            toolStripMenuItem_show.Name = "toolStripMenuItem_show";
            toolStripMenuItem_show.Size = new Size(180, 22);
            toolStripMenuItem_show.Text = "Show";
            toolStripMenuItem_show.Click += toolStripMenuItem_show_Click;
            // 
            // toolStripMenuItem_settings
            // 
            toolStripMenuItem_settings.Name = "toolStripMenuItem_settings";
            toolStripMenuItem_settings.Size = new Size(180, 22);
            toolStripMenuItem_settings.Text = "Settings";
            toolStripMenuItem_settings.Click += toolStripMenuItem_settings_Click;
            // 
            // toolStripMenuItem_exit
            // 
            toolStripMenuItem_exit.Name = "toolStripMenuItem_exit";
            toolStripMenuItem_exit.Size = new Size(180, 22);
            toolStripMenuItem_exit.Text = "Exit";
            toolStripMenuItem_exit.Click += toolStripMenuItem_exit_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(243, 359);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(flowLayoutPanel_recent);
            Controls.Add(label_loading);
            Controls.Add(textBox_opt);
            Controls.Add(flowLayoutPanel_all);
            Controls.Add(textBox_search);
            Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Symbol Picker";
            TopMost = true;
            FormClosing += Form1_FormClosing;
            Load += Form1_Load;
            KeyDown += Form1_KeyDown;
            contextMenuStrip_tray.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox textBox_search;
        private FlowLayoutPanel flowLayoutPanel_all;
        private TextBox textBox_opt;
        private Label label_loading;
        private FlowLayoutPanel flowLayoutPanel_recent;
        private Label label1;
        private Label label2;
        private NotifyIcon notifyIcon_tray;
        private ContextMenuStrip contextMenuStrip_tray;
        private ToolStripMenuItem toolStripMenuItem_settings;
        private ToolStripMenuItem toolStripMenuItem_exit;
        private ToolStripMenuItem toolStripMenuItem_show;
    }
}