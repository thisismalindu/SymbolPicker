using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SymbolPicker
{
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();
        }
        #region load/save
        private void Settings_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult b = MessageBox.Show("Warn: Your settings might not be saved. Click \"Yes\" to save settings, click \"No\" to discard changes, click \"Cancle\" to return", "Warning: ", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
            if (b == DialogResult.Yes)
            {
                SaveSettings();
            }
            else if (b == DialogResult.Cancel)
            {
                e.Cancel = true;
                return;
            }
            else
            {
                //continue
            }

            this.Hide();
            e.Cancel = true;
        }
        private void button_save_Click(object sender, EventArgs e)
        {
            SaveSettings();
        }

        private void Settings_Load(object sender, EventArgs e)
        {
            LoadSettings();
        }
        private static List<(Type objType, string propertyName, Type propertyType)> listToSave =
            new List<(Type, string, Type)>() {
            (typeof(TrackBar), "Value",  typeof(int)),
            (typeof(CheckBox), "Checked",  typeof(bool)),
            (typeof(TextBox), "Text",  typeof(string)),
            };

        private const string SettingsFile = "settings.json";

        public void LoadSettings()
        {
            if (!File.Exists(SettingsFile)) return; // maybe the first time

            string json;
            try
            {
                json = File.ReadAllText(SettingsFile);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error reading settings: {ex.Message}. Ignoring settings...");
                return;
            }
            Dictionary<string, object> settings;
            try
            {
                settings = JsonSerializer.Deserialize<Dictionary<string, object>>(json);
                if (settings == null) return;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error parsing settings: {ex.Message}. Ignoring settings...");
                return;
            }

            foreach (KeyValuePair<string, object> a in settings)
            {
                Control ctrl = this.Controls.Find(a.Key, true)[0];
                if (ctrl != null)
                {
                    foreach ((Type objType, string propertyName, Type propertyType) item in listToSave)
                    {
                        if (ctrl.GetType() == item.objType)
                        {
                        FLAG_LOAD_SINGLE_RETRY:
                            var property = ctrl.GetType().GetProperty(item.propertyName);
                            if (property != null)
                            {
                                try
                                {
                                    //MessageBox.Show(a.Value.ToString());
                                    object convertedValue = Convert.ChangeType(a.Value.ToString(), item.propertyType); //a.Value.ToString() must have ToString, or it will show that the class must implement IConvertable
                                    property.SetValue(ctrl, convertedValue);
                                }
                                catch (Exception ex)
                                {
                                    DialogResult r = MessageBox.Show($"Error parsing settings (setValue): {ex.Message}. Click \"Cancle\" To retry, click \"OK\" to discard changes");
                                    if (r == DialogResult.Cancel)
                                    {
                                        goto FLAG_LOAD_SINGLE_RETRY;
                                    }
                                }
                            }
                            else
                            {
                                MessageBox.Show($"Debug message: LoadSettings property != null");
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show($"Debug message: Controls.Find(a.Key, true)[0]; if (ctrl != null)");
                }
            }
        }

        public void SaveSettings()
        {
        FLAG_SAVE_RETRY:
            var settings = new Dictionary<string, object>();

            foreach (Control winFormCtrl in EnumAllControls(this))
            {
                foreach (var item in listToSave)
                {
                    if (winFormCtrl.GetType() == item.objType)
                    {
                        var property = winFormCtrl.GetType().GetProperty(item.propertyName);
                        if (property != null)
                        {
                            object o = property.GetValue(winFormCtrl);
                            if (o != null) settings.Add(winFormCtrl.Name, o);
                            // MessageBox.Show(o.ToString());
                        }
                        else
                        {
                            MessageBox.Show($"Debug message: SaveSettings property != null");
                        }
                    }
                }
            }

            try
            {
                string json = JsonSerializer.Serialize(settings, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(SettingsFile, json);
            }
            catch (Exception ex)
            {
                DialogResult r = MessageBox.Show($"Error saving settings (parse): {ex.Message}. Click \"Cancle\" To retry, click \"OK\" to discard changes");
                if (r == DialogResult.Cancel)
                {
                    goto FLAG_SAVE_RETRY;
                }
            }



            //restart
            System.Diagnostics.Process.Start(Application.ExecutablePath);
            Thread.Sleep(100);
            //Environment.Exit(0);
            Program.MainForm.EndProgram();
        }

        public List<Control> EnumAllControls(Control parent)
        {
            List<Control> controls = new List<Control>();

            foreach (Control ctrl in parent.Controls)
            {
                controls.Add(ctrl); // 添加当前控件

                // 处理 TabControl 特殊情况
                if (ctrl is TabControl tabControl)
                {
                    foreach (TabPage page in tabControl.TabPages)
                    {
                        controls.AddRange(EnumAllControls(page)); // 递归添加 TabPage 内的控件
                    }
                }
                else
                {
                    controls.AddRange(EnumAllControls(ctrl)); // 递归添加普通子控件
                }
            }

            return controls;
        }

        #region old
        //Properties.Settings.Default is static, so it can't work


        //private void LoadSettings()
        //{
        //    foreach (Control winFormCtrl in this.Controls)
        //    {
        //        foreach (var item in listToSave)
        //        {
        //            if (winFormCtrl.GetType() == item.objType)
        //            {
        //                var property = winFormCtrl.GetType().GetProperty(item.propertyName); //reflection
        //                if (property != null)
        //                {
        //                    #region debug check
        //                    if (property.PropertyType != item.propertyType)
        //                    {
        //                        MessageBox.Show("debug error: property.PropertyType != item.propertyType");
        //                        Environment.Exit(0);
        //                    }
        //                    #endregion

        //                    if (Properties.Settings.Default[winFormCtrl.Name] != null)
        //                    {
        //                        property.SetValue(winFormCtrl, Properties.Settings.Default[winFormCtrl.Name]);
        //                    }
        //                }
        //            }
        //        }
        //    }
        //}
        //private void SaveSettings()
        //{
        //    foreach (Control winFormCtrl in this.Controls)
        //    {
        //        foreach (var item in listToSave)
        //        {
        //            if (winFormCtrl.GetType() == item.objType)
        //            {
        //                var property = winFormCtrl.GetType().GetProperty(item.propertyName); //reflection
        //                if (property != null)
        //                {
        //                    #region debug check
        //                    if (property.PropertyType != item.propertyType)
        //                    {
        //                        MessageBox.Show("debug error: property.PropertyType != item.propertyType - save");
        //                        Environment.Exit(0);
        //                    }
        //                    #endregion

        //                    Properties.Settings.Default[winFormCtrl.Name] = property.GetValue(winFormCtrl, null);


        //                }
        //            }
        //        }
        //    }


        //    Properties.Settings.Default.Save();
        //}
        #endregion

        #endregion

        #region transparency
        private void trackBar_intrans_ValueChanged(object sender, EventArgs e)
        {
            label_intrans_value.Text = trackBar_intrans.Value.ToString();
        }

        #endregion

        #region hotkey
        private void textBox_hotkey_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetterOrDigit(e.KeyChar))
            {
                //return (Keys)Enum.Parse(typeof(Keys), c.ToString().ToUpper());
                textBox_hotkey.Text = e.KeyChar.ToString().ToUpper();
            }
        }
        #endregion

    }
}
