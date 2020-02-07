using System.ComponentModel.DataAnnotations;

namespace Hackathon2020Team4.ViewModels
{
    public class TeacherRegisterViewModel
    {
        [Required(ErrorMessage = "Введіть Email!")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

        [Required]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        [DataType(DataType.Password)]
        [Display(Name = "Підтвердіть пароль")]
        public string PasswordConfirm { get; set; }

        [Required(ErrorMessage = "Введіть Ваше Прізвище!")]
        [Display(Name = "Введіть Ваше Прізвище")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Введіть Ім*я!")]
        [Display(Name = "Введіть Ваше Ім*я")]
        public string FirstMidName { get; set; }
    }
}