using ProjetoVendas.Model;
using System.Threading.Tasks;

namespace ProjetoVendas.Integrations.Interface
{
    public interface ICep
    {
        Task<Endereco> GetEnderecoAsync(string cep);
    }
}