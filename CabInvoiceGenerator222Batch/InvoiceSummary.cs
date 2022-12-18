using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabInvoiceGenerator222Batch
{
    public class InvoiceSummary
    {
        public double totalFare;
        public int numberOfRides;
        public double average;
        public InvoiceSummary(double totalFare, int numberOfRides)
        {
            this.totalFare = totalFare;
            this.numberOfRides = numberOfRides;
            this.average = totalFare / numberOfRides;
        }
        public override bool Equals(object obj)
        {
            if(obj == null) //any1 object if null then return false ,test will fail so both object should have some data in order to check equality. 
            {
                return false;
            }
            if(obj is not InvoiceSummary)    //whether InvoiceSummary is a child class of object class or not .
            {
                return false;
            }
            InvoiceSummary inputedObject = (InvoiceSummary)obj;
            return this.numberOfRides == inputedObject.numberOfRides && this.totalFare == inputedObject.totalFare;
        }
    }
}