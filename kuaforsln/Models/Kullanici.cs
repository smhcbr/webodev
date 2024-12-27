using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace kuaforsln.Models;

public partial class Kullanici
{
    public static object Identity;

    public Kullanici()
    {
        Randevu = new HashSet<Randevu>();
        Uzman = new HashSet<Uzman>();
        Gallery = new HashSet<Gallery>();
    }
    
    [Key]
    public int KullaniciID { get; set; }
    [Required]
    public String KullaniciAdi { get; set; }
    [Required]
    public String Sifre { get; set; }
    [Required]
    public String TamAdi { get; set; }
    [Required]
    public String Email { get; set; }
    public String Telefon { get; set; }
    public String Adres { get; set; }
    [Required]
    public int YetkiId { get; set; }
    [ForeignKey("YetkiId")]
    public virtual Yetki Yetki { get; set; }
    
    public virtual ICollection<Randevu> Randevu { get; set; }
    public virtual ICollection<Uzman> Uzman { get; set; }
    public virtual ICollection<Gallery> Gallery { get; set; }


    public static bool IsInRole(string user)
    {
        throw new NotImplementedException();
    }
}