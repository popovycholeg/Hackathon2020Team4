using System.ComponentModel.DataAnnotations;

namespace Hackathon2020Team4.ViewModels
{
    public class RegisterViewModel
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

        [Required(ErrorMessage = "Введіть Ваш університет!")]
        [Display(Name = "Введіт Ваш університет")]
        public string Institution { get; set; }

        [Required(ErrorMessage = "Введіть Ваш факультет!")]
        [Display(Name = "Введіть Ваш факультет")]
        public string Faculty { get; set; }

        [Required(ErrorMessage = "Введіть Ваш курс(рік навчання)!")]
        [Display(Name = "Введіть Ваш курс(рік навчання)")]
        public int InstitutionCourse { get; set; }

        [Required(ErrorMessage = "Введіть інформацію про себе!")]
        [Display(Name = "Розкажіть про свої вміння в галузі ІТ, технології з якими працювали, мови програмування, якими володієте, навичками. Що хітіли б дізнатися ще у свері ІТ?")]
        public string AboutMe { get; set; }

    }
}