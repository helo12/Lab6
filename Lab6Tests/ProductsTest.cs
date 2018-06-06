using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NUnit.Framework;
using Lab6Classes;
using Lab6DBClasses;
using System.Data;
using ToolsCSharp;

using DBCommand = System.Data.SqlClient.SqlCommand;
using ProductDB = Lab6DBClasses.ProductDB;
namespace Lab6Tests
{
    [TestFixture]
    class ProductsTest
    {
        private string dataSource = "Data Source=1912831-C20231;Initial Catalog=MMABooksUpdated;Integrated Security=True";
        ProductDB DB;
        Product p;
        Product p2;
        [SetUp]
        public void ResetData()
        {
            DB = new ProductDB(dataSource);
            DBCommand command = new DBCommand();
            command.CommandText = "usp_testingProductResetData";
            command.CommandType = CommandType.StoredProcedure;
            DB.RunNonQueryProcedure(command);

            
        }

        [Test]
        public void LoadFromDataBase()
        {
            p = new Product(1, dataSource);
            Assert.AreEqual(1, p.ID);
            Assert.AreEqual("ABCD", p.Code.Trim());
        }
        [Test]
        public void TestCreate()
        {
            p = new Product(dataSource);
            p.Code = "TEST";
            p.Description = "This is a test";

            p.Save();
            Product p2 = new Product(p.ID, dataSource); 
            Assert.True(p.Code == p2.Code);
        }
        //The fact that this throws a null ref means that this is working correctly
        [Test]
        public void TestDelete()
        {
            p.Delete();
            p.Save();
            Assert.True(DB.Retrieve(p) == null);

        }

    }
}
