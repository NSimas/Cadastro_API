using Cadastro.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cadastro.Data.Map
{
    public class PessoaFisicaMap : IEntityTypeConfiguration<PessoaFisicaModel>
    {
        public void Configure(EntityTypeBuilder<PessoaFisicaModel> builder)
        {

            builder.HasKey(x => x.Id);
            builder.Property(x => x.IdUsuario)
                .IsRequired()
                .HasMaxLength(10);
            builder.Property(x => x.Nome)
                .IsRequired()
                .HasMaxLength(255);
            builder.Property(x => x.Sobrenome)
                .IsRequired()
                .HasMaxLength(255);
            builder.Property(x => x.DataNascimento)
                .IsRequired();
            builder.Property(x => x.Email)
                .IsRequired()
                .HasMaxLength(150);
            builder.Property(x => x.CPF)
                .IsRequired()
                .HasMaxLength(15);
            builder.Property(x => x.RG)
                .IsRequired()
                .HasMaxLength(18);

            //relations
            builder.HasOne(x => x.Usuario);

            builder.HasMany(x => x.Enderecos)
                .WithOne(x => x.pessoa)
                .HasForeignKey(y => y.PessoaId)
                .IsRequired();
            builder.HasMany(x => x.Contatos)
                .WithOne(x => x.pessoa)
                .HasForeignKey(y => y.PessoaId)
                .IsRequired();
        }
    }

}