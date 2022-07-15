namespace SymbolPicker
{
    public partial class Form1 : Form
    {
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

        List<Symbol> symbols = new List<Symbol>();
        string path = Application.StartupPath + @"\symbols.txt";
        public Form1()
        {
            InitializeComponent();


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

            LayoutItems("");

        }

        public void LayoutItems(string searchString)
        {

            for (int i = 0; i < symbols.Count; i++)
            {
                if (symbols[i].name.StartsWith(searchString))
                {
                    Button button = new Button();
                    button.Font = new System.Drawing.Font("Segoe UI Variable Display", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
                    button.Size = new System.Drawing.Size(60, 60);
                    button.Text = symbols[i].img;
                    button.KeyDown += Button_KeyDown;
                    button.Click += Button_Click;
                    button.Tag = i;
                    flowLayoutPanel.Controls.Add(button);

                }

            }
        }

        private void Button_Click(object? sender, EventArgs e)
        {
            Copy(sender);
        }

        private void Button_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Hide();
                notifyIcon.Visible = true;
                

            }
            else if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Space)
            {
                Copy(sender);
            }
        }

        private void Copy(Object sender)
        {

            Clipboard.SetText(((Button)sender).Text);
            this.Hide();
            notifyIcon.Visible = true;


        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Hide();
                notifyIcon.Visible = true;

            }
        }

        private void textBox_TextChanged(object sender, EventArgs e)
        {
            flowLayoutPanel.Controls.Clear();
            LayoutItems(textBox.Text);

        }

        private void notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Show();
            WindowState = FormWindowState.Normal;
            notifyIcon.Visible = false;
        }

        private void textBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Hide();
                notifyIcon.Visible = true;

            }
            else if (e.KeyCode == Keys.Down)
            {
                SendKeys.Send("{TAB}");
            }
        }
    }


}

