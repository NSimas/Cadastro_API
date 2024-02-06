using Cadastro.Models;

namespace Cadastro.Repositorios.Interfaces
{
    public interface IPessoaFisicaRepositorio
    {
        Task<List<PessoaFisicaModel>> BuscarTodasPessoas();
        Task<PessoaFisicaModel> BuscarId(int id);
        Task<PessoaFisicaModel> Adicionar(PessoaFisicaModel pessoaFisica);
        Task<PessoaFisicaModel> Atualizar(PessoaFisicaModel pessoaFisica, int id);
        Task<bool> Deletar(int id);
    }
}
