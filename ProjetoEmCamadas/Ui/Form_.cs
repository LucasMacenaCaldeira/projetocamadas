using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProjetoEmCamadas.Code.DTO;
using ProjetoEmCamadas.Code.BLL;

namespace ProjetoEmCamadas
{
    public partial class Form_Linkedin : Form
    {
        empregoBLL empbll = new empregoBLL();
        empregoDTO empdto = new empregoDTO();
        public Form_Linkedin()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dgv_nomes.DataSource = empbll.listar();
        }

        private void btn_cadastrar_Click(object sender, EventArgs e)
        {
            empdto.Nome = txt_nome.Text;
            empdto.Vaga = txt_vaga.Text;

            empbll.inserir(empdto);

            MessageBox.Show("Cadastrado com sucesso!", "Individuo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            txt_id.Clear();
            txt_nome.Clear();
            txt_vaga.Clear();
        }

        private void btn_editar_Click(object sender, EventArgs e)
        {
            empdto.Id = int.Parse(txt_id.Text);
            empdto.Nome = txt_nome.Text;
            empdto.Vaga = txt_vaga.Text;

            empbll.editar(empdto);

            MessageBox.Show("Alterado com sucesso", "Individuo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            empbll.listar();

            txt_id.Clear();
            txt_nome.Clear();
            txt_vaga.Clear();


        }

        private void btn_excluir_Click(object sender, EventArgs e)
        {
    
            empdto.Id = int.Parse(txt_id.Text);
            empdto.Nome = txt_nome.Text;
            empdto.Vaga = txt_vaga.Text;
    
            empbll.excluir(empdto);

            MessageBox.Show("Excluido com sucesso!", "Individuo", MessageBoxButtons.OK, MessageBoxIcon.Information);

               empbll.excluir();

            txt_id.Clear();
            txt_nome.Clear();
            txt_vaga.Clear();
        }

        private void dgv_nomes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txt_id.Text = dgv_nomes.Rows[e.RowIndex].Cells[0].Value.ToString();
            txt_nome.Text = dgv_nomes.Rows[e.RowIndex].Cells[1].Value.ToString();
            txt_vaga.Text = dgv_nomes.Rows[e.RowIndex].Cells[2].Value.ToString();


        }
    }
}
