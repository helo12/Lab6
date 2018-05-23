using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;
using ToolsCSharp;

using DBDataReader = System.Data.SqlClient.SqlDataReader;
using System.Data.SqlClient;

namespace Lab6PropClasses
{
    [Serializable()]
    public class CustomerProp : IBaseProps
    {
        /*[CustomerID]
      ,[Name]
      ,[Address]
      ,[City]
      ,[State]
      ,[ZipCode]
      ,[ConcurrencyID]*/
        #region instance variables
        /// <summary>
        /// 
        /// </summary>
        public int ID = Int32.MinValue;



        /// <summary>
        /// 
        /// </summary>
        public string Name = "";

        /// <summary>
        /// 
        /// </summary>
        public string Address = "";

        /// <summary>
        /// 
        /// </summary>
        public string City = "";
        /// <summary>
        /// 
        /// </summary>
        public string State = "";

        /// <summary>
        /// 
        /// </summary>
        public string Zipcode = "";
        /// <summary>
        /// ConcurrencyID. See main docs, don't manipulate directly
        /// </summary>
        public int ConcurrencyID=0;
        #endregion
        public object Clone()
        {
            CustomerProp p = new CustomerProp();
            p.ID = this.ID;
            p.Name = this.Name;
            p.Address = this.Address;
            p.City = this.City;
            p.State = this.State;
            p.Zipcode = this.Zipcode;
            p.ConcurrencyID = this.ConcurrencyID;
            return p;
        }

        public string GetState()
        {
            XmlSerializer serializer = new XmlSerializer(this.GetType());
            StringWriter writer = new StringWriter();
            serializer.Serialize(writer, this);
            return writer.GetStringBuilder().ToString();
        }

        public void SetState(string xml)
        {
            XmlSerializer serializer = new XmlSerializer(this.GetType());
            StringReader reader = new StringReader(xml);
            CustomerProp p = (CustomerProp)serializer.Deserialize(reader);
            this.ID = p.ID;
            this.Name = p.Name;
            this.Address = p.Address;
            this.City = p.City;
            this.State = p.State;
            this.Zipcode = p.Zipcode;
            this.ConcurrencyID = p.ConcurrencyID;
        }

        public void SetState(DBDataReader dr)
        {
            this.ID = (Int32)dr["CustomerID"];
            this.Name = (string)dr["Name"];
            this.Address = (string)dr["Address"];
            this.City = (string)dr["City"];
            this.State = (string)dr["State"];
            this.Zipcode = (string)dr["ZipCode"];
            this.ConcurrencyID = (Int32)dr["ConcurrencyID"];
        }
    }
}
