using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleDT5
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    public class Osoba
    {
        public String Imie { get; set; }
        public String Nazwisko { get; set; }
        public int RokUrodzenia { get; set; }
        public virtual String Stanowisko { get { return ""; } }
        public Osoba(string imie, string nazwikso, int rokUrodzenia)
        {
            Imie = imie;
            Nazwisko = nazwikso;
            RokUrodzenia = rokUrodzenia;
        }
        public virtual string Informacje() { return null; }
        public virtual double JakaPensja() { return 0; }
    }

    public class PracownikFizyczny : Osoba
    {
        public double StawkaGodzinowa { get; set; }
        public int LiczbaPrzepracowanychGodzin { get; set; }
        public int LiczbaNadgodzin { get; set; }
        public Kierownik Kierownik { get; set; }
        public string Umiejetnosci { get; set; }
        public override String Stanowisko { get { return "Pracownik Fizyczny"; } }
        public PracownikFizyczny(string imie, string nazwikso, int rokUrodzenia, double stawka, int liczbaPrzepracGodzin, int liczbaNadgodzin, Kierownik kierownik, string umiejetnosci)
            : base(imie, nazwikso, rokUrodzenia)
        {
            StawkaGodzinowa = stawka;
            LiczbaPrzepracowanychGodzin = liczbaPrzepracGodzin;
            LiczbaNadgodzin = liczbaNadgodzin;
            Kierownik = kierownik;
            Umiejetnosci = umiejetnosci;
        }
        public override string Informacje()
        {
            return String.Format("Stanowisko:{9}\n{0} {1}\n Rok urodzenia: {2}, Stawka godzinowa {3}\nLiczba przepracowanych godzin {4}, Liczba nadgodzin {5}\nKierownik: {6} {7}\n Umiejetnosci {8}\n",
                Imie, Nazwisko, RokUrodzenia, StawkaGodzinowa, LiczbaPrzepracowanychGodzin, LiczbaNadgodzin, Kierownik.Imie, Kierownik.Nazwisko, Umiejetnosci, Stanowisko);
        }
        public override double JakaPensja()
        {
            return StawkaGodzinowa * LiczbaPrzepracowanychGodzin + StawkaGodzinowa * 1.5 * LiczbaNadgodzin;
        }
    }

    public class PracownikUmyslowy : Osoba
    {
        public double PensjaMiesieczna { get; set; }
        public double ProcentPremii { get; set; }
        public Kierownik Kierownik { get; set; }
        public int NrTelefonu { get; set; }
        public string NrPokoju { get; set; }
        public override String Stanowisko { get { return "Pracownik Umyslowy"; } }
        public PracownikUmyslowy(string imie, string nazwikso, int rokUrodzenia, double pensjaMiesieczna, double procentPremii, Kierownik kierownik, int nrTelefonu, string nrPokoju)
            : base(imie, nazwikso, rokUrodzenia)
        {
            PensjaMiesieczna = pensjaMiesieczna;
            ProcentPremii = procentPremii;
            Kierownik = kierownik;
            NrTelefonu = nrTelefonu;
            NrPokoju = nrPokoju;
        }
        public override string Informacje()
        {
            return String.Format("Stanowisko:{9}\n{0} {1}\n Rok urodzenia: {2}, Pensja miesieczna {3}\nProcent premii {4},\nKierownik: {5} {6}\nNr Telefonu {7}\nNr Pokoju{8}",
                Imie, Nazwisko, RokUrodzenia, PensjaMiesieczna, ProcentPremii, Kierownik.Imie, Kierownik.Nazwisko, NrTelefonu, NrPokoju, Stanowisko);
        }
        public override double JakaPensja()
        {
            return PensjaMiesieczna + ProcentPremii * PensjaMiesieczna;
        }
    }

    public class Kierownik : PracownikUmyslowy
    {
        public double KwotaDodatkuKierowniczego { get; set; }
        public int NrKomorkowy { get; set; }
        public string NazwaDzialu { get; set; }
        public override String Stanowisko { get { return "Kierownik"; } }
        public Kierownik(string imie, string nazwikso, int rokUrodzenia, double pensjaMiesieczna, double procentPremii, double kwotaDodatku, int nrTelefonu, int nrKomorkowy, string nrPokoju, string nazwaDzialu)
            : base(imie, nazwikso, rokUrodzenia, pensjaMiesieczna, procentPremii, null, nrTelefonu, nrPokoju)
        {
            KwotaDodatkuKierowniczego = kwotaDodatku;
            NrKomorkowy = nrKomorkowy;
            NazwaDzialu = nazwaDzialu;
        }
        public override string Informacje()
        {
            return String.Format("Stanowisko:{0}\n{1} {2}\n Rok urodzenia: {3}, Pensja miesieczna {4}\nProcent premii {5},\nDodatek kierowniczy: {6}\nNr Telefonu {7}\nNr Komorkowy {8}\nNr Pokoju{9}\nNazwa dzialu {10}",
                Stanowisko, Imie, Nazwisko, RokUrodzenia, PensjaMiesieczna, ProcentPremii, KwotaDodatkuKierowniczego, NrTelefonu, NrKomorkowy, NrPokoju, NazwaDzialu);
        }
        public override double JakaPensja()
        {
            return base.JakaPensja() + KwotaDodatkuKierowniczego;
        }
    }
    public class CzlonekZarzadu : Osoba
    {
        public double PensjaMiesieczna { get; set; }
        public Osoba Asystent { get; set; }
        public int LiczbaSpotkan { get; set; }
        public override String Stanowisko { get { return "Czlonek Zarzadu"; } }
        public CzlonekZarzadu(string imie, string nazwikso, int rokUrodzenia, double pensjaMiesieczna, Osoba asystent, int liczbaSpotkan)
            : base(imie, nazwikso, rokUrodzenia)
        {
            PensjaMiesieczna = pensjaMiesieczna;
            Asystent = asystent;
            LiczbaSpotkan = LiczbaSpotkan;
        }
        public override string Informacje()
        {
            return String.Format("Stanowisko:{0}\n{1} {2}\n Rok urodzenia: {3}, Pensja miesieczna {4}\nAsysten {5} {6}\n Liczba spotan rady nadzorczej {7}",
                Stanowisko, Imie, Nazwisko, RokUrodzenia, PensjaMiesieczna, Asystent.Imie, Asystent.Nazwisko, LiczbaSpotkan);
        }
        public override double JakaPensja()
        {
            return PensjaMiesieczna + LiczbaSpotkan * 100;//kwota za spotkanie
        }
    }
    public class Praktykant : Osoba
    {
        static private double Stypendium { get { return 1000.0; } }
        public bool CzyMaStypendium { get; set; }
        public override String Stanowisko { get { return "Praktykant"; } }
        public Osoba Opiekun { get; set; }
        public Praktykant(string imie, string nazwikso, int rokUrodzenia, bool czyStypendum, Osoba opiekun)
            : base(imie, nazwikso, rokUrodzenia)
        {
            CzyMaStypendium = czyStypendum;
            Opiekun = opiekun;
        }
        public override string Informacje()
        {
            string stypendium = "Stypendium: ";
            stypendium += CzyMaStypendium ? "1000" : "BRAK";
            return String.Format("Stanowisko:{0}\n{1} {2}\n Rok urodzenia: {3}, Opiekun {4} {5}\n{6}",
                Stanowisko, Imie, Nazwisko, RokUrodzenia, Opiekun.Imie, Opiekun.Nazwisko, stypendium);
        }
        public override double JakaPensja()
        {
            return CzyMaStypendium ? Stypendium : 0;
        }
    }
}

