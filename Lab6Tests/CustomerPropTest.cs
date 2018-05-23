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
    class CustomerPropTest
    {
        CustomerProp p;
        CustomerProp p1;


        [SetUp]
        public void SetUp()
        {
            p = new CustomerProp();

            p.ID = 1234;
            p.Name = "TEST";
            p.Address = "REEEEE";
            p.City = "Eugene";
            p.State = "OR";
            p.Zipcode = "97402";
            p.ConcurrencyID = 1;

            p1 = new CustomerProp();
        }
        [Test]
        public void TestGetState()
        {
            string xml = p.GetState();

            Assert.True(xml.Length > 0);
            Assert.True(xml.Contains(p.City));
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
