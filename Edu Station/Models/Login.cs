using System.ComponentModel.DataAnnotations;

namespace Edu_Station.Models
{
    public class Login
    {
        [Required(ErrorMessage = "Digite o login")]
        public string User { get; set; }

        [Required(ErrorMessage = "Digite a senha")]
        public string Senha { get; set; }
    }
}
