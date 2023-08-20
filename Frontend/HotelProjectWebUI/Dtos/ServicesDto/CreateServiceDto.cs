using System.ComponentModel.DataAnnotations;

namespace HotelProjectWebUI.Dtos.ServicesDto
{
    public class CreateServiceDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Hizmet ikon linki giriniz.")]
        public string ServiceIcon { get; set; }

        [Required(ErrorMessage = "Hizmet başlığı giriniz.")]
        [StringLength(100, ErrorMessage = "başlık en fazla 100 karakter olabilir.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Hizmet açıklaması giriniz.")]
        [StringLength(300,ErrorMessage ="Açıklama en fazla 300 karakter olabilir.")]
        public string Description { get; set; }
    }
}
