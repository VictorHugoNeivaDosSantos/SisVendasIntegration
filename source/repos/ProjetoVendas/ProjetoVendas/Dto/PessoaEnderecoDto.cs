using ProjetoVendas.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoVendas.Dto
{
    public class PessoaEnderecoDto
    { 
        public string Nome { get; set; }
        public string Cep { get; set; }
        public string Cidade { get; set; }
    }
}
