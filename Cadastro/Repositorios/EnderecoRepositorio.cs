using Cadastro.Data;
using Cadastro.Models;
using Cadastro.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Cadastro.Repositorios
{
    public class EnderecoRepositorio : IEnderecoRepositorio
    {
        private readonly CadastroDbContext _dbContext;

        public EnderecoRepositorio(CadastroDbContext cadastroDbContext)
        {
            _dbContext = cadastroDbContext;
        }

        public async Task<List<EnderecoModel>> BuscarTodosEnderecos()
        {
            return await _dbContext.Endereco.Include(x => x.pessoa).ToListAsync();
        }

        public async Task<EnderecoModel> BuscarId(int id)
        {
            return await _dbContext.Endereco.Include(x => x.pessoa).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<EnderecoModel> Adicionar(EnderecoModel endereco)
        {
            await _dbContext.Endereco.AddAsync(endereco);
            await _dbContext.SaveChangesAsync();

            return endereco;
        }

        public async Task<EnderecoModel> Atualizar(EnderecoModel endereco, int id)
        {
            EnderecoModel enderecoPorId = await BuscarId(id);

            if (enderecoPorId == null)
            {
                throw new Exception($"Endereço com o ID: {id} não foi localizado no banco de dados.");
            }

            enderecoPorId.Logradouro = endereco.Logradouro;
            enderecoPorId.Numero = endereco.Numero;
            enderecoPorId.CEP = endereco.CEP;
            enderecoPorId.Complemento = endereco.Complemento;
            enderecoPorId.Cidade = endereco.Cidade;
            enderecoPorId.Estado = endereco.Estado;

            _dbContext.Endereco.Update(enderecoPorId);
            await _dbContext.SaveChangesAsync();

            return enderecoPorId;
        }

        public async Task<bool> Deletar(int id)
        {
            EnderecoModel enderecoPorId = await BuscarId(id);

            if (enderecoPorId == null)
            {
                throw new Exception($"Endereco com o ID: {id} não foi localizado no banco de dados.");
            }

            _dbContext.Endereco.Remove(enderecoPorId);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
