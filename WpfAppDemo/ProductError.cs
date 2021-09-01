using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppDemo
{
    public partial class Product : IDataErrorInfo
    {
        public string this[string columnName]
        {
            get
            {
                string result = string.Empty;
                if (columnName == "ProductName")
                {
                    if (ProductName == "")
                    {
                        result = "Product name cannot be empty";
                    }
                }
                return result;
            }
        }

        public string Error => null;
    }
}
