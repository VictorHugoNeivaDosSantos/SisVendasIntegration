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
    }
}
