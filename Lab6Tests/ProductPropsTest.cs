using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Lab6PropClasses;
using Lab6DBClasses;
using ToolsCSharp;
namespace Lab6Tests
{
    [TestFixture]
    class ProductPropsTest
    {
        ProductProps p;
        ProductProps p1;
        
        
        [SetUp]
        public void SetUp()
        {
            p = new ProductProps();
            
            p.code = "TEST";
            p.description = "REEEEE";
            p.ID = 1234;
            p.quanitity = 2;
            p.unitPrice = 99;

            p1 = new ProductProps();
        }
        [Test]
        public void TestGetState()
        {
            string xml = p.GetState();

            Assert.True(xml.Length>0);
            Assert.True(xml.Contains(p.description ));
            Console.WriteLine(xml);
        }

        [Test]
        public void TestSetState()
        {
            string xml = p.GetState();
            p1.SetState(xml);

            Assert.True(xml == p1.GetState());
        }

    
    }
}
