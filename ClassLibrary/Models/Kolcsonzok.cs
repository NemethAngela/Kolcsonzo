using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ClassLibrary.Models
{
    public partial class Kolcsonzok
    {
        public Kolcsonzok()
        {
            Kolcsonzeseks = new HashSet<Kolcsonzesek>();
        }

        [Key]
        public int Id { get; set; }
        public string? Nev { get; set; }
        public string SzulIdo { get; set; } = null!;

        public virtual ICollection<Kolcsonzesek> Kolcsonzeseks { get; set; }
    }
}
