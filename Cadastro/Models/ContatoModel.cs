using Cadastro.Enums;

namespace Cadastro.Models
{
    public class ContatoModel
    {
        public int Id { get; set; }
        public int PessoaId { get; set; }
        public virtual PessoaFisicaModel? pessoa { get; set; }

        public string? Nome { get; set; }
        public TipoContato? Tipo { get; set; }
        public string? Contato { get; set; }
    }
}
