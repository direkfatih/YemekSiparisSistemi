namespace YemekSiparisSistemi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Restoran restoran= new Restoran();

            restoran.YemekEkle(new AnaYemek ("Kebap", 140 ));
            restoran.YemekEkle(new Icecek ("Cola", 25 ));
            restoran.YemekEkle(new Tatli("Sütlaç", 70));

            restoran.YemekEkle(new AnaYemek("Adana", 150));
            restoran.YemekEkle(new Icecek("Ayran", 20));
            restoran.YemekEkle(new Tatli("Künefe", 80));

            restoran.YemekEkle(new AnaYemek("İskender", 240));
            restoran.YemekEkle(new Icecek("Gazoz", 25));
            restoran.YemekEkle(new Tatli("Baklava", 90));

            restoran.MenuyuGoster();
            restoran.SiparisAl();
            
        }
    }

    class Yemek
    {
        public string YemekAd { get; set; }
        public double YemekFiyat { get; set; }

        public Yemek(string yemekAd, double yemekFiyat)
        {
            YemekAd = yemekAd;
            YemekFiyat = yemekFiyat;
        }

        public virtual void YemekBilgisiYazdir()
        {
            Console.WriteLine($"Yemek: {YemekAd}, Fiyatı: {YemekFiyat} TL");
        }
    }

    class AnaYemek : Yemek
    {
        public AnaYemek(string yemekAd, double yemekFiyat) : base (yemekAd, yemekFiyat)
        {

        }

        public override void YemekBilgisiYazdir()
        {
            Console.WriteLine($"Ana Yemek: {YemekAd}, Fiyatı: {YemekFiyat} TL");
        }
    }

    class Icecek : Yemek
    {
        public Icecek(string yemekAd, double yemekFiyat) : base(yemekAd, yemekFiyat)
        {

        }

        public override void YemekBilgisiYazdir()
        {
            Console.WriteLine($"İçecek: {YemekAd}, Fiyatı: {YemekFiyat} TL");
        }

    }

    class Tatli : Yemek
    {
        public Tatli(string yemekAd, double yemekFiyat) : base(yemekAd, yemekFiyat)
        {

        }

        public override void YemekBilgisiYazdir()
        {
            Console.WriteLine($"Tatlı: {YemekAd}, Fiyatı: {YemekFiyat} TL");
        }
    }

    class Restoran
    {
        private List<Yemek> yemekListesi = new List<Yemek>();

        public void YemekEkle(Yemek yeniYemek)
        {
            yemekListesi.Add(yeniYemek);
        }

        public void MenuyuGoster()
        {
            Console.WriteLine("<Menü>");
            Console.WriteLine("Ana Yemekler:");
            foreach (var yemek in yemekListesi.OfType<AnaYemek>())
            {
                yemek.YemekBilgisiYazdir();
            }

            Console.WriteLine("\nIçecekler:");
            foreach (var yemek in yemekListesi.OfType<Icecek>())
            {
                yemek.YemekBilgisiYazdir();
            }

            Console.WriteLine("\nTatlılar:");
            foreach (var yemek in yemekListesi.OfType<Tatli>())
            {
                yemek.YemekBilgisiYazdir();
            }
        }


        //public void SiparisAl()
        //{
        //    Console.WriteLine("Sipariş vermek istediğiniz yemeği giriniz: ");
        //    string siparisAd = Console.ReadLine();

        //    Yemek secilenYemek = null;

        //    foreach (var item in yemekListesi)
        //    {
        //        if (item.YemekAd == siparisAd)
        //        {
        //            secilenYemek = item;
        //            break;
        //        }
        //    }

        //    if (secilenYemek != null)
        //    {
        //        Console.WriteLine($"Sipariş edilen yemek: {secilenYemek.YemekAd}, Toplam tutar: {secilenYemek.YemekFiyat}");
        //    }
        //    else
        //    {
        //        Console.WriteLine("Üzgünüz! Menümüzde böyle bir yemek bulunmamaktadır.");
        //    }

        //}
        public void SiparisAl()
        {
            List<Yemek> siparisListesi = new List<Yemek>();
            double toplamTutar = 0;

            Console.Write("Sipariş vermek istediğiniz yemeği giriniz: ");
            string siparisAdi = Console.ReadLine();
            Yemek secilenYemek = yemekListesi.Find(y => y.YemekAd.Equals(siparisAdi, StringComparison.OrdinalIgnoreCase));
            Console.WriteLine("************************************");
            if (secilenYemek != null)
            {
                siparisListesi.Add(secilenYemek);
                toplamTutar += secilenYemek.YemekFiyat;
                Console.WriteLine($"Siparişiniz alındı: {secilenYemek.YemekAd}, Fiyat: {secilenYemek.YemekFiyat} TL");
            }
            else
            {
                Console.WriteLine("Üzgünüz, menümüzde böyle bir yemek yoktur.");
            }


            while (true) 
            {
                Console.Write("Sipariş vermek istediğiniz yemeği giriniz. Yemek siparişinizi tamamladıysanız 'çıkış' yazarak sipariş verme işleminizi bitireblirsiniz: ");
                siparisAdi = Console.ReadLine();
                Console.WriteLine("************************************");
                if (siparisAdi.ToLower() == "çıkış")
                {
                    break;
                }

                secilenYemek = yemekListesi.Find(y => y.YemekAd.Equals(siparisAdi, StringComparison.OrdinalIgnoreCase));

                if (secilenYemek != null)
                {
                    siparisListesi.Add(secilenYemek);
                    toplamTutar += secilenYemek.YemekFiyat;
                    Console.WriteLine($"Siparişiniz alındı: {secilenYemek.YemekAd}, Fiyat: {secilenYemek.YemekFiyat} TL");
                }
                else
                {
                    Console.WriteLine("Üzgünüz, menümüzde böyle bir yemek yoktur.");
                }
            }

            Console.WriteLine("Siparişleriniz: ");

            foreach (var item in siparisListesi)
            {
                item.YemekBilgisiYazdir();
            }

            Console.WriteLine($"Toplam Tutar: {toplamTutar} TL");
        }
    }
}