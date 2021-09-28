using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoVendas.Model
{
    public class Endereco
    {
        
        public long Id { get; set; }
        [JsonProperty("code")]
        public string Cep { get; set; }
        [JsonProperty("state")]
        public string UF { get; set; }
        [JsonProperty("city")]
        public string Cidade { get; set; }
        [JsonProperty("district")]
        public string Bairro { get; set; }
        [JsonProperty("address")]
        public string Rua { get; set; }

    }
}
