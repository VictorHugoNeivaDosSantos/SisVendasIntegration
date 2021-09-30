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

        public async Task<string> AddPessoaAsync(PessoaDto pessoaDto)
        {
            var pessoa = new Pessoa();
            _mapper.Map(pessoaDto, pessoa);

            if (pessoa.Cep.Length == 8)
            {
                var endereco = await _cep.GetEnderecoAsync(pessoa.Cep);
                pessoa.EnderecoId = await _repositoryEndereco.AddEnderecoAsync(endereco);
            }
            else
            {
                return "Cliente sem endereco cadastrado!";
            }

            await _repositoryPessoa.AddPessoaAsync(pessoa);
            return "Cliente cadastrado!";
        }

        public async Task<PessoaDto> GetPessoaDtoAsync(long id)
        {
            PessoaDto Dto = new PessoaDto();
            var pessoa = await _repositoryPessoa.GetPessoaAsync(id);
            _mapper.Map(pessoa, Dto);
            return Dto;
        }

        public async Task<List<PessoaDto>> GetPessoaListAsync()
        {
            var listaPessoa = await _repositoryPessoa.GetListAsync();
            List<PessoaDto> listaPessoaDto = new List<PessoaDto>();
            _mapper.Map(listaPessoa, listaPessoaDto);
            return listaPessoaDto;
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
                await _repositoryEndereco.DeletarEnderecoAsync(idEndereco);
            }
            //await _repositoryPessoa.DeletarPessoaIdAsync(id);

            return "Pessoa deletada com sucesso";
        }

        public async Task EditarPessoaAsync(long id, PessoaDto pessoaDto)
        {
            var pessoa = await _repositoryPessoa.GetPessoaAsync(id);         
            _mapper.Map(pessoaDto, pessoa);
            var endereco = await _repositoryEndereco.GetEnderecoAsync(pessoa.EnderecoId);
            var enderecoNew = await _cep.GetEnderecoAsync(pessoa.Cep);
            endereco.Cep = enderecoNew.Cep;
            endereco.Bairro = enderecoNew.Bairro;
            endereco.Cidade = enderecoNew.Cidade;
            endereco.Rua = enderecoNew.Rua;
            await _repositoryEndereco.EditarEnderecoAsync(endereco);        
            await _repositoryPessoa.EditarPessoaAsync(pessoa);

           
        }

    }
}
