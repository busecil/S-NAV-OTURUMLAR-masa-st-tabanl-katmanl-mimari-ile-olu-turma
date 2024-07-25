using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Varliklar
{
    [Table("SinavOturumlari")]
    public class Sinav
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public TimeSpan Saat { get; set; }
        public bool Aktif { get; set; }
        public Sinav()
        {
        }

        public Sinav(int ID, TimeSpan saat, bool aktif)
        {
            this.ID = ID;
            Saat = saat;
            Aktif = aktif;
        }
    }
}