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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            textBox_search = new TextBox();
            flowLayoutPanel_all = new FlowLayoutPanel();
            textBox_opt = new TextBox();
            label_loading = new Label();
            flowLayoutPanel_recent = new FlowLayoutPanel();
            label1 = new Label();
            label2 = new Label();
            SuspendLayout();
            // 
            // textBox_search
            // 
            textBox_search.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBox_search.Location = new Point(4, 4);
            textBox_search.Name = "textBox_search";
            textBox_search.Size = new Size(247, 23);
            textBox_search.TabIndex = 0;
            textBox_search.TextChanged += textBox_search_TextChanged;
            textBox_search.Enter += textBox_search_Enter;
            textBox_search.KeyDown += textBox_KeyDown;
            textBox_search.Leave += textBox_search_Leave;
            // 
            // flowLayoutPanel_all
            // 
            flowLayoutPanel_all.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            flowLayoutPanel_all.AutoScroll = true;
            flowLayoutPanel_all.Location = new Point(4, 192);
            flowLayoutPanel_all.Name = "flowLayoutPanel_all";
            flowLayoutPanel_all.Size = new Size(247, 133);
            flowLayoutPanel_all.TabIndex = 1;
            // 
            // textBox_opt
            // 
            textBox_opt.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            textBox_opt.Location = new Point(4, 331);
            textBox_opt.Name = "textBox_opt";
            textBox_opt.Size = new Size(247, 23);
            textBox_opt.TabIndex = 2;
            // 
            // label_loading
            // 
            label_loading.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label_loading.BackColor = SystemColors.AppWorkspace;
            label_loading.Location = new Point(91, 220);
            label_loading.Margin = new Padding(0);
            label_loading.Name = "label_loading";
            label_loading.Size = new Size(63, 20);
            label_loading.TabIndex = 1;
            label_loading.Text = "Loading";
            label_loading.TextAlign = ContentAlignment.MiddleCenter;
            label_loading.Visible = false;
            // 
            // flowLayoutPanel_recent
            // 
            flowLayoutPanel_recent.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            flowLayoutPanel_recent.AutoScroll = true;
            flowLayoutPanel_recent.Location = new Point(4, 49);
            flowLayoutPanel_recent.Name = "flowLayoutPanel_recent";
            flowLayoutPanel_recent.Size = new Size(247, 121);
            flowLayoutPanel_recent.TabIndex = 2;
            // 
            // label1
            // 
            label1.Location = new Point(4, 173);
            label1.Name = "label1";
            label1.Size = new Size(37, 16);
            label1.TabIndex = 3;
            label1.Text = "all";
            // 
            // label2
            // 
            label2.Location = new Point(2, 29);
            label2.Name = "label2";
            label2.Size = new Size(54, 17);
            label2.TabIndex = 4;
            label2.Text = "recent";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 16F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(254, 359);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(flowLayoutPanel_recent);
            Controls.Add(label_loading);
            Controls.Add(textBox_opt);
            Controls.Add(flowLayoutPanel_all);
            Controls.Add(textBox_search);
            Font = new Font("Segoe UI Variable Display", 9F, FontStyle.Regular, GraphicsUnit.Point);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Form1";
            Opacity = 0.9D;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Symbol Picker";
            TopMost = true;
            FormClosing += Form1_FormClosing;
            Load += Form1_Load;
            KeyDown += Form1_KeyDown;
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
    }
}