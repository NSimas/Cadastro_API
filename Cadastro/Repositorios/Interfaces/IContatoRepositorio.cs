using Cadastro.Models;

namespace Cadastro.Repositorios.Interfaces
{
    public interface IContatoRepositorio
    {
        Task<List<ContatoModel>> BuscarTodosContatos();
        Task<ContatoModel> BuscarId(int id);
        Task<ContatoModel> Adicionar(ContatoModel contatoModel);
        Task<ContatoModel> Atualizar(ContatoModel contatoModel, int id);
        Task<bool> Deletar(int id);
    }
}
