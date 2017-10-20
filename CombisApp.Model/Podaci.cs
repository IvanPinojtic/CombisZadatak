using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CombisApp.Model
{
    [Table("Podaci")]
    public class Podaci
    {
        [Key]
        public int Id { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        [RegularExpression("([0-9]+)")]
        public string PostanskiBroj { get; set; }
        public string Grad { get; set; }
        public string Telefon { get; set; }
    }
}
