﻿using System.ComponentModel.DataAnnotations;

namespace HotelProjectWebUI.Dtos.LoginDto
{
    public class LoginUserDto
    {
        [Required(ErrorMessage ="Kullanıcı Adını Giriniz")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Şifreyi Giriniz")]
        public string Password { get; set; }
    }
}
