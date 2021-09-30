using ProjetoVendas.Model;
using System.Threading.Tasks;

namespace ProjetoVendas.Repositories.Interface
{
    public interface IRepositoryEndereco
    {
        Task<long> AddEnderecoAsync(Endereco endereco);
        Task DeletarEnderecoAsync(long id);
        Task EditarEnderecoAsync(Endereco endereco);
        Task<Endereco> GetEnderecoAsync(long id);
            
    }
}