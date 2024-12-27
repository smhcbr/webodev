using System.ComponentModel.DataAnnotations;

namespace kuaforsln.Models;

public partial class IletisimForm
{
    [Key]
    public int Id { get; set; }
    public string Ad { get; set; }
    public string Baslik { get; set; }
    public string Mesaj { get; set; }
    public string Email { get; set; }
    public string Telefon { get; set; }
}