using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileTools.UI
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
            duplicados.Click += Duplicados_Click;
            mesclar.Click += Mesclar_Click;
            renomearTodos.Click += RenomearTodos_Click;
            renomearGuid.Click += RenomearGuid_Click;
        }

        private void RenomearGuid_Click(object sender, EventArgs e)
        {
            RenomearTodosGuid renomearTodosGuid = new RenomearTodosGuid();
            renomearTodosGuid.ShowDialog();
        }

        private void RenomearTodos_Click(object sender, EventArgs e)
        {
            RenomearTodos renomearTodos = new RenomearTodos();
            renomearTodos.ShowDialog();
        }

        private void Mesclar_Click(object sender, EventArgs e)
        {
            MesclarPastas mesclarPastas = new MesclarPastas();
            mesclarPastas.ShowDialog();
        }

        private void Duplicados_Click(object sender, EventArgs e)
        {
            EncontrarDuplicados encontrarDuplicados = new EncontrarDuplicados();
            encontrarDuplicados.ShowDialog();
        }
    }
}
