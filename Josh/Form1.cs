using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Josh {
    public partial class Form1 : Form {
        string master = "";
        public Form1() {
            InitializeComponent();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData) {
            if (keyData == (Keys.Right)) {
                button1.PerformClick();
                return true;
            }

            if (keyData == (Keys.Left)) {
                button2.PerformClick();
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void button1_Click(object sender, EventArgs e) {
            //imageList1.Images.Add(Image.FromFile(@"C:\LOGO.png"));
            try {
                FileBox.SelectedIndex = FileBox.SelectedIndex + 1;
            } catch {

            }
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e) {
            DialogResult result = browser.ShowDialog();
            if (result == DialogResult.OK) {
                master = browser.SelectedPath;
                string[] m = Directory.GetDirectories(master);

                foreach (var v in m) {
                    MainList.Items.Add(v.TrimEnd(Path.DirectorySeparatorChar).Split(Path.DirectorySeparatorChar).Last());
                    // MainList.Items.Add(v);
                }
            }
        }

        private void MainList_DoubleClick(object sender, EventArgs e) {
            /*FileBox.Items.Clear();
            imageList1.Images.Clear();
            string[] d = Directory.GetFiles(master + @"\" +  MainList.SelectedItems[0].Text);

            foreach (var v in d) {
                FileBox.Items.Add(v);
                imageList1.Images.Add(Image.FromFile(v));
            }

            FileBox.SelectedIndex = 0;*/

            //comboBox1.Items.Add("worked");
        }

        private void FileBox_SelectedIndexChanged(object sender, EventArgs e) {
            MainPic.Image = Image.FromFile(FileBox.Text);
        }

        private void button2_Click(object sender, EventArgs e) {
            if (FileBox.SelectedIndex != 0) {
                FileBox.SelectedIndex = FileBox.SelectedIndex - 1;
            }
        }

        private void MainList_SelectedIndexChanged(object sender, EventArgs e) {
            FileBox.Items.Clear();
            imageList1.Images.Clear();
            string[] d = Directory.GetFiles(master + @"\" +  MainList.SelectedItems[0].Text);

            foreach (var v in d) {
                FileBox.Items.Add(v);
                imageList1.Images.Add(Image.FromFile(v));
            }

            FileBox.SelectedIndex = 0;
        }
    }
}