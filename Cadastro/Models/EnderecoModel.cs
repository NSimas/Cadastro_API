using Cadastro.Enums;

namespace Cadastro.Models
{
    public class EnderecoModel
    {
        public int Id { get; set; }
        public int PessoaId { get; set; }
        public virtual PessoaFisicaModel? pessoa { get; set; }

        public string? Logradouro { get; set; }
        public string? Numero { get; set; }
        public string? CEP { get; set; }
        public string? Complemento { get; set; }
        public string? Cidade { get; set; }
        public EstadosBrasileiros? Estado { get; set; }
    }
}
