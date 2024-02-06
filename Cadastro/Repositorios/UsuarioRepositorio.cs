using Cadastro.Data;
using Cadastro.Models;
using Cadastro.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Cadastro.Repositorios
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly CadastroDbContext _dbContext;

        public UsuarioRepositorio(CadastroDbContext cadastroDbContext)
        {
            _dbContext = cadastroDbContext;
        }

        public async Task<List<UsuarioModel>> BuscarTodosUsuarios()
        {
            return await _dbContext.Usuario.ToListAsync();
        }

        public async Task<UsuarioModel> BuscarId(int id)
        {
            return await _dbContext.Usuario.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<UsuarioModel> Adicionar(UsuarioModel usuarioModel)
        {
            await _dbContext.Usuario.AddAsync(usuarioModel);
            await _dbContext.SaveChangesAsync();

            return usuarioModel;
        }

        public async Task<UsuarioModel> Atualizar(UsuarioModel usuarioModel, int id)
        {
            UsuarioModel usuarioPorId = await BuscarId(id);

            if (usuarioPorId == null)
            {
                throw new Exception($"Usuário com o ID: {id} não foi localizado no banco de dados.");
            }

            usuarioPorId.Nome = usuarioModel.Nome;
            usuarioPorId.Email = usuarioModel.Email;

            _dbContext.Usuario.Update(usuarioPorId);
            await _dbContext.SaveChangesAsync();

            return usuarioPorId;
        }



        public async Task<bool> Deletar(int id)
        {
            UsuarioModel usuarioPorId = await BuscarId(id);

            if (usuarioPorId == null)
            {
                throw new Exception($"Usuário com o ID: {id} não foi localizado no banco de dados.");
            }

            _dbContext.Usuario.Remove(usuarioPorId);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
