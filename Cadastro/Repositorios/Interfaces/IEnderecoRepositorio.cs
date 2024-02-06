using Cadastro.Models;

namespace Cadastro.Repositorios.Interfaces
{
    public interface IEnderecoRepositorio
    {
        Task<List<EnderecoModel>> BuscarTodosEnderecos();
        Task<EnderecoModel> BuscarId(int id);
        Task<EnderecoModel> Adicionar(EnderecoModel enderecoModel);
        Task<EnderecoModel> Atualizar(EnderecoModel enderecoModel, int id);
        Task<bool> Deletar(int id);
    }
}
