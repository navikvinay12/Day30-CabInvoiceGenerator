using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabInvoiceGenerator222Batch
{
    public class CabInvoiceCustomException:Exception
    {
        public ExceptionTypes exceptionTypes;
        public enum ExceptionTypes
        {
            INVALID_DISTANCE,
            INVALID_TIME
        }
        public CabInvoiceCustomException(string message,ExceptionTypes exceptionTypes):base(message)
        {
            this.exceptionTypes= exceptionTypes;
        }
    }
}
