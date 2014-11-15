using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrzewoDecyzyjne
{
    class CDrzewo
    {
        public int nrWezla;
        public int odpTak, odpNie;
        public String Tytul, Tekst;
        public CDrzewo(int id=0, int tak=0, int nie=0, String tyt="", String tek="")
        {
            nrWezla = id;
            odpTak = tak;
            odpNie = nie;
            Tytul = tyt;
            Tekst = tek;
        }
    }

    
}
