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
    public partial class FrmCadastrar : Form
    {
        public FrmCadastrar()
        {
            InitializeComponent();
        }
        ConexaoBD bd = new ConexaoBD();
        string sql;
        Login objlogin = new Login();

        public void limparerro()
        {
            txtSenha.Clear();
            txtConfirma.Clear();
        }
        public void limpar()
        {
            txtCodigo.Clear();
            txtNome.Clear();
            txtUsuario.Clear();
            txtSenha.Clear();
            txtConfirma.Clear();
            cbxTipo.SelectedIndex = -1;
            cbxStatus.SelectedIndex = -1;
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            if (txtSenha.Text != txtConfirma.Text)
            {
                MessageBox.Show("Senhas diferentes!!...", "Erro Senha", MessageBoxButtons.OK, MessageBoxIcon.Error);
                limpar();
            }
            else if(txtNome.Text == "" && txtUsuario.Text == "" && txtSenha.Text == "")
            {
                MessageBox.Show("Você não inseriu todos os dados \n Por favor insira os dados...","Erro com as informações",MessageBoxButtons.OK,MessageBoxIcon.Stop);
                limpar();
            }
            else

            {

                sql = string.Format("insert into usuario values(null,'{0}','{1}','{2}','{3}','{4}')", txtNome.Text, txtUsuario.Text, txtSenha.Text, cbxTipo.Text, cbxStatus.Text);
                bd.AlterarDados(sql);
                MessageBox.Show("Cadastro do Usuário efetuado com sucesso!", "Cadastro de Usuário", MessageBoxButtons.OK, MessageBoxIcon.Information);
                limpar();
            }
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            sql = string.Format("delete from usuario where codigo = '{0}'", txtCodigo.Text);
            bd.AlterarDados(sql);
            MessageBox.Show("Usuário excluido com sucesso!", "Partido", MessageBoxButtons.OK, MessageBoxIcon.Information);
            limpar();
            
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            sql = string.Format("update usuario set nome = '{0}',usuario = '{1}',senha = '{2}',tipo = '{3}',status_usu = '{4}' where Codigo = '{5}' ", txtNome.Text, txtUsuario.Text, txtSenha.Text, cbxTipo.Text, cbxStatus.Text,txtCodigo.Text);
            bd.AlterarDados(sql);
            MessageBox.Show("Dados do Usuário alterado com sucesso!", "Usuário", MessageBoxButtons.OK, MessageBoxIcon.Information);
            limpar();

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            sql = string.Format("select * from usuario where usuario = '{0}' and senha = '{1}'", txtUsuario.Text, txtSenha.Text);
            dt = bd.ConsultarDados(sql);

            if (dt.Rows.Count > 0)
            {
                txtCodigo.Text = dt.Rows[0]["codigo"].ToString();
                txtNome.Text = dt.Rows[0]["nome"].ToString();
                cbxStatus.Text = dt.Rows[0]["status_usu"].ToString();
                cbxTipo.Text = dt.Rows[0]["tipo"].ToString();
                limparerro();

            }
            else
            {

                MessageBox.Show("Usuário ou senha incorreto \n Por favor tente novamente!!");

            }
        }
    }
}

