using Microsoft.EntityFrameworkCore;
using ProjetoVendas.Context;
using ProjetoVendas.Dto;
using ProjetoVendas.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoVendas.Repositories
{
    public class RepositoryPessoa : IRepositoryPessoa
    {
        private readonly ContextDB _context;

        public RepositoryPessoa(ContextDB context)
        {
            _context = context;
        }

        public async Task<Pessoa> AddPessoa(Pessoa pessoa)
        {
            _context.Pessoa.Add(pessoa);
            await _context.SaveChangesAsync();
            return pessoa;
        }

        public async Task<Pessoa> GetPessoa(long id)
        {
            return await _context.Pessoa.Include(i => i.Endereco).FirstOrDefaultAsync(f => f.Id == id);

        }
        public async Task<List<Pessoa>> GetListAsync()
        {
           return await _context.Pessoa.ToListAsync();
        }

        public async Task<List<Pessoa>> GetListInlcudeAsync()
        {
            return await _context.Pessoa.Include(i => i.Endereco).ToListAsync();
        }

        public async Task<string> DeletarPessoaIdAsync(long id)
        {
            var pessoa = await _context.Pessoa.FirstOrDefaultAsync(f => f.Id == id) ?? throw new Exception("Pessoa não encontrada");
            _context.Pessoa.Remove(pessoa);
            await _context.SaveChangesAsync();
            return "Pessoa excluída";
        }

        public async Task<long> SelectIdEnderecoPessoaAsync(long id)
        {
            //var pessoa = await _context.Pessoa.FirstOrDefaultAsync(f => f.Id == id);
            //return pessoa.EnderecoId;
            return await _context.Pessoa.Where(w => w.Id == id).Select(s => s.EnderecoId).FirstOrDefaultAsync();
        }
    }
}
