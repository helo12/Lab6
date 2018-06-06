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
    class CustomerTest
    {
        private string dataSource = "Data Source=1912831-C20231;Initial Catalog=MMABooksUpdated;Integrated Security=True";
        CustomerDB DB;
        Customer p;
        Customer p2;
        [SetUp]
        public void Setup()
        {
            DB = new CustomerDB(dataSource);
            DBCommand command = new DBCommand();
            command.CommandText = "usp_testingCustomerResetData";
            command.CommandType = CommandType.StoredProcedure;
            DB.RunNonQueryProcedure(command);
        }

        [Test]
        public void TestCreate()
        {
            p = new Customer(dataSource);
            p.City = "TEST";
            p.Name = "Irene";
            p.States = "OR";
            p.Save();
            Customer p2 = new Customer(p.ID, dataSource);
            Assert.True(p.Name == p2.Name);
        }
    }
}
