using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleDT2
{
    class Program
    {
        static void Main(string[] args)
        {
            Samochody.Porownaj("test"); //statyczna metoda klasy
            Samochody mojeSamochody = new Samochody();
            Auto opel = new Auto("Astra", "Opel");
            mojeSamochody += opel; //użycie operatora dodawania
            mojeSamochody = mojeSamochody + new Auto("Punto", "Fiat");
            mojeSamochody.Wypisz();
            //użycie indeksatora
            Console.WriteLine("Marka1: {0} Model2: {1}\n",
                mojeSamochody[0].Marka, mojeSamochody[1].Nazwa);
            Console.WriteLine("Rysowanie choinki \nPodaj liczbe: ");
            string odp = Console.ReadLine();
            int n = 0;
            if (Int32.TryParse(odp, out n)) //parsowanie zmiennej
            {
                int[][] tab = new int[n][];
                for (int i = 0; i < n; i++)
                {
                    tab[i] = new int[i * 2]; //tworzenie tablicy wyszczerbionej
                    for (int j = 0; j < n - i; j++)
                        Console.Write(" ");
                    foreach (var item in tab[i])
                        Console.Write(item);
                    Console.WriteLine();
                }
                Console.ReadKey();
            }
        }
        public class Samochody
        {
            private List<Auto> samochody;
            public Auto this[int id]
            {
                get { return samochody[id]; }
                set { samochody[id] = value; }
            }
            public static Samochody operator +(Samochody s, Auto a)
            {
                if (s.samochody == null)
                    s.samochody = new List<Auto>();
                s.samochody.Add(a);
                return s;
            }
            public void Wypisz()
            {
                foreach (var item in samochody)
                    Console.WriteLine("{0} {1}", item.Nazwa, item.Marka);
            }
            public static void Porownaj(string txt)
            {
                Console.WriteLine("Porównianie {1} i te st zwraca {0}",
                    txt.CompareTo("te st"), txt);
                Console.WriteLine("Porównianie {1} i Test zwraca {0}",
                    txt.CompareTo("Test"), txt);
                Console.WriteLine("Porównianie {1} i test zwraca {0}",
                    txt.CompareTo("test"), txt);
            }
        }

        public class Auto
        {
            public string Nazwa { get; set; }
            private string marka;
            public string Marka
            {
                get { return marka; }
                set { marka = value; }
            }
            public Auto() { }
            public Auto(string Nazwa, string Marka)
            {
                this.Marka = Marka;
                this.Nazwa = Nazwa;
            }
        }
    }
}