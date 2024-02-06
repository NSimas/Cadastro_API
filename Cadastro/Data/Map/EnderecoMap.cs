using Cadastro.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cadastro.Data.Map
{
    public class EnderecoMap : IEntityTypeConfiguration<EnderecoModel>
    {
        
        public void Configure(EntityTypeBuilder<EnderecoModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.PessoaId)
                .IsRequired()
                .HasMaxLength(10);

            builder.Property(x => x.Logradouro)
                .IsRequired()
                .HasMaxLength(255);
            builder.Property(x => x.Numero)
                .IsRequired()
                .HasMaxLength(50);
            builder.Property(x => x.CEP)
                .IsRequired()
                .HasMaxLength(50);
            builder.Property(x => x.Complemento)
                .IsRequired()
                .HasMaxLength(255);
            builder.Property(x => x.Cidade)
                .IsRequired()
                .HasMaxLength(255);
            builder.Property(x => x.Estado)
                .IsRequired();

            //relations
            builder.HasOne(x => x.pessoa);
                //.WithMany(x => x.Enderecos)
                //.HasForeignKey(y => y.PessoaId)
                //.IsRequired();
        }
    }
}