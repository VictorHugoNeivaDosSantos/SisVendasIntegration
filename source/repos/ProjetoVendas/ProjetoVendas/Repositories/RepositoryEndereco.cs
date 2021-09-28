using ProjetoVendas.Context;
using ProjetoVendas.Model;
using ProjetoVendas.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoVendas.Repositories
{
    public class RepositoryEndereco : IRepositoryEndereco
    {
        private readonly ContextDB _context;

        public RepositoryEndereco(ContextDB context)
        {
            _context = context;
        }

        public async Task<long> AddEnderecoAsync(Endereco endereco)
        {
            await _context.Endereco.AddAsync(endereco);
            await _context.SaveChangesAsync();
            return endereco.Id;
        }
    }
}
