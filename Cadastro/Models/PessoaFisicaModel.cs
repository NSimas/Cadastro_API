namespace Cadastro.Models
{
    public class PessoaFisicaModel
    {
        public int Id { get; set; }
        public int IdUsuario { get; set; }
        public virtual UsuarioModel Usuario { get; set; }
        public string? Nome { get; set; }
        public string? Sobrenome { get; set; }
        public DateTime? DataNascimento { get; set; }
        public string? Email { get; set; }
        public string? CPF { get; set; }
        public string? RG { get; set; }

        public List<EnderecoModel> Enderecos { get; set; } = new List<EnderecoModel>();
        public List<EnderecoModel> Contatos { get; set; } = new List<EnderecoModel>();
        

    }
}
