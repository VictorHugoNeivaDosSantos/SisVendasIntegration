using ProjetoVendas.Model;
using System.Threading.Tasks;

namespace ProjetoVendas.Repositories.Interface
{
    public interface IRepositoryEndereco
    {
        Task<long> AddEnderecoAsync(Endereco endereco);
    }
}