using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace kuaforsln.Models;

public partial class Randevu
{
    [Key]
    public int Id { get; set; }
    [Required]
    public int KullaniciId { get; set; }
    [Required]
    public int UzmanId { get; set; }
    public DateTime RandevuTarih { get; set; }
    [ForeignKey("KullaniciId")]
    public virtual Kullanici Kullanici { get; set; }
    [ForeignKey("UzmanId")]
    public virtual Uzman Uzman { get; set; }
}