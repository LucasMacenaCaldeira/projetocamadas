using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetoEmCamadas.Code.DTO;
using ProjetoEmCamadas.Code.DAL;
using System.Data;

namespace ProjetoEmCamadas.Code.BLL
{
    class empregoBLL
    {
        Conexao conexao = new Conexao();
        string tabela = "tbl_emprego";
        public void inserir(empregoDTO empdto)
        {
            string inserir = $"insert into {tabela} values(null, '{empdto.Nome}', '{empdto.Vaga}')";
            conexao.ExecutarComando(inserir);
        }

        public void editar(empregoDTO empdto)
        {

        }

        public void excluir(empregoDTO empdto)
        {
            string excluir = $"delete from {tabela} where id = '{empdto.Id}';";
            conexao.ExecutarComando(excluir);
        }

        public DataTable  listar()
        {
            string sql = $"select * from {tabela} order by id;";
            return conexao.ExecutarConsulta(sql);
        }

       public void Editar(empregoDTO empdto)
        {
            string alterar = $"update {tabela} set nome = '{empdto.Nome}', vaga = '{empdto.Vaga}' where id = '{empdto.Id}';";
            conexao.ExecutarComando(alterar);
        }

        internal void excluir()
        {
            throw new NotImplementedException();
        }
    }
}
