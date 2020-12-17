using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FileTools.UI
{
    public partial class EncontrarDuplicados : Form
    {
        public EncontrarDuplicados()
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
            try
            {
                FileTool fileTool = new FileTool();
                var items = fileTool.FindDuplicated(textBox1.Text);
                listBox1.DataSource = items;
                MessageBox.Show("Tarefa concluída");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
