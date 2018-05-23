using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab6DBClasses;
using Lab6PropClasses;
using NUnit.Framework;
namespace Lab6Tests
{
    [TestFixture]
    class ProductDBTests
    {
        private string dataSource = "Data Source=1912831-C20231;Initial Catalog=MMABooksUpdated;Integrated Security=True";
        ProductDB DB;
        ProductProps p;
        [SetUp]
        public void SetUp()
        {
            DB = new ProductDB(dataSource);
            p = new ProductProps();
            
            p.code = "TEST";
            p.quanitity = 1;
            p.unitPrice = 1;
            p.description = "This is an updated test";
        }

        [Test]
        public void TestCreateProduct()
        {
            ProductProps p2 = (ProductProps)DB.Create(p);
            ProductProps p3 = (ProductProps)DB.Retrieve(p2.ID);
           Assert.True(p3.code.Trim() == p.code.Trim());
        }
        [Test]
        public void TestDelete()
        {
            p = (ProductProps)DB.Retrieve(6);
            Assert.True(DB.Delete(p));
        }
        [Test]
        public void TestRetrieveProduct()
        {
           p = (ProductProps)DB.Retrieve(7);
            Assert.True(p.code == "TEST      ");
        }
        [Test]
        public void TestRetrieveAll()
        {
            int temp=0;
            List<ProductProps> testList = (List<ProductProps>)(DB.RetrieveAll(temp.GetType()));
            for(int i = 0; i < testList.Count; i++)
            {
                Assert.True(testList[i].quanitity == 1);
            }
        }
        [Test]
        public void TestUpdate()
        {
            p = (ProductProps)DB.Retrieve(5);
            p.description = "This has been changed yay!";
            Assert.True(DB.Update(p));
        }

    }
}
