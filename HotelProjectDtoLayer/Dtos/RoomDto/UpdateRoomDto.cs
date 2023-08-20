using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProjectDtoLayer.Dtos.RoomDto
{
    public class UpdateRoomDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Lütfen oda numarısını giriniz.")]
        public string RoomNumber { get; set; }

        [Required(ErrorMessage = "Lütfen oda görselini giriniz.")]
        public string RoomCoverImage { get; set; }

        [Required(ErrorMessage = "Lütfen odanın fiyat bilgisini giriniz.")]
        public int Price { get; set; }

        [Required(ErrorMessage = "Lütfen odanın başlık bilgisini giriniz.")]
        [StringLength(100,ErrorMessage ="Lütfen en fazla 100 karakter giriniz.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Lütfen yatak sayısı giriniz.")]
        public string BedCount { get; set; }

        [Required(ErrorMessage = "Lütfen banyo sayısı giriniz.")]
        public string BathCount { get; set; }

        public string Wifi { get; set; }

        [Required(ErrorMessage = "Lütfen oda açıklamasını giriniz.")]
        public string Description { get; set; }
    }
}
