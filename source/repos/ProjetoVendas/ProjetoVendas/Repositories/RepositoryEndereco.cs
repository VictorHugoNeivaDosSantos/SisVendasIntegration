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

        public async Task<string> DeletarEnderecoAsync(long id)
        {
            var endereco = _context.Endereco.FirstOrDefault(f => f.Id == id) ?? throw new Exception("Endereço não encontrado");
            _context.Endereco.Remove(endereco);
            await _context.SaveChangesAsync();
            return "Endereco deletado com sucesso!";
        }
    }
}
