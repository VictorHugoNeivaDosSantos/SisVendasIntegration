using ProjetoVendas.Dto;
using ProjetoVendas.Model;
using System.Threading.Tasks;

namespace ProjetoVendas.Services.Interface
{
    public interface IServicePessoa
    {
        Task<long> AddPessoaAsync(PessoaDto pessoa);
        Task<PessoaDto> GetPessoaDtoAsync(long id);
    }
}