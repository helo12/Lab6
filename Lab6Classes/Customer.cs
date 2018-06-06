using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using ToolsCSharp;
using CustomerDB = Lab6DBClasses.CustomerDB;
using Lab6PropClasses;


namespace Lab6Classes
{
    public class Customer : BaseBusiness

    {
        #region properties
        /// <summary>
        /// Read-only ID property.
        /// </summary>
        public int ID
        {
            get
            {
                return ((CustomerProp)mProps).ID;
            }
        }

        /// <summary>
        /// Read/Write property. 
        /// </summary>
        public string Name
        {
            get
            {
                return ((CustomerProp)mProps).Name;
            }

            set
            {
                if (!(value == ((CustomerProp)mProps).Name))
                {
                    if (value.Trim().Length < 10)
                    {
                        mRules.RuleBroken("Name", false);
                        ((CustomerProp)mProps).Name = value;
                        mIsDirty = true;
                    }

                    else
                    {
                        throw new ArgumentOutOfRangeException("Customer Name must be in an acceptable format");
                    }
                }
            }
        }
        public string City
        {
            get
            {
                return ((CustomerProp)mProps).City;
            }
            set
            {
                if (!(value == ((CustomerProp)mProps).City))
                {
                    if (value.Length >= 1 && value.Length <= 50)
                    {
                        mRules.RuleBroken("City", false);
                        ((CustomerProp)mProps).City = value;
                        mIsDirty = true;
                    }

                    else
                    {
                        throw new ArgumentException("Title must be between 1 and 50 characters");
                    }
                }
            }
        }

        public string States
        {
            get
            {
                return ((CustomerProp)mProps).State;
            }
            set
            {
                if (!(value == ((CustomerProp)mProps).State))
                {
                    if (value.Length >= 1 && value.Length <= 50)
                    {
                        mRules.RuleBroken("State", false);
                        ((CustomerProp)mProps).State = value;
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
            List<Customer> customers = new List<Customer>();
            List<CustomerProp> props = new List<CustomerProp>();


            props = (List<CustomerProp>)mdbReadable.RetrieveAll(props.GetType());
            foreach (CustomerProp prop in props)
            {
                Customer e = new Customer(prop, this.mConnectionString);
                customers.Add(e);
            }

            return customers;
        }

        protected override void SetDefaultProperties()
        {
           // throw new NotImplementedException();
        }


        protected override void SetRequiredRules()
        {
           // mRules.RuleBroken("ProductID", true);
            mRules.RuleBroken("Name", true);
            mRules.RuleBroken("City", true);
            mRules.RuleBroken("State", true);
        }

        protected override void SetUp()
        {
            mProps = new CustomerProp();
            mOldProps = new CustomerProp();

            if (this.mConnectionString == "")
            {
                mdbReadable = new CustomerDB();
                mdbWriteable = new CustomerDB();
            }

            else
            {
                mdbReadable = new CustomerDB(this.mConnectionString);
                mdbWriteable = new CustomerDB(this.mConnectionString);
            }
        }

        /// <summary>
        /// Default constructor - does nothing.
        /// </summary>
        public Customer() : base()
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
        public Customer(string cnString)
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
        public Customer(int key, string cnString)
            : base(key, cnString)
        {
        }

        public Customer(int key)
            : base(key)
        {
        }

        // *** I added these 2 so that I could create a 
        // business object from a properties object
        // I added the new constructors to the base class
        public Customer(CustomerProp props)
            : base(props)
        {
        }

        public Customer(CustomerProp props, string cnString)
            : base(props, cnString)
        {
        }
        public static DataTable GetTable(string cnString)
        {
            Type t = null;
            CustomerDB db = new CustomerDB(cnString);
            return (DataTable)(db.RetrieveAll(t));
        }

        public static DataTable GetTable()
        {
            Type t = null;
            CustomerDB db = new CustomerDB();
            return (DataTable)(db.RetrieveAll(t));
        }

        /// <summary>
        /// Deletes the customer identified by the id.
        /// </summary>
        public static void Delete(Customer id)
        {
            CustomerDB db = new CustomerDB();
            db.Delete((IBaseProps)id);
        }

        public static void Delete(Customer id, string cnString)
        {
            CustomerDB db = new CustomerDB(cnString);
            db.Delete((IBaseProps)id);
        }
    }

}
#endregion