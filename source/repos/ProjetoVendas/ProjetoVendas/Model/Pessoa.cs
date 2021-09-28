using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoVendas.Model
{
    [Table("pessoa")]
    public class Pessoa
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public string Cep { get; set; }
        public Endereco Endereco { get; set; }
        public long EnderecoId { get; set; }
    }
}
