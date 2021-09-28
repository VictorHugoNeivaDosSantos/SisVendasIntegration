using ProjetoVendas.Model;
using System.Threading.Tasks;

namespace ProjetoVendas.Repositories
{
    public interface IRepositoryPessoa
    {
        Task<Pessoa> AddPessoa(Pessoa pessoa);
        Task<Pessoa> GetPessoa(long id);
    }
}