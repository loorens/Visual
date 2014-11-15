using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    class Program
    {
        static void Main(string[] args)
        {
            MyClass m = new MyClass();
            MyClass2 m2 = new MyClass2();
            
            
        }
    }

    public class MyClass
    {
        public int A;
        private int B;
        protected int C;
    }

    public class MyClass2 : MyClass
    {
        
    }

}
