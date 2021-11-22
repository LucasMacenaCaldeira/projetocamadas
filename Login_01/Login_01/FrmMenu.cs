using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Login_01
{
    public partial class FrmMenu : Form
    {
        public FrmMenu()
        {
            InitializeComponent();
        }

        Login objLogin = new Login();

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void usuárioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCadastrar cad = new FrmCadastrar();
            cad.ShowDialog();
        }

        private void FrmMenu_Load(object sender, EventArgs e)
        {
            lblBemVindo.Text = "Seja Bem Vindo "+objLogin.UsuarioLogado()+"";

            if(objLogin.TipoUsuario() != "Administrador")
            {
                usuárioToolStripMenuItem.Enabled = false;
            }
        }
    }
}
