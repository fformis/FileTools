using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FileTools.UI
{
    public partial class MesclarPastas : Form
    {
        public MesclarPastas()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            var result = folderBrowserDialog1.ShowDialog();
            textBox1.Text = folderBrowserDialog1.SelectedPath;
        }

        private void button2_Click(object sender, EventArgs e)
        {

            var result = folderBrowserDialog2.ShowDialog();
            textBox2.Text = folderBrowserDialog2.SelectedPath;
        }

        private void button3_Click(object sender, EventArgs e)
        {

            var result = folderBrowserDialog3.ShowDialog();
            textBox3.Text = folderBrowserDialog3.SelectedPath;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                FileTool fileTool = new FileTool();
                fileTool.MergeFolders(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text);
                MessageBox.Show("Tarefa concluída");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
