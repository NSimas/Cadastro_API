using Cadastro.Data.Map;
using Cadastro.Models;
using Microsoft.EntityFrameworkCore;

namespace Cadastro.Data
{
    public class CadastroDbContext : DbContext
    {

        public CadastroDbContext(DbContextOptions<CadastroDbContext> options)
            : base(options)
        {
        }

        public DbSet<UsuarioModel> Usuario { get; set; }
        public DbSet<PessoaFisicaModel> PessoaFisica { get; set; }
        public DbSet<EnderecoModel> Endereco { get; set; }
        public DbSet<ContatoModel> Contato { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioMap());
            modelBuilder.ApplyConfiguration(new PessoaFisicaMap());
            modelBuilder.ApplyConfiguration(new EnderecoMap());
            modelBuilder.ApplyConfiguration(new ContatoMap());

            base.OnModelCreating(modelBuilder);
        }

    }
}
