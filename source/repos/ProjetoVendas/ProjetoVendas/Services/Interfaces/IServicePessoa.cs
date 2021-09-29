using ProjetoVendas.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjetoVendas.Services.Interface
{
    public interface IServicePessoa
    {
        Task<long> AddPessoaAsync(PessoaDto pessoaDto);
        Task<string> DeletarPessoaAsync(long id);
        Task<PessoaDto> GetPessoaDtoAsync(long id);
        Task<List<PessoaDto>> GetPessoaListAsync();
        Task<List<PessoaEnderecoDto>> GetPessoaListIncludeAsync();
    }
}