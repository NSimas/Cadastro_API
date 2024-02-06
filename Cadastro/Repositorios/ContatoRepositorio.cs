using Cadastro.Data;
using Cadastro.Models;
using Cadastro.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Cadastro.Repositorios
{
    public class ContatoRepositorio : IContatoRepositorio
    {
        private readonly CadastroDbContext _dbContext;

        public ContatoRepositorio(CadastroDbContext cadastroDbContext)
        {
            _dbContext = cadastroDbContext;
        }

        public async Task<List<ContatoModel>> BuscarTodosContatos()
        {
            return await _dbContext.Contato.Include(x => x.pessoa).ToListAsync();
        }

        public async Task<ContatoModel> BuscarId(int id)
        {
            return await _dbContext.Contato.Include(x => x.pessoa).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<ContatoModel> Adicionar(ContatoModel contato)
        {
            await _dbContext.Contato.AddAsync(contato);
            await _dbContext.SaveChangesAsync();

            return contato;
        }

        public async Task<ContatoModel> Atualizar(ContatoModel contato, int id)
        {
            ContatoModel contatoPorId = await BuscarId(id);

            if (contatoPorId == null)
            {
                throw new Exception($"Contato com o ID: {id} não foi localizado no banco de dados.");
            }

            contatoPorId.Nome = contato.Nome;
            contatoPorId.Tipo = contato.Tipo;
            contatoPorId.Contato = contato.Contato;

            _dbContext.Contato.Update(contatoPorId);
            await _dbContext.SaveChangesAsync();

            return contatoPorId;
        }

        public async Task<bool> Deletar(int id)
        {
            ContatoModel contatoPorId = await BuscarId(id);

            if (contatoPorId == null)
            {
                throw new Exception($"Contato com o ID: {id} não foi localizado no banco de dados.");
            }

            _dbContext.Contato.Remove(contatoPorId);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
