using AutoMapper;
using ProjetoVendas.Dto;
using ProjetoVendas.Integrations;
using ProjetoVendas.Integrations.Interface;
using ProjetoVendas.Model;
using ProjetoVendas.Repositories;
using ProjetoVendas.Repositories.Interface;
using ProjetoVendas.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoVendas.Services
{
    public class ServicePessoa : IServicePessoa
    {
        private readonly IRepositoryPessoa _repositoryPessoa;
        private readonly IRepositoryEndereco _repositoryEndereco;
        private readonly ICep _cep;
        private readonly IMapper _mapper;

        public ServicePessoa(IRepositoryEndereco repositoryEndereco, IRepositoryPessoa repositoryPessoa, ICep cep, IMapper mapper)
        {
            _repositoryEndereco = repositoryEndereco;
            _repositoryPessoa = repositoryPessoa;
            _cep = cep;
            _mapper = mapper;
        }

        public async Task<long> AddPessoaAsync(PessoaDto pessoaDto)
        {
            var pessoa = new Pessoa();
            _mapper.Map(pessoaDto, pessoa);

            if (pessoa.Cep != null)
            {
                var endereco = await _cep.GetEnderecoAsync(pessoa.Cep);
                pessoa.EnderecoId = await _repositoryEndereco.AddEnderecoAsync(endereco);
            }

            await _repositoryPessoa.AddPessoa(pessoa);
            return pessoa.Id;
        }

        public async Task<PessoaDto> GetPessoaDtoAsync(long id)
        {
            PessoaDto dto = new PessoaDto();

            var pessoa = _repositoryPessoa.GetPessoa(id);
            await _mapper.Map(dto, pessoa);
            return dto;

        }

        public async Task<List<PessoaDto>> GetPessoaListAsync()
        {
            List<PessoaDto> list = new List<PessoaDto>();
            var pessoa = await _repositoryPessoa.GetListAsync();
            _mapper.Map(list, pessoa);
            return list;
        }

        public async Task<List<PessoaEnderecoDto>> GetPessoaListIncludeAsync()
        {
            List<PessoaEnderecoDto> list = new List<PessoaEnderecoDto>();
            var pessoa = await _repositoryPessoa.GetListInlcudeAsync();
            _mapper.Map(pessoa, list);
            return list;
        }

        public async Task<string> DeletarPessoaAsync(long id)
        {
             var idEndereco = await _repositoryPessoa.SelectIdEnderecoPessoaAsync(id);
            if (idEndereco != 0)
            {
               string t = await _repositoryEndereco.DeletarEnderecoAsync(idEndereco);
            }
            return await _repositoryPessoa.DeletarPessoaIdAsync(id);
        }

    }
}
