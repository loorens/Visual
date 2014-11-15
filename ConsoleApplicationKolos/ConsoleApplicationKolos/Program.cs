using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplicationKolos
{
    delegate void ZaCiezkie(Object o, ZaCiezkieEventArgs e);

    class Program
    {
        static void Main(string[] args)
        {
            Kontener<IElement> kontener = new Kontener<IElement>();
            kontener.zaCiezkie += delegate(Object o, ZaCiezkieEventArgs e)
            {
                Console.WriteLine("aaa");
            };
            kontener.zaCiezkie += (o, e) => 
            {
                var oo = o as Kontener<IElement>;
                Console.WriteLine("Tu ma coś być ... {0} {1}", oo.maxWaga , e.AktualnaWaga ); 
            };
            kontener.maxWaga = 5;

            kontener.Dodaj(new Kilo());
            kontener.Dodaj(new DwaKilo());
            kontener.Dodaj(new Kilo());
            kontener.Dodaj(new DwaKilo());
            kontener.Dodaj(new Kilo());
            kontener.Dodaj(new DwaKilo());


        }
    }


    interface IElement
    {
        int Waga { get; }
    }

    class DwaKilo : IElement
    {
        public int Waga
        {
            get { return 2; }
        }
    }

    class Kilo : IElement
    {
        public int Waga
        {
            get { return 1; }
        }
    }

    class ZaCiezkieEventArgs : EventArgs
    {
        private int aktualnaWaga;
        public int AktualnaWaga { 
            get
            {
                return aktualnaWaga;
            }
        
        }
        private List<int> Elementy;
        public ZaCiezkieEventArgs(int aktualnaWaga)
        {
            this.aktualnaWaga = aktualnaWaga;
        }
    }



    class Kontener<T>:IEnumerable<T>  where T : IElement
    {
        public int maxWaga { get; set; }


        private int aktWaga;
        List<T> elementy;
        public int AktualnaWaga { get { return aktWaga; } }

        public event ZaCiezkie zaCiezkie;


        public void Dodaj(T t)
        {
            if (elementy == null) elementy = new List<T>();
            elementy.Add(t);
            aktWaga += t.Waga;
            if (maxWaga < aktWaga)
            {
                zaCiezkie(this, new ZaCiezkieEventArgs(aktWaga));
            }
        }
        public T this[uint id]
        {
            set
            {
                elementy[(int)id] = value;
            }
            get
            {
                return elementy[(int)id];
            }
        }


    
        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return elementy.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return elementy.GetEnumerator();
        }
    }
}
