using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace kuaforsln.Models;

public partial class Uzman
{
    public Uzman()
    {
        Randevu = new HashSet<Randevu>();
    }
    [Key]
    public int Id { get; set; }
    [Required]
    public int KullaniciId { get; set; }
    public string UzmanAlan { get; set; }
    [ForeignKey("KullaniciId")]
    public virtual Kullanici Kullanici { get; set; }
    public virtual ICollection<Randevu> Randevu { get; set; }
}