using System;
using System.Collections.Generic;
using System.Linq;

public class Kisi
{
    public string Isim { get; set; }
    public string Numara { get; set; }
}

public class TelefonRehberi
{
    private List<Kisi> rehber = new List<Kisi>();

    public TelefonRehberi()
    {
        
        rehber.Add(new Kisi { Isim = "Ali", Numara = "1234567890" });
        rehber.Add(new Kisi { Isim = "Ayşe", Numara = "0987654321" });
        rehber.Add(new Kisi { Isim = "Mehmet", Numara = "1122334455" });
        rehber.Add(new Kisi { Isim = "Fatma", Numara = "5566778899" });
        rehber.Add(new Kisi { Isim = "Osman", Numara = "2233445566" });
    }
    public void NumaraKaydet(string isim, string numara)
    {
        if (rehber.Any(k => k.Isim == isim))
        {
            Console.WriteLine("Bu isimde bir kayıt zaten mevcut.");
        }
        else
        {
            rehber.Add(new Kisi { Isim = isim, Numara = numara });
            Console.WriteLine($"{isim} için numara kaydedildi.");
        }
    }

    public void NumaraSil(string isim)
    {
        var kisi = rehber.FirstOrDefault(k => k.Isim == isim);
        if (kisi != null)
        {
            rehber.Remove(kisi);
            Console.WriteLine($"{isim} silindi.");
        }
        else
        {
            Console.WriteLine("Bu isimde bir kayıt bulunamadı.");
        }
    }

    public void NumaraGuncelle(string isim, string yeniNumara)
    {
        var kisi = rehber.FirstOrDefault(k => k.Isim == isim);
        if (kisi != null)
        {
            kisi.Numara = yeniNumara;
            Console.WriteLine($"{isim} için numara güncellendi.");
        }
        else
        {
            Console.WriteLine("Bu isimde bir kayıt bulunamadı.");
        }
    }

    public void RehberListele(bool ters = false)
    {
        List<Kisi> siraliRehber;

        if (ters)
        {
            siraliRehber = rehber.OrderByDescending(k => k.Isim).ToList();
        }
        else
        {
            siraliRehber = rehber.OrderBy(k => k.Isim).ToList();
        }

        foreach (var kisi in siraliRehber)
        {
            Console.WriteLine($"{kisi.Isim}: {kisi.Numara}");
        }
    }

    public void RehberdeAra(string isim)
    {
        var kisi = rehber.FirstOrDefault(k => k.Isim == isim);
        if (kisi != null)
        {
            Console.WriteLine($"{kisi.Isim}: {kisi.Numara}");
        }
        else
        {
            Console.WriteLine("Bu isimde bir kayıt bulunamadı.");
        }
    }

    static void Main(string[] args)
    {
        var rehber = new TelefonRehberi();

        while (true)
        {
            Console.WriteLine("1. Telefon Numarası Kaydet");
            Console.WriteLine("2. Telefon Numarası Sil");
            Console.WriteLine("3. Telefon Numarası Güncelle");
            Console.WriteLine("4. Rehber Listeleme (A-Z)");
            Console.WriteLine("5. Rehber Listeleme (Z-A)");
            Console.WriteLine("6. Rehberde Arama");
            Console.WriteLine("7. Çıkış");

            int secim = Convert.ToInt32(Console.ReadLine());

            switch (secim)
            {
                case 1:
                    Console.Write("İsim: ");
                    string isim = Console.ReadLine();
                    Console.Write("Numara: ");
                    string numara = Console.ReadLine();
                    rehber.NumaraKaydet(isim, numara);
                    break;
                case 2:
                    Console.Write("Silinecek isim: ");
                    isim = Console.ReadLine();
                    rehber.NumaraSil(isim);
                    break;
                case 3:
                    Console.Write("Güncellenecek isim: ");
                    isim = Console.ReadLine();
                    Console.Write("Yeni numara: ");
                    numara = Console.ReadLine();
                    rehber.NumaraGuncelle(isim, numara);
                    break;
                case 4:
                    rehber.RehberListele();
                    break;
                case 5:
                    rehber.RehberListele(true);
                    break;
                case 6:
                    Console.Write("Aranacak isim: ");
                    isim = Console.ReadLine();
                    rehber.RehberdeAra(isim);
                    break;
                case 7:
                    return;
            }
        }
    }
}
