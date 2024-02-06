using Cadastro.Models;

namespace Cadastro.Repositorios.Interfaces
{
    public interface IUsuarioRepositorio
    {
        Task<List<UsuarioModel>> BuscarTodosUsuarios();
        Task<UsuarioModel> BuscarId(int id);
        Task<UsuarioModel> Adicionar(UsuarioModel usuarioModel);
        Task<UsuarioModel> Atualizar(UsuarioModel usuarioModel, int id);
        Task<bool> Deletar(int id);
    }
}
