using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProjetoVendas.Dto;
using ProjetoVendas.Model;
using ProjetoVendas.Services;
using ProjetoVendas.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoVendas.Controllers
{
    [ApiController]
    [Route("sisvendas")]
    public class PessoaController : ControllerBase
    {
        private readonly IServicePessoa _service;

        public PessoaController(IServicePessoa service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<string> AddPessoaAsync([FromBody] PessoaDto pessoa)
        {
          return  await _service.AddPessoaAsync(pessoa);
        }

        [HttpGet("{id}")]
        public async Task<PessoaDto> GetPessoaAsync([FromRoute] long id)
        {
            return await _service.GetPessoaDtoAsync(id);
        }

        [HttpGet("lista")]
        public async Task<List<PessoaDto>> GetListPessoaAsync()
        {
            return await _service.GetPessoaListAsync();
        }

        [HttpGet("listaEndereco")]
        public async Task<List<PessoaEnderecoDto>> GetListPessoaEnderecoAsync()
        {
            return await _service.GetPessoaListIncludeAsync();
        }
        [HttpDelete("{id}")]

        public async Task<string> DeletarPessoa([FromRoute]long id)
        {
            return await _service.DeletarPessoaAsync(id);
        }

        [HttpPut("{id}")]

        public async Task AtualizarPessoaAsync([FromRoute]long id,[FromBody] PessoaDto pessoa)
        {
            await _service.EditarPessoaAsync(id, pessoa);
        }


    }
}
