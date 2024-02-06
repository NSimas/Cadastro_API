using Cadastro.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cadastro.Data.Map
{
    public class ContatoMap : IEntityTypeConfiguration<ContatoModel>
    {
        public void Configure(EntityTypeBuilder<ContatoModel> builder)
        {

            builder.HasKey(x => x.Id);
            builder.Property(x => x.PessoaId)
                .IsRequired()
                .HasMaxLength(10);

            builder.Property(x => x.Nome)
                .IsRequired()
                .HasMaxLength(255);
            builder.Property(x => x.Tipo)
                .IsRequired();
            builder.Property(x => x.Contato)
                .IsRequired()
                .HasMaxLength(150);

            //relations
            builder.HasOne(x => x.pessoa);
                   //.WithMany(x => x.Contatos)
                   //.HasForeignKey(x => x.PessoaId)
                   //.IsRequired();

        }
    }
}
