using System.ComponentModel.DataAnnotations;

namespace Chapter_Decio.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "E-mail requerido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Senha requerida")]

        public string Senha { get; set; }
    }
}
