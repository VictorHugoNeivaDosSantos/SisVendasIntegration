using ProjetoVendas.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjetoVendas.Repositories
{
    public interface IRepositoryPessoa
    {
        Task<Pessoa> AddPessoaAsync(Pessoa pessoa);
        Task<Pessoa> GetPessoaAsync(long id);
        Task DeletarPessoaIdAsync(long id);
        Task<List<Pessoa>> GetListInlcudeAsync();
        Task<List<Pessoa>> GetListAsync();
        Task<long> SelectIdEnderecoPessoaAsync(long id);
        Task EditarPessoaAsync(Pessoa pessoa);

    }
}