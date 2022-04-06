namespace DesafioCientec.Business.Models
{
    public class Fundacao : Entity
    {
        public string Nome { get; set; }
        public string Documento { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string InstituicaoApoiada { get; set; }
    }
}