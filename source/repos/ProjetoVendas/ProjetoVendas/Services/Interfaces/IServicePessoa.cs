using ProjetoVendas.Dto;
using ProjetoVendas.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjetoVendas.Services.Interface
{
    public interface IServicePessoa
    {
        Task<string> AddPessoaAsync(PessoaDto pessoaDto);
        Task<string> DeletarPessoaAsync(long id);
        Task<PessoaDto> GetPessoaDtoAsync(long id);
        Task<List<PessoaDto>> GetPessoaListAsync();
        Task<List<PessoaEnderecoDto>> GetPessoaListIncludeAsync();
        Task EditarPessoaAsync(long id, PessoaDto pessoa);
    }
}