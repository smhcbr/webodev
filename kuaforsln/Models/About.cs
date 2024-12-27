using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace kuaforsln.Models
{
    public partial class About
    {
        [Key]
        public int Id { get; set; }
        public string Amac { get; set; }
        public string Vizyon { get; set; }
        public string Hakkinda { get; set; }
    }
}