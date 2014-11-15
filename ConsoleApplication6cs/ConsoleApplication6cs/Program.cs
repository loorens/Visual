using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Test;

namespace ConsoleApplicationDT6
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] kolory = { "green", "brown", "blue" };
            var s = kolory.Max(c => c.Length);

            int i;
            Console.ReadLine();
            /*
            Klasa k = new Klasa();
            //k.DodanieUczniaDoKlasy += WyswietlDodanego;
            k.DodanieUczniaDoKlasy += delegate(Uczen u) // metoda anonimowa
            {
                Console.WriteLine("Dodawanie delegat anonimowy {0} {1}", u.Imie, u.Nazwisko);
            };
            //k.UsuniecieUczniaZKlasy += WyswietlUsinietego;
            k.UsuniecieUczniaZKlasy += ucz => Console.WriteLine("Wyrazenie lambda Usunieto: {0} {1}", ucz.Imie, ucz.Nazwisko);
            k.UsuniecieUczniaZKlasy += ucz => WyswietlUsinietego(ucz); // wywoĹ?anie tej samej metody przez lambda
            Uczen u1 = new Uczen() { Nazwisko = "Czarny", Imie = "Bohdan" };
            k.DodanieUcznia(u1);
            k.UsuniecieOstatniegoUczniaZKlasy();
            int i = 1;
            try
            {
                i++;
                Wyjatki w = new Wyjatki();
                w.ThrowMojException();
                w.ThrowApplicationException();
                w.ThrowException();
                i++;
            }
            catch (MojException ex)
            {
                Console.WriteLine("Catch 1 {0}", ex.Message);
            }
            catch (ApplicationException ex)
            {
                Console.WriteLine("Catch 2 {0}", ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Catch 3 {0}", ex.Message);
            }
            finally
            {
                Console.WriteLine("FINALLLLLLY {0}", i);
            }*/
        }
        public static void WyswietlDodanego(Uczen uczen)
        {
            Console.WriteLine("Dodano: {0} {1}", uczen.Imie, uczen.Nazwisko);
        }
        public static void WyswietlUsinietego(Uczen uczen)
        {
            Console.WriteLine("Usunieto: {0} {1}", uczen.Imie, uczen.Nazwisko);
        }
        public static void Swap<T>(ref T a, ref T b)
        {
            T buff = a;
            a = b;
            b = buff;
        }
    }

}
namespace Test
{
    public delegate void DodanieUcznia(Uczen uczen);
    public delegate void UsuniecieUcznia(Uczen uczen);
    public class Uczen
    {
        public String Imie { get; set; }
        public String Nazwisko { get; set; }
    }
    public class Klasa
    {
        List<Uczen> Uczniowie = new List<Uczen>();
        int liczbaUczniow { get; set; }
        public event DodanieUcznia DodanieUczniaDoKlasy;
        public event UsuniecieUcznia UsuniecieUczniaZKlasy;

        public void DodanieUcznia(Uczen uczen)
        {
            Uczniowie.Add(uczen);
            liczbaUczniow++;
            DodanieUczniaDoKlasy(uczen);
        }
        public void UsuniecieOstatniegoUczniaZKlasy()
        {
            UsuniecieUczniaZKlasy(Uczniowie[liczbaUczniow - 1]);
            Uczniowie.RemoveAt(--liczbaUczniow);
        }
    }

    public class Stos<T> where T : new() //domyślny konstruktor wymagany
    {
        int pozycja = 0;
        T[] stos = new T[100];
        public void Dodaj(T element)
        {
            stos[pozycja++] = element;
        }
        public T Zdejmin()
        {
            return stos[--pozycja];
        }
    }

    class Wyjatki
    {
        public void ThrowApplicationException()
        {
            throw new ApplicationException("App ex rzucony");
        }
        public void ThrowException()
        {
            throw new Exception("Ex rzucony");
        }
        public void ThrowMojException()
        {
            throw new MojException("Moj ex rzucony");
        }
    }
    class MojException : ApplicationException
    {
        public MojException(string message) : base(message) { }
    }
}