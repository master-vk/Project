using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Collections;

namespace TextEdi
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            command = new Command();
        }
        Command command;
        private void button1_Click(object sender, EventArgs e)
        {
            ResetTimer();
            OpenFile();
            
        }
        const int MAX_TIME = 15;
        public void OpenFile()
        {
            if (openFlDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string tempName = "";
                bool isFind = false;
                foreach (var item in openFlDialog.FileName.ToString())
                {
                    if (item == '.')
                    {
                        isFind = true;
                    }
                    if (isFind)
                    {
                        tempName += item;
                    }
                }
                if (tempName == ".rtf")
                {
                    rtbox.LoadFile(openFlDialog.FileName);
                    this.Text = openFlDialog.FileName;

                }
                else
                {
                    using (StreamReader sr = new StreamReader(File.Open(openFlDialog.FileName, FileMode.Open)))
                    {
                        rtbox.Text = sr.ReadToEnd();
                    }
                    this.Text = openFlDialog.FileName;
                }
            }
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            
                pnlMain.Width = this.Width;
                pnlMain.Height = this.Height;
                rtbox.Width = this.Width - 80;
                rtbox.Height = this.Height - 40;
                btnMenu.Height = this.Height - 40;
            if (this.WindowState != FormWindowState.Maximized)
            {
                panel1.Location = new Point(panel1.Location.X, this.Height - 250);
                btnOpen.Location = new Point(btnOpen.Location.X, this.Height - 320);
                btnSave.Location = new Point(btnSave.Location.X, this.Height - 320);
                txtSearch.Location = new Point(txtSearch.Location.X, this.Height - 320);
                btnUndo.Location = new Point(btnUndo.Location.X, this.Height - 192);
                btnRedo.Location = new Point(btnRedo.Location.X, this.Height - 192);
                btnOk.Location = new Point(btnOk.Location.X, this.Height - 122);
            }
            
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ResetTimer();
            rtbox.SelectionFont = new System.Drawing.Font(listBox1.SelectedItem.ToString(), 10);
            
            
            
        }
        
        private void btnMenu_Click(object sender, EventArgs e)
        {
            ResetTimer();
            ShowMenu();
            
        }

        public void ShowMenu()
        {
            string[] extract = (from item in FontFamily.Families
                                select item.Name).ToArray<string>();

            string[] size = new string[] { "8", "9", "10", "11", "12", "14", "16", "18", "20", "22", "24", "26", "28", "32", "48", "72" };

            this.listBox1.Items.AddRange(extract);
            this.listBox3.Items.AddRange(size);
            this.listBox2.Items.AddRange(new object[]{FontStyle.Bold.ToString(),
                FontStyle.Italic.ToString(),
                FontStyle.Regular.ToString(),
                FontStyle.Strikeout.ToString(),
                FontStyle.Underline.ToString()
            });
            btnOk.Visible = true;
            btnOpen.Visible = true;
            btnSave.Visible = true;
            panel1.Visible = true;
            txtSearch.Visible = true;
            btnUndo.Visible = true;
            btnRedo.Visible = true;
            timer1.Start();
        }

        private void btnColor_Click(object sender, EventArgs e)
        {
            ResetTimer();
            SetColor(null);
           
        }

        public void SetColor(object[] obj)
        {
            
            if(obj == null)
            {
                command.Memo(new object[] { rtbox.SelectionColor, btnColor.BackColor });
                
                if (colorDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    btnUndoColor.Visible = true;
                    btnUndoColor.BackColor = btnColor.BackColor;
                    rtbox.SelectionColor = colorDialog1.Color;
                    btnColor.BackColor = colorDialog1.Color;
                }
            }
            else
            {
                btnUndoColor.BackColor = btnColor.BackColor;
                rtbox.SelectionColor = (Color)obj[0];
                btnColor.BackColor = (Color)obj[1];
            }
            
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            ResetTimer();
            Font currentFont = rtbox.SelectionFont;
            rtbox.SelectionFont = new Font(currentFont.FontFamily,
                currentFont.Size,
                (FontStyle)Enum.Parse(typeof(FontStyle), 
                listBox2.SelectedItem.ToString()));
            
        }

        private void rtbox_TextChanged(object sender, EventArgs e)
        {
            ResetTimer();
            btnMenu_Click(sender, e);
            
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            HideFormatButtons();
        }

        private void HideFormatButtons()
        {
            timer1.Stop();
            panel1.Visible = false;
            btnOk.Visible = false;
            btnOpen.Visible = false;
            btnSave.Visible = false;
            txtSearch.Visible = false;
            btnUndo.Visible = false;
            btnRedo.Visible = false;
            if (txtSearch.Text != "Search")
            {
                
                rtbox.SelectionStart = rtbox.Find(txtSearch.Text);
                rtbox.SelectionLength = txtSearch.Text.Length;
                rtbox.SelectionBackColor = Color.White;
                txtSearch.Text = "Search";
            }
            
            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            ResetTimer();
            SaveFile();
            
        }

        public void SaveFile()
        {
            
            saveFileDialog1.Filter = "RTF files |*.rtf|All files|*.*";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string fileName = saveFileDialog1.FileName;

                rtbox.SaveFile(fileName);
            }
        }

        

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                rtbox.SelectionStart = rtbox.Find(txtSearch.Text);
                rtbox.SelectionLength = txtSearch.Text.Length;
                rtbox.SelectionBackColor = Color.Aqua;
            }
        }

        private void listBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            Font currentFont = rtbox.SelectionFont;
            rtbox.SelectionFont = new Font(currentFont.FontFamily,
                float.Parse(listBox3.SelectedItem.ToString()));            
        }

        private void btnUndo_Click(object sender, EventArgs e)
        {
            ResetTimer();
            object[] temp = command.Undo();//<------покрутить ундо последнее действие не срабатывает верно
            if (temp != null)
            {
                SetColor(temp);
            }
            else
            {
                btnUndoColor.Visible = false;
            }
            
        }

        private void btnUndo_Click_1(object sender, EventArgs e)
        {
            ResetTimer();
            rtbox.Undo();
            
        }

        private void btnRedo_Click(object sender, EventArgs e)
        {
            ResetTimer();
            rtbox.Redo();
            
        }

        private void ResetTimer()
        {
            timer1.Stop();
            _time = MAX_TIME;
            timer1.Start();
        }
        int _time = MAX_TIME;
        private void timer1_Tick(object sender, EventArgs e)
        {
            --_time;
            //btnOk.Text = _time.ToString();
            if(_time == 0)
            {
                HideFormatButtons();
            }
        }

        
    }
}
