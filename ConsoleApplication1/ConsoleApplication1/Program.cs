using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Calculator
{
    public class Calc
    {
        static void Main(string[] args)
        {
        }

        public static string Multi(string text, int n)
        {
            string r = "";
            for (int i = 0; i < n; i++)
            {
                r += text;
            }
            return r;
        }
        public static int Square(int n)
        {
            return n * n;
        }
        public static void Sleep()
        {
            Thread.Sleep(2000);
        }

    }
}
