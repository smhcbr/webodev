using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace kuaforsln.Models
{
    public partial class Gallery
    {
        [Key]
        public int Id { get; set; }
        public string ResimAciklama { get; set; }
        [Required]
        public string ResimYol { get; set; }
        public DateTime ResimTarihi { get; set; }
        public int ResimId { get; set; }

        public virtual Kullanici ResimKullanici { get; set; }
    }
}