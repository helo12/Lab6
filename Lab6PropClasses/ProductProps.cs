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
    public class ProductProps : IBaseProps
    {
        #region instance variables
        /// <summary>
        /// 
        /// </summary>
        public int ID = Int32.MinValue;



        /// <summary>
        /// 
        /// </summary>
        public string code = "";

        /// <summary>
        /// 
        /// </summary>
        public string description = "";

        /// <summary>
        /// 
        /// </summary>
        public int quanitity = Int32.MinValue;
        /// <summary>
        /// 
        /// </summary>
        public decimal unitPrice = decimal.MinValue;

        /// <summary>
        /// ConcurrencyID. See main docs, don't manipulate directly
        /// </summary>
        public int ConcurrencyID = 0;
        #endregion
        public object Clone()
        {
            ProductProps p = new ProductProps();
            p.ID = this.ID;
            p.code = this.code;
            p.description = this.description;
            p.quanitity = this.quanitity;
            p.unitPrice = this.unitPrice;
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
            ProductProps p = (ProductProps)serializer.Deserialize(reader);
            this.ID = p.ID;
            this.code = p.code;
            this.description = p.description;
            this.quanitity = p.quanitity;
            this.unitPrice = p.unitPrice;
            this.ConcurrencyID = p.ConcurrencyID;
        }

        public void SetState(DBDataReader dr)
        {
            this.ID = (Int32)dr["ProductID"];
            this.code = (string)dr["ProductCode"]; 
            this.description = (string)dr["Description"];
            this.quanitity = (Int32)dr["OnHandQuantity"];
            this.unitPrice = (decimal)dr["UnitPrice"];
            this.ConcurrencyID = (Int32)dr["ConcurrencyID"];
        }
    }
}
