using İnterfaceler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Varliklar;
using VeriBaglantisi;


namespace İslemler
{
    public class SinavIslemleri : VtIslemleriI<Sinav>
    {
        public SinavDAL sinavDAL;
        public SinavIslemleri()
        {
            if (sinavDAL == null)
            {
                sinavDAL = new SinavDAL();
            }

        }
        public void Ekle(Sinav kayit)
        {
            sinavDAL.Ekle(kayit);
        }

        public void Guncelle(Sinav kayit)
        {
            sinavDAL.Guncelle(kayit);
        }

        public void Sil(Sinav kayit)
        {
            sinavDAL.Sil(kayit);
        }

        public List<Sinav> sorgula(Func<Sinav, bool> filtre)
        {
            return sinavDAL.sorgula(filtre);
        }

        public List<Sinav> tamaminiGetir()
        {
            return sinavDAL.tamaminiGetir();
        }

        public Sinav tekilGetir(Func<Sinav, bool> filtre = null)
        {
            return sinavDAL.tekilGetir(filtre);
        }

        public Sinav tekilGetir(int ID)
        {
            return sinavDAL.tekilGetir(ID);
        }

        public void TopluEkle(List<Sinav> eklenecekListe)
        {
            sinavDAL.TopluEkle(eklenecekListe);
        }

        public void TopluSil(List<Sinav> silinecekListe)
        {
            sinavDAL.TopluSil(silinecekListe);
        }
    }
}
