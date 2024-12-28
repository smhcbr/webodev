using kuaforsln.Models;

namespace kuaforsln.ViewModels
{
    public class ContactViewModel
    {
        public Iletisim Contact { get; set; } = new();
        public IletisimForm ContactForm { get; set; } = new();
    }
}
