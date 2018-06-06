using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using ToolsCSharp;
using ProdcuctDB = Lab6DBClasses.ProductDB;
using Lab6PropClasses;


namespace Lab6Classes
{
    public class Product : BaseBusiness

    {
        #region properties
        /// <summary>
        /// Read-only ID property.
        /// </summary>
        public int ID
        {
            get
            {
                return ((ProductProps)mProps).ID;
            }
        }

        /// <summary>
        /// Read/Write property. 
        /// </summary>
        public string Code
        {
            get
            {
                return ((ProductProps)mProps).code;
            }

            set
            {
                if (!(value == ((ProductProps)mProps).code))
                {
                    if (value.Trim().Length < 10)
                    {
                        mRules.RuleBroken("ProductCode", false);
                        ((ProductProps)mProps).code = value;
                        mIsDirty = true;
                    }

                    else
                    {
                        throw new ArgumentOutOfRangeException("Product Code must be in an acceptable format");
                    }
                }
            }
        }
        public string Description
        {
            get
            {
                return ((ProductProps)mProps).description;
            }
            set
            {
                if (!(value == ((ProductProps)mProps).description))
                {
                    if (value.Length >= 1 && value.Length <= 50)
                    {
                        mRules.RuleBroken("Description", false);
                        ((ProductProps)mProps).description = value;
                        mIsDirty = true;
                    }

                    else
                    {
                        throw new ArgumentException("Title must be between 1 and 50 characters");
                    }
                }
            }
        }
        public override object GetList()
        {
            List<Product> products = new List<Product>();
            List<ProductProps> props = new List<ProductProps>();


            props = (List<ProductProps>)mdbReadable.RetrieveAll(props.GetType());
            foreach (ProductProps prop in props)
            {
                Product e = new Product(prop, this.mConnectionString);
                products.Add(e);
            }

            return products;
        }

        protected override void SetDefaultProperties()
        {
            //throw new NotImplementedException();
        }


        protected override void SetRequiredRules()
        {
            //mRules.RuleBroken("ProductID", true);
            mRules.RuleBroken("ProductCode", true);
            mRules.RuleBroken("Description", true);
        }

        protected override void SetUp()
        {
            mProps = new ProductProps();
            mOldProps = new ProductProps();

            if (this.mConnectionString == "")
            {
                mdbReadable = new ProdcuctDB();
                mdbWriteable = new ProdcuctDB();
            }

            else
            {
                mdbReadable = new ProdcuctDB(this.mConnectionString);
                mdbWriteable = new ProdcuctDB(this.mConnectionString);
            }
        }

        /// <summary>
        /// Default constructor - does nothing.
        /// </summary>
        public Product() : base()
        {
        }

        /// <summary>
        /// One arg constructor.
        /// Calls methods SetUp(), SetRequiredRules(), 
        /// SetDefaultProperties() and BaseBusiness one arg constructor.
        /// </summary>
        /// <param name="cnString">DB connection string.
        /// This value is passed to the one arg BaseBusiness constructor, 
        /// which assigns the it to the protected member mConnectionString.</param>
        public Product(string cnString)
            : base(cnString)
        {
        }

        /// <summary>
        /// Two arg constructor.
        /// Calls methods SetUp() and Load().
        /// </summary>
        /// <param name="key">ID number of a record in the database.
        /// Sent as an arg to Load() to set values of record to properties of an 
        /// object.</param>
        /// <param name="cnString">DB connection string.
        /// This value is passed to the one arg BaseBusiness constructor, 
        /// which assigns the it to the protected member mConnectionString.</param>
        public Product(int key, string cnString)
            : base(key, cnString)
        {
        }

        public Product(int key)
            : base(key)
        {
        }

        // *** I added these 2 so that I could create a 
        // business object from a properties object
        // I added the new constructors to the base class
        public Product(ProductProps props)
            : base(props)
        {
        }

        public Product(ProductProps props, string cnString)
            : base(props, cnString)
        {
        }
        public static DataTable GetTable(string cnString)
        {
            Type t = null;
            ProdcuctDB db = new ProdcuctDB(cnString);
            return (DataTable)(db.RetrieveAll(t));
        }

        public static DataTable GetTable()
        {
            Type t = null;
            ProdcuctDB db = new ProdcuctDB();
            return (DataTable)(db.RetrieveAll(t));
        }

        /// <summary>
        /// Deletes the customer identified by the id.
        /// </summary>
        public static void Delete(Product id)
        {
            ProdcuctDB db = new ProdcuctDB();
            db.Delete((IBaseProps)id);
        }

        public static void Delete(Product id, string cnString)
        {
            ProdcuctDB db = new ProdcuctDB(cnString);
            db.Delete((IBaseProps)id);
        }
    }

}
#endregion