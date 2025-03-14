using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Simulator;



namespace SymbolPicker
{
    public partial class Form1 : Form
    {
        private static List<Symbol> allSymbols = new List<Symbol>();
        private static List<Button> allSymbolButtons = new List<Button>();

        private static List<Symbol> recentSymbols = new List<Symbol>();
        private static List<Button> recentSymbolButtons = new List<Button>();


        private static string allPath = Application.StartupPath + @"\symbols.txt";
        private static string recentPath = Application.StartupPath + @"\recent.txt";
        private static Font templateFont = new Font("Segoe UI Variable Display", 14F, FontStyle.Regular, GraphicsUnit.Point);
        private static Size templateSize = new System.Drawing.Size(30, 30);


        #region test
        private void TestInit()
        {
            //Console.WriteLine(11);
            //Console.WriteLine(11);
            //Console.WriteLine(11);
            //Console.WriteLine(11);
            //Console.WriteLine(11);
            //MessageBox.Show("1111");
            //Trace.WriteLine("WTF WHY IT WILL NOT CONSOLE WRITELINE ONLY IN THIS PROJECT");
            //Console.WriteLine("Oh wait, Im idiot im on release mode");


            //Trace.WriteLine(KeyboardSimulator.SimulateKeyboard(0, KeyEventFlags.UNICODE, '我', true, 0));
            //Trace.WriteLine(KeyboardSimulator.SimulateKeyboard(0, KeyEventFlags.KEYUP));
        }

        #endregion

        #region init

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadAllButtons();
            LoadRecentButtons();

            AlwaysTopMost();
            if (!HotKey.API_RegisterHotKey(this.Handle, (int)Keys.B, HotKey.control.Ctrl, Keys.B))
            {
                MessageBox.Show("Can not reg hot key!");
            }


            TestInit();



            FadeWindow(false);
        }

