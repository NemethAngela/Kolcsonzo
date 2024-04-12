using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ClassLibrary.Models
{
    public partial class Kolcsonzesek
    {
        [Key]
        public int Id { get; set; }
        public int KolcsonzokId { get; set; }
        public string? Iro { get; set; }
        public string? Mufaj { get; set; }
        public string? Cim { get; set; }

        public virtual Kolcsonzok Kolcsonzok { get; set; } = null!;
    }
}
