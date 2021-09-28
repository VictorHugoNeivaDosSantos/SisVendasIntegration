using Newtonsoft.Json;
using ProjetoVendas.Integrations.Interface;
using ProjetoVendas.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ProjetoVendas.Integrations
{
    public class Cep : ICep
    {
        private readonly IHttpClientFactory _factory;

        public Cep(IHttpClientFactory factory)
        {
            _factory = factory;
        }

        public async Task<Endereco> GetEnderecoAsync(string cep)
        {
            string url = $"https://ws.apicep.com/cep/{cep}.json";
            var request = new HttpRequestMessage(HttpMethod.Get, url);
            var client = _factory.CreateClient("cep");
            var response = await client.SendAsync(request);
            string readString = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {        
                var endereco = JsonConvert.DeserializeObject<Endereco>(readString);
                return endereco;
            }
            else
            {
                throw new Exception("CEP não encontrado");
            }
        }
    }
}