        private Button CreateOneButton(string tag, string txt)
        {
            Button button = new Button();
            button.Font = templateFont;
            button.Size = templateSize;
            button.Click += Button_Click;
            button.Tag = tag;

            button.Text = txt;

            return button;
        }
        private void LoadButtons(string path, List<Symbol> lssym, List<Button> lsbtn, FlowLayoutPanel layout, string tag)
        {
            if (!File.Exists(path)) return; //可能是 【最近使用】 还没添加
            try
            {
                string[] linesFromTextFile = File.ReadAllLines(path);
                for (int i = 0; i < linesFromTextFile.Length; i += 2)
                {
                    string name = linesFromTextFile[i];
                    string img = linesFromTextFile[i + 1]; //gets the second line in the section

                    Symbol symbol = new Symbol(name, img);
                    lssym.Add(symbol);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            for (int i = 0; i < lssym.Count; i++)
            {
                Button button = CreateOneButton(tag, lssym[i].img);
                lsbtn.Add(button);
            }

            AddButtonsToLayout(lsbtn, layout);

        }
        private void AddButtonsToLayout(List<Button> lsbtn, FlowLayoutPanel layout)
        {
            layout.Controls.Clear();
            for (int i = 0; i < lsbtn.Count; i++)
            {
                //Button没法Clone
                layout.Controls.Add(lsbtn[i]);
            }
        }
        private void LoadAllButtons()
        {
            LoadButtons(allPath, allSymbols, allSymbolButtons, flowLayoutPanel_all, "all");
        }

        private void LoadRecentButtons()
        {
            LoadButtons(recentPath, recentSymbols, recentSymbolButtons, flowLayoutPanel_recent, "recent");
        }


        private void AlwaysTopMost()
        {
            Task.Run(() =>
            {
                while (true)
                {
                    this.Invoke(new Action(() =>
                    {
                        this.TopMost = true;
                    }));

                    Thread.Sleep(500);
                }
            });
        }
        #endregion

        #region end
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveRecent();
            HotKey.API_UnregisterHotKey(this.Handle, (int)Keys.B);
            Environment.Exit(0); //because the thread in AlwaysTopMost
        }
        public static void SaveRecent()
        {
            string txt = "";
            foreach (Symbol symbol in recentSymbols)
            {
                txt += symbol.name + "\n" + symbol.img + "\n";
            }
            try
            {
                File.WriteAllText(recentPath, txt);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Can not save recent symbols: " + ex.Message, "Error: ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        #endregion

        #region handleOutput
        private const int RECENTKEEPCOUNT = 24;

        private void Button_Click(object? sender, EventArgs e)
        {
            SetNoActivate(this.Handle);
            ShownAndInputToTextbox((Button)sender);
            textBox_search.Text = "";

            #region recent

            #region symbols
            Symbol removeS = recentSymbols.FirstOrDefault(x => x.img == ((Button)sender).Text);
            if (removeS != null)
            {
                recentSymbols.Remove(removeS);
            }

            Symbol addS = allSymbols.FirstOrDefault(x => x.img == ((Button)sender).Text);
            if (addS != null)
            {
                recentSymbols.Insert(0, addS);
            }
            else
            {
                MessageBox.Show("Can not add symbol to recent!");
            }

            if (recentSymbols.Count > RECENTKEEPCOUNT)
            {
                recentSymbols.RemoveAt(recentSymbols.Count - 1);
            }
            #endregion
            #region button

            Button recentBtn = recentSymbolButtons.FirstOrDefault(x => x.Text == ((Button)sender).Text);
            if (recentBtn != null)
            {
                recentSymbolButtons.Remove(recentBtn);
                recentSymbolButtons.Insert(0, recentBtn);
            }
            else
            {
                Button btn = CreateOneButton("recent", addS.img);
                recentSymbolButtons.Insert(0, btn);
            }

            if (recentSymbolButtons.Count > RECENTKEEPCOUNT)
            {
                recentSymbolButtons.RemoveAt(recentSymbolButtons.Count - 1);
                //MessageBox.Show(recentSymbolButtons.Count + "");
            }

            AddButtonsToLayout(recentSymbolButtons, flowLayoutPanel_recent);

            #endregion

            #endregion

        }

        private void ShownAndInputToTextbox(Button sender)
        {
            this.textBox_opt.Text = sender.Text;
            //Clipboard.SetText(sender.Text);
            //this.Hide(); // 隐藏窗口 失去焦点
            Thread.Sleep(10);

            //uint resultDown = KeyboardSimulator.SimulateKeyboard(0x41, KeyEventFlags.KEYDOWN);
            //MessageBox.Show(resultDown + "");
            //KeyboardSimulator.SimulateKeyboard(0, KeyEventFlags.UNICODE, sender.Text[0], true, 0);
            //KeyboardSimulator.SimulateKeyboard(0, KeyEventFlags.KEYUP);

            SimulateUnicodeInput(sender.Text);

            // this.Show(); // 重新显示窗口
        }

        public static void SimulateUnicodeInput(string text)
        {
            foreach (var c in text)
            {
                ushort unicode = (ushort)c; // 直接转换为 Unicode（仅适用于 U+0000 ~ U+FFFF）

                // 发送按键按下事件
                KeyboardSimulator.SimulateKeyboard(0, KeyEventFlags.UNICODE, unicode, true);

                // 发送按键释放事件
                KeyboardSimulator.SimulateKeyboard(0, KeyEventFlags.UNICODE | KeyEventFlags.KEYUP, unicode, true);
            }
        }

        #endregion


        #region handle input

        public void FilterButtons(string text)
        {
            //this.label_loading.Visible = true; 不需要了，已经很快了
            this.Refresh();
            flowLayoutPanel_all.SuspendLayout();  // 暂停 UI 更新，提高性能
            // flowLayoutPanel.Controls.Clear(); // 清除旧的按钮


            if (string.IsNullOrEmpty(text)) //更快
            {
                for (int i = 0; i < allSymbols.Count; i++)
                {
                    allSymbolButtons[i].Visible = true;
                }
            }
            else
            {
                //Stopwatch sw = Stopwatch.StartNew();

                for (int i = 0; i < allSymbols.Count; i++)
                {
                    if (allSymbols[i].name.Contains(text))
                    {
                        allSymbolButtons[i].Visible = true;
                    }
                    else
                    {
                        allSymbolButtons[i].Visible = false;
                    }
                }
                //sw.Stop();
                //Trace.WriteLine(sw.ElapsedMilliseconds);

            }



            flowLayoutPanel_all.ResumeLayout();  // 恢复 UI 更新
            //this.label_loading.Visible = false;
            this.Refresh();
        }



        private CancellationTokenSource CancellationTokenSource;


        private async void textBox_search_TextChanged(object sender, EventArgs e)
        {
            // 取消之前的任务
            CancellationTokenSource?.Cancel();
            CancellationTokenSource = new CancellationTokenSource();
            CancellationToken token = CancellationTokenSource.Token;

            try
            {
                await Task.Delay(150, token);
                if (!token.IsCancellationRequested)
                {
                    FilterButtons(textBox_search.Text); // 执行搜索
                }
            }
            catch (TaskCanceledException)
            {
                // 任务被取消，不做任何处理
            }
        }

        #endregion

        #region window setting


        #region no focus
        [DllImport("user32.dll")]
        private static extern int GetWindowLong(IntPtr hWnd, int nIndex);

        [DllImport("user32.dll")]
        private static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

        private const int GWL_EXSTYLE = -20;
        private const int WS_EX_NOACTIVATE = 0x08000000;

        public static void SetNoActivate(IntPtr hWnd)
        {
            int exStyle = GetWindowLong(hWnd, GWL_EXSTYLE);
            SetWindowLong(hWnd, GWL_EXSTYLE, exStyle | WS_EX_NOACTIVATE);
        }

        public static void CancleNoActivate(IntPtr hWnd)
        {
            int exStyle = GetWindowLong(hWnd, GWL_EXSTYLE);
            SetWindowLong(hWnd, GWL_EXSTYLE, exStyle & ~WS_EX_NOACTIVATE);
        }


        //const int WS_EX_NOACTIVATE = 0x08000000;
        //protected override CreateParams CreateParams
        //{
        //    get
        //    {
        //        CreateParams cp = base.CreateParams;
        //        cp.ExStyle |= WS_EX_NOACTIVATE; // 默认不获取焦点
        //        return cp;
        //    }
        //}

        #endregion

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                textBox_search_Leave(null, null);
                this.WindowState = FormWindowState.Minimized;
            }
        }
        private void textBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Escape)
            {
                textBox_opt.Focus();
            }
            if (e.KeyCode == Keys.Escape)
            {
                textBox_search_Leave(null, null);
                this.WindowState = FormWindowState.Minimized;
            }
        }



        private void textBox_search_Enter(object sender, EventArgs e)
        {
            Trace.WriteLine(1);
            CancleNoActivate(this.Handle);
            this.Activate();
        }

        private void textBox_search_Leave(object sender, EventArgs e)
        {
            Trace.WriteLine(2);
            SetNoActivate(this.Handle);
            this.Hide();
            this.Show(); //cancle activate
        }
        #endregion


        #region hotkey
        public static class HotKey
        {
            [DllImport("user32")]
            private static extern bool RegisterHotKey(IntPtr hWnd, int id, uint control, Keys vk);

            //解除注册热键的api
            [DllImport("user32")]
            private static extern bool UnregisterHotKey(IntPtr hWnd, int id);

            public static bool API_RegisterHotKey(IntPtr hWnd, int id, control control, Keys vk)
            {
                return RegisterHotKey(hWnd, id, (uint)control, vk);
            }
            public static bool API_UnregisterHotKey(IntPtr hWnd, int id)
            {
                return UnregisterHotKey(hWnd, id);
            }
            public enum control : uint
            {
                None = 0,
                Alt = 1,
                Ctrl = 2,
                Shift = 4,
                Windows = 8
            }
        }


        protected override void WndProc(ref Message m) //重写窗口消息
        {
            switch (m.Msg)
            {
                case 0x0312: //hotkey
                    switch ((int)m.WParam)
                    {
                        case (int)Keys.B: //Ctrl+B

                            label1.Focus(); //总是label1就好了
                            if (this.Visible == false) //WindowState == FormWindowState.Minimized
                            {
                                // label1.Focus();
                                //this.Visible = true; //WindowState = FormWindowState.Normal
                                FadeWindow(false);
                                // textBox_search.Focus();
                            }
                            else
                            {
                                // label1.Focus(); //取消search的Focus（让窗口失去焦点，因为Focus那里用了个事件，如果没有了焦点就设置本窗口无焦点）
                                //this.Visible = false; //WindowState = FormWindowState.Minimized
                                FadeWindow(true);
                            }
                            break;
                    }

                    break;
            }
            base.WndProc(ref m);
        }

        private bool startedFade = false;
        private async void FadeWindow(bool fadeOut)
        {
            if (startedFade) return;
            startedFade = true;
            double to = this.Opacity;
            double original = this.Opacity;

            if (!fadeOut)
            {
                this.Opacity = 0;
                this.Visible = true;
            }
            int time = 12;
            for (int i = 0; i < time; i++)
            {
                if (fadeOut)
                {
                    if (this.Opacity - 1.0 / time >= 0) this.Opacity -= 1.0 / time;
                }
                else
                {
                    if (this.Opacity + 1.0 / time <= original) this.Opacity += 1.0 / time;
                }
                await Task.Delay(1);
            }
            if (fadeOut)
            {
                this.Opacity = 0;
                this.Visible = false;
                this.Opacity = original;
            }
            else
            {
                this.Opacity = to;
            }

            startedFade = false;
        }
        #endregion

        private void transparentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // if transparent tool strip menu item is checked, set the form to be transparent
            if (transparentToolStripMenuItem.Checked)
            {
                this.Opacity = 0.7;
            }
            else
            {
                this.Opacity = 1;
            }
        }
    }

    public class Symbol
    {
        public string name;
        public string img;
        public Symbol(string name, string img)
        {
            this.name = name;
            this.img = img;
        }
    }

}

