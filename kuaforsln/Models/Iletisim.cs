using System.ComponentModel.DataAnnotations;

namespace kuaforsln.Models;

public partial class Iletisim
{
    [Key]
    public int Id { get; set; }
    public string Email { get; set; }
    public string Telefon { get; set; }
    public string Adres { get; set; }
    
}