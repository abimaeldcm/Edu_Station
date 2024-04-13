using Edu_Station.Models.Enum;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Edu_Station.Models
{
    public class Pessoa
    {
        public Guid Id { get; set; }

        [DisplayName("Nome Completo")]
        [Required]
        public string NomeCompleto { get; set; }
        [Required]
        public string CPF { get; set; }
        public EPerfil Perfil { get; set; }
        [Required]
        public string Senha { get; set; }
        [Required]
        public DateTime DataNascimento { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
    }
}
