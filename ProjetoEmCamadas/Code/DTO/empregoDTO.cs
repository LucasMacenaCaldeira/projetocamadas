using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoEmCamadas.Code.DTO
{
    class empregoDTO
    {
        private int _id;
        private string _nome;
        private string _vaga;

        public int Id { get => _id; set => _id = value; }
        public string Nome { get => _nome; set => _nome = value; }
        public string Vaga { get => _vaga; set => _vaga = value; }
    }
}
