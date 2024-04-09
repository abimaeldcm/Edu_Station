using Edu_Station.Models.Enum;
using System.ComponentModel.DataAnnotations;

namespace Edu_Station.Models
{
    public class Login
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Digite o login")]
        public string User { get; set; }

        [Required(ErrorMessage = "Digite a senha")]
        public string Senha { get; set; }
        public EPerfil Perfil { get; set; }
    }
}
