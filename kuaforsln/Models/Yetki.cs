using System.ComponentModel.DataAnnotations;

namespace kuaforsln.Models;

public partial class Yetki
{
    public  Yetki()
    { 
        Kullanici = new HashSet<Kullanici>();
    } 
    [Key] 
    public int Id { get; set; } 
    public string RoleAdi { get; set; } 
    public virtual ICollection<Kullanici> Kullanici { get; set; }
    
}