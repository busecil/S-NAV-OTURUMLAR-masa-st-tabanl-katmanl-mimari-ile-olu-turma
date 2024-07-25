using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Varliklar;

namespace VeriBaglantisi
{
    public class SinavOturumlariuyg: DbContext
    {
        DbSet<Sinav> Sinavlar { get; set; }
    }
}
