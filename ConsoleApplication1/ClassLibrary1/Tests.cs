using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Calculator;


namespace ClassLibrary1
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void TestMulti()
        {
            string sol = Calc.Multi("a", 3);
            Assert.AreEqual("aaa", sol);
        }
        [Test]
        [MaxTime(2100)]
        public void TestTime()
        {
            Calc.Sleep();


        }
        
    }
}
