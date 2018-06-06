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
    class CustomerDBTest
    {
        private string dataSource = "Data Source=1912831-C20231;Initial Catalog=MMABooksUpdated;Integrated Security=True";
        CustomerDB DB;
        CustomerProp p;
        [SetUp]
        public void SetUp()
        {
            DB = new CustomerDB(dataSource);
            p = new CustomerProp();

            p.Name = "TEST";
            p.Address="Test Address";
            p.City="REEEEEE";
            p.State = "OR";
        }

        [Test]
        public void TestCreateCustomer()
        {
            CustomerProp p2 = (CustomerProp)DB.Create(p);
            CustomerProp p3 = (CustomerProp)DB.Retrieve(p2.ID);
            Assert.True(p3.Name.Trim() == p.Name.Trim());
        }
        [Test]
        public void TestDelete()
        {
            p = (CustomerProp)DB.Retrieve(2);
            Assert.True(DB.Delete(p));
        }
        [Test]
        public void TestRetrieveProduct()
        {
            p = (CustomerProp)DB.Retrieve(3);
            Assert.True(p.Name == "TEST");
        }
        [Test]
        public void TestRetrieveAll()
        {
            int temp = 0;
            List<CustomerProp> testList = (List<CustomerProp>)(DB.RetrieveAll(temp.GetType()));
            for (int i = 0; i < testList.Count; i++)
            {
                Assert.True(testList[i].State == "OR");
            }
        }
        [Test]
        public void TestUpdate()
        {

        IBaseProps temp =    DB.Retrieve(2);
            p = (CustomerProp)temp;
            p.Name = "changed";
            Assert.True(DB.Update(p));
        }
    }
}
