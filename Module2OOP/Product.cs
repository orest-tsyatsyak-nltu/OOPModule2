using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module2OOP
{
    [Serializable]
    internal class Product : IComparable<Product>
    {

        private string _name;
        private DateTime _expirationDate;
        private string _manufacturerName;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }        

        public DateTime ExpirationDate
        {
            get { return _expirationDate; }
            set { _expirationDate = value; }
        }

        public string ManufacturerName
        {
            get { return _manufacturerName; }
            set { _manufacturerName = value; }
        }

        public Product(string name, DateTime expirationDate, string manufacturerName)
        {
            Name = name;
            ExpirationDate = expirationDate;
            ManufacturerName = manufacturerName;
        }

        public int CompareTo(Product other)
        {
            return string.Compare(Name, other.Name);
        }

        public override string ToString()
        {
            return Name + " " + ExpirationDate + " " + ManufacturerName;
        }
    }
}
