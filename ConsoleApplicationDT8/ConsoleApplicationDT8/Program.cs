using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace ConsoleApplicationDT88
{
    class Program
    {
        static void Main(string[] args)
        {
            Assembly a = null;
            try
            {
                a = Assembly.Load("PrzykladowaBiblioteka");
                Type samochodType = a.GetType("PrzykladowaBiblioteka.Samochod");
                object samochod = Activator.CreateInstance(samochodType);
                MethodInfo uruchomMethod = samochodType.GetMethod("Uruchom");
                uruchomMethod.Invoke(samochod, null);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }
            finally
            {
                Console.ReadKey();
            }
        }
    }
}