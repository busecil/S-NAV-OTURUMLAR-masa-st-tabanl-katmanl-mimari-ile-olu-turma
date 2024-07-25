using İnterfaceler;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Varliklar;

namespace VeriBaglantisi
{
    public class SinavDAL : VtIslemleriI<Sinav>
    {
        public void Ekle(Sinav kayit)
        {
            using (SinavOturumlariuyg vt = new SinavOturumlariuyg())
            {
                vt.Entry(kayit).State = EntityState.Added;
                vt.SaveChanges();
            }
        }

        public void Guncelle(Sinav kayit)
        {
            using (SinavOturumlariuyg vt = new SinavOturumlariuyg())
            {
                vt.Entry(kayit).State = EntityState.Modified;
                vt.SaveChanges();
            }
        }

        public void Sil(Sinav kayit)
        {
            using (SinavOturumlariuyg vt = new SinavOturumlariuyg())
            {
                vt.Entry(kayit).State = EntityState.Deleted;
                vt.SaveChanges();
            }
        }

        public List<Sinav> sorgula(Func<Sinav, bool> filtre)
        {
            using (SinavOturumlariuyg vt = new SinavOturumlariuyg())
            {
                return filtre == null ? vt.Set<Sinav>().ToList() : vt.Set<Sinav>().Where(filtre).ToList();
            }
        }

        public List<Sinav> tamaminiGetir()
        {
            using (SinavOturumlariuyg vt = new SinavOturumlariuyg())
            {
                return vt.Set<Sinav>().ToList();
            }
        }

        public Sinav tekilGetir(Func<Sinav, bool> filtre = null)
        {
            using (SinavOturumlariuyg vt = new SinavOturumlariuyg())
            {
                return vt.Set<Sinav>().SingleOrDefault(filtre);
            }
        }

        public Sinav tekilGetir(int ID)
        {
            using (SinavOturumlariuyg vt = new SinavOturumlariuyg())
            {
                return vt.Set<Sinav>().SingleOrDefault(o => o.ID == ID);
            }
        }

        public void TopluEkle(List<Sinav> eklenecekListe)
        {
            using (SinavOturumlariuyg vt = new SinavOturumlariuyg())
            {
                foreach (Sinav Eleman in eklenecekListe)
                {
                    vt.Entry(Eleman).State = EntityState.Added;
                }

                vt.SaveChanges();
            }
        }

        public void TopluSil(List<Sinav> silinecekListe)
        {
            using (SinavOturumlariuyg vt = new SinavOturumlariuyg())
            {
                foreach (Sinav Eleman in silinecekListe)
                {
                    vt.Entry(Eleman).State = EntityState.Deleted;
                }

                vt.SaveChanges();
            }
        }
    }
}
