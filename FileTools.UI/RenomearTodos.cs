using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FileTools.UI
{
    public partial class RenomearTodos : Form
    {
        public RenomearTodos()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var result = folderBrowserDialog1.ShowDialog();
            textBox3.Text = folderBrowserDialog1.SelectedPath;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                FileTool fileTool = new FileTool();
                fileTool.RenameAll(textBox3.Text, textBox4.Text);
                MessageBox.Show("Tarefa concluída");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
