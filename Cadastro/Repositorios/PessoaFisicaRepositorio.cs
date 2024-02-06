using Cadastro.Data;
using Cadastro.Models;
using Cadastro.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Cadastro.Repositorios
{
    public class PessoaFisicaRepositorio : IPessoaFisicaRepositorio
    {
        private readonly CadastroDbContext _dbContext;

        public PessoaFisicaRepositorio(CadastroDbContext cadastroDbContext)
        {
            _dbContext = cadastroDbContext;
        }

        public async Task<List<PessoaFisicaModel>> BuscarTodasPessoas()
        {
            return await _dbContext.PessoaFisica
                .Include(x => x.Enderecos)
                .Include(x => x.Contatos)
                .ToListAsync();
        }

        public async Task<PessoaFisicaModel> BuscarId(int id)
        {
            return await _dbContext.PessoaFisica.Include(x => x.Enderecos).Include(x => x.Contatos).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<PessoaFisicaModel> Adicionar(PessoaFisicaModel pessoaFisica)
        {
            await _dbContext.PessoaFisica.AddAsync(pessoaFisica);
            await _dbContext.SaveChangesAsync();

            return pessoaFisica;
        }

        public async Task<PessoaFisicaModel> Atualizar(PessoaFisicaModel pessoaFisica, int id)
        {
            PessoaFisicaModel pessoaFisicaPorId = await BuscarId(id);

            if (pessoaFisicaPorId == null)
            {
                throw new Exception($"Pessoa Fisica com o ID: {id} não foi localizada no banco de dados.");
            }

            pessoaFisicaPorId.Nome = pessoaFisica.Nome;
            pessoaFisicaPorId.Sobrenome = pessoaFisica.Sobrenome;
            pessoaFisicaPorId.DataNascimento = pessoaFisica.DataNascimento;
            pessoaFisicaPorId.Email = pessoaFisica.Email;
            pessoaFisicaPorId.CPF = pessoaFisica.CPF;
            pessoaFisicaPorId.RG = pessoaFisica.RG;

            _dbContext.PessoaFisica.Update(pessoaFisicaPorId);
            await _dbContext.SaveChangesAsync();

            return pessoaFisicaPorId;
        }



        public async Task<bool> Deletar(int id)
        {
            PessoaFisicaModel pessoaFisicaPorId = await BuscarId(id);

            if (pessoaFisicaPorId == null)
            {
                throw new Exception($"Pessoa Fisica com o ID: {id} não foi localizada no banco de dados.");
            }

            _dbContext.PessoaFisica.Remove(pessoaFisicaPorId);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
