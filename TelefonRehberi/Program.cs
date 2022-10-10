using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelefonRehberi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Kisi> kisiler = new List<Kisi>();
            Kisi kisi1 = new Kisi("Yunus", "Başer", "5554442211");
            kisiler.Add(kisi1);
            Kisi kisi2 = new Kisi("Emre", "Sırakaya", "4443332255");
            kisiler.Add(kisi2);
            Kisi kisi3 = new Kisi("Eylül", "Kaya", "5652123399");
            kisiler.Add(kisi3);
            Kisi kisi4 = new Kisi("Mustafa", "Korkmaz", "2225457899");
            kisiler.Add(kisi4);
            Kisi kisi5 = new Kisi("Halil", "Taş", "4546565213");
            kisiler.Add(kisi5);
            bool tekrarEtsinMi = true;
            do
            {
                Console.WriteLine("Lütfen yapmak istediğiniz işlemi seçiniz :)");
                Console.WriteLine("**************************************************************************************************");
                Console.WriteLine("(1) Yeni Numara Kaydetmek");
                Console.WriteLine("(2) Varolan Numarayı Silmek");
                Console.WriteLine("(3) Varolan Numarayı Güncelllemek");
                Console.WriteLine("(4) Rehberi Listelemek");
                Console.WriteLine("(5) Rehberde Arama Yapmak");


                int secim = Convert.ToInt32(Console.ReadLine());

                if (secim == 1)
                {

                    string isim, soyisim, numara;
                    Console.Write("Lütfen isim giriniz            : "); isim = Console.ReadLine();
                    Console.WriteLine();
                    Console.Write("Lütfen soyisim giriniz         : "); soyisim = Console.ReadLine();
                    Console.WriteLine();
                    Console.Write("Lütfen telefon numarası giriniz: "); numara = Console.ReadLine();
                    kisiler.Add(new Kisi(isim, soyisim, numara));
                    Console.WriteLine("Kişi eklendi !");

                    foreach  (Kisi kisi in kisiler)
                    {
                        Console.WriteLine(kisi.Isim);
                    }
                    
                }
                else if (secim == 2)
                {
                    bool bitmedi = true;
                    do
                    {
                        Console.WriteLine("Lütfen numarasını silmek istediğiniz kişinin adını ya da soyadını giriniz");
                        string aranan = Console.ReadLine();
                        bool bulundu = false;
                        foreach (Kisi kisi in kisiler)
                        {
                            if (kisi.Isim == aranan || kisi.Soyisim == aranan)
                            {
                                bulundu = true;
                                Console.WriteLine(kisi.Isim + " isimli kişi rehberden silinmek üzere, onaylıyor musunuz ?(y/n)");
                                char cevap = Convert.ToChar(Console.ReadLine());
                                if (cevap == 'y')
                                {
                                    kisiler.Remove(kisi);
                                    Console.WriteLine("Kişi silindi !");
                                    
                                    bitmedi = false;
                                    break;
                                }
                                else if (cevap == 'n')
                                {
                                    Console.WriteLine("İşlem iptal edilmiştir !");
                                    bitmedi = false;
                                    break;
                                }
                            }
                            else
                            {
                                bulundu = false;

                            }
                        }

                        if(bulundu == false)
                        {

                            Console.WriteLine("Aradığınız kriterlere uygun veri rehberde bulunamadı. Lütfen bir seçim yapınız.");
                            Console.WriteLine("* Silmeyi sonlandırmak için : (1) \n* Yeniden denemek için : (2)");
                            char cevap2 = Convert.ToChar(Console.ReadLine());
                            if (cevap2 == '1')
                            {
                                Console.WriteLine("İşlem iptal edilmiştir !");
                                bitmedi = false;
                            }
                            else if (cevap2 == '2')
                            {
                                bitmedi = true;
                            }


                        }

                    } while (bitmedi);

                }else if(secim == 3)
                {
                    bool bitmemis = true;
                    bool bulundu_mu = false;
                    do
                    {
                        Console.WriteLine("Lütfen numarasını güncellemek istediğiniz kişinin adını ya da soyadını giriniz.");
                        string guncellenecekKisi = Console.ReadLine();
                        foreach(Kisi kisi in kisiler)
                        {
                            if(kisi.Isim == guncellenecekKisi || kisi.Soyisim == guncellenecekKisi)
                            {
                                bulundu_mu = true;
                                Console.WriteLine("Lütfen "+kisi.Isim+" isimli kişinin yeni numarasını giriniz.");
                                string guncelNumara = Console.ReadLine();
                                kisi.Numara = guncelNumara;
                                
                                bitmemis = false;
                                break;
                            }
                            else
                            {
                                bulundu_mu = false;
                               
                            }
                        }

                        if (bulundu_mu == false)
                        {
                            Console.WriteLine("Aradığınız kriterlere uygun veri rehberde bulunamadı. Lütfen bir seçim yapınız.");
                            Console.WriteLine("* Güncellemeyi sonlandırmak için : (1) \n* Yeniden denemek için : (2)");
                            char cevap3 = Convert.ToChar(Console.ReadLine());
                            if (cevap3 == '1')
                            {
                                Console.WriteLine("İşlem iptal edilmiştir !");
                                bitmemis = false;
                            }
                            else if (cevap3 == '2')
                            {
                                bitmemis = true;
                            }
                        }

                    } while (bitmemis);

                }else if(secim == 4)
                {
                    Console.WriteLine("************ Kişi Listesi ************");
                    foreach(Kisi kisi in kisiler)
                    {
                        Console.WriteLine("İsim : "+kisi.Isim);
                        Console.WriteLine("Soyisim : "+kisi.Soyisim);
                        Console.WriteLine("Telefon Numarası : "+kisi.Numara);
                        Console.WriteLine("-");
                    }

                }else if(secim == 5)
                {
                    bool sonlandirildi = true;
                    bool mevcut_mu = false;
                    do
                    {
                        Console.WriteLine("Arama yapmak istediğiniz tipi seçiniz.\n" +
                            "**********************************************\n" +
                            "İsim veya soyisime göre arama yapmak için (1)\n" +
                            "Telefon numarasına göre arama yapmak için (2)");
                        char secenek = Convert.ToChar(Console.ReadLine());
                        if(secenek == '1')
                        {
                            Console.WriteLine("Lütfen aranacak isim veya soyisimi giriniz.");
                            string aranacak = Console.ReadLine();
                            foreach(Kisi kisi in kisiler)
                            {
                                if(kisi.Isim == aranacak || kisi.Soyisim == aranacak)
                                {
                                    mevcut_mu = true;
                                    sonlandirildi=false;
                                    Console.WriteLine("İsim : "+kisi.Isim);
                                    Console.WriteLine("Soyisim : "+kisi.Soyisim);
                                    Console.WriteLine("Telefon Numarası : "+kisi.Numara);
                                    Console.WriteLine("-");
                                }
                            }
                            if(mevcut_mu == false)
                            {
                                Console.WriteLine("Aradığınız kriterlere uygun veri rehberde bulunamadı! Lütfen bir seçim yapınız.\n" +
                                    "* Aramayı sonlandırmak için (1)\n" +
                                    "* Yeniden denemek için (2)");
                                char alternatif = Convert.ToChar(Console.ReadLine());
                                if(alternatif == '1')
                                {
                                    sonlandirildi = false;
                                }else if(alternatif == '2')
                                {
                                    sonlandirildi=true;
                                }
                            }
                        }

                    } while (sonlandirildi);
                }

            } while (tekrarEtsinMi);

            






        }
    }
}
