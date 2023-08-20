using System.ComponentModel.DataAnnotations;

namespace HotelProjectWebUI.Dtos.RegisterDto
{
    public class CreateNewUserDto
    {
        [Required(ErrorMessage ="Ad boş olamaz.")]
        public string Name { get; set; }

        [Required(ErrorMessage ="Soyad boş olamaz.")]
        public string SurName { get; set; }

        [Required(ErrorMessage ="Şehir boş olamaz.")]
        public string City { get; set; }

        [Required(ErrorMessage ="Kullanıcı adı boş olamaz.")]
        public string UserName { get; set; }

        [Required(ErrorMessage ="Mail adresi boş olamaz.")]
        public string Mail { get; set; }

        [Required(ErrorMessage ="Şifre boş olamaz.")]
        public string Password { get; set; }


        [Required(ErrorMessage ="Şifre tekrar alanı boş olamaz.")]
        [Compare("Password",ErrorMessage ="Şifreler uyuşmuyor")]
        public string PasswordConfirm { get; set; }
    }
}
