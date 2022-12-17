using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabInvoiceGenerator222Batch
{
    public class CabInvoiceGenerator
    {
        public double CalculateTotalFare(Ride ride)
        {
            double totalFare;
            if (ride.distance <= 0)
            {
                throw new CabInvoiceCustomException("Invalid distance",CabInvoiceCustomException.ExceptionTypes.INVALID_DISTANCE);
            }
            else if (ride.time <= 0)
            {
                throw new CabInvoiceCustomException("Invalid time", CabInvoiceCustomException.ExceptionTypes.INVALID_TIME);
            }
            else
            {
                totalFare = ride.distance * ride.DISTANCE_PER_KM + ride.time * ride.COST_PER_MIN;
                return Math.Max(totalFare, ride.MINIMUM_FARE);
            }
        }
        public double CalculateTotalFare(Ride[] rides)
        {
            double totalFare=0;
            foreach(Ride ride in rides)
            {
                totalFare += CalculateTotalFare(ride);
            }
            return totalFare;
        }
    }
}
