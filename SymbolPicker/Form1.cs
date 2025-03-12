using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Simulator;



namespace SymbolPicker
{
    public partial class Form1 : Form
    {
        private static List<Symbol> symbols = new List<Symbol>();
        private static List<Button> symbolButtons = new List<Button>();
        private static string path = Application.StartupPath + @"\symbols.txt";
        private static Font templateFont = new Font("Segoe UI Variable Display", 14F, FontStyle.Regular, GraphicsUnit.Point);
        private static Size templateSize = new System.Drawing.Size(30, 30);


        #region init / end

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadButtons();
            AlwaysTopMost();



            TestInit();
        }
        private void TestInit()
        {
            //Console.WriteLine(11);
            //Console.WriteLine(11);
            //Console.WriteLine(11);
            //Console.WriteLine(11);
            //Console.WriteLine(11);
            //MessageBox.Show("1111");
            //Trace.WriteLine("WTF WHY IT WILL NOT CONSOLE WRITELINE ONLY IN THIS PROJECT");
            Console.WriteLine("Fine, you win vs2022, I felt nasty");


            //Trace.WriteLine(KeyboardSimulator.SimulateKeyboard(0, KeyEventFlags.UNICODE, '我', true, 0));
            //Trace.WriteLine(KeyboardSimulator.SimulateKeyboard(0, KeyEventFlags.KEYUP));
        }


        private void LoadButtons()
        {
            try
            {
                string[] linesFromTextFile = File.ReadAllLines(path);
                for (int i = 0; i < linesFromTextFile.Length; i += 2)
                {
                    string name = linesFromTextFile[i];
                    string img = linesFromTextFile[i + 1]; //gets the second line in the section

                    Symbol symbol = new Symbol(name, img);
                    symbols.Add(symbol);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            for (int i = 0; i < symbols.Count; i++)
            {
                {
                    //Button没法Clone
                    Button button = new Button();
                    button.Font = templateFont;
                    button.Size = templateSize;
                    button.Click += Button_Click;
                    button.Tag = i;

                    button.Text = symbols[i].img;

                    flowLayoutPanel_all.Controls.Add(button);

                    symbolButtons.Add(button);
                }

            }
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

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0); //because the thread in AlwaysTopMost
        }

        #endregion

        #region handleOutput
        private void Button_Click(object? sender, EventArgs e)
        {
            SetNoActivate(this.Handle);
            ShownAndInputToTextbox((Button)sender);
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
                for (int i = 0; i < symbols.Count; i++)
                {
                    symbolButtons[i].Visible = true;
                }
            }
            else
            {
                //Stopwatch sw = Stopwatch.StartNew();

                for (int i = 0; i < symbols.Count; i++)
                {
                    if (symbols[i].name.Contains(text))
                    {
                        symbolButtons[i].Visible = true;
                    }
                    else
                    {
                        symbolButtons[i].Visible = false;
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
            if(e.KeyCode == Keys.Enter || e.KeyCode == Keys.Escape)
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

