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
        public async Task<long> AddPessoaAsync([FromBody] PessoaDto pessoa)
        {
          return  await _service.AddPessoaAsync(pessoa);
        }

        [HttpGet("{id}")]
        public async Task<PessoaDto> GetPessoaAsync([FromRoute] long id)
        {
            return await _service.GetPessoaDtoAsync(id);
        }
    }
}
