using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewSale.Common.Exceptions
{
    public class NewSaleException 
        : Exception
    {
        public NewSaleException()
        {
        }

        public NewSaleException(string code, string message)
            : base(message)
        {
            this.Code = code;
        }

        public string Code { get; set; }
    }
}
