using ProjetoVendas.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjetoVendas.Repositories
{
    public interface IRepositoryPessoa
    {
        Task<Pessoa> AddPessoa(Pessoa pessoa);
        Task<Pessoa> GetPessoa(long id);
        Task<string> DeletarPessoaIdAsync(long id);
        Task<List<Pessoa>> GetListInlcudeAsync();
        Task<List<Pessoa>> GetListAsync();
        Task<long> SelectIdEnderecoPessoaAsync(long id);
    }
}