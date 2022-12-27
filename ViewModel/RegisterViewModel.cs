using System.ComponentModel.DataAnnotations;

namespace ApiSqlAsp.ViewModel
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "O nome é Obrigatório")]
        public string UserNames { get; set; }
    }
}
