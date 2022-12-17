using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabInvoiceGenerator222Batch
{
    public class Ride
    {
        public double distance;
        public int time;
        public RideType type;
        public readonly int MINIMUM_FARE;
        public readonly int DISTANCE_PER_KM;
        public readonly int COST_PER_MIN;

        public Ride(double distance, int time,RideType rideType) 
        {
            this.distance= distance;
            this.time= time;
            type=rideType;

            if (this.type == RideType.NORMAL)
            {
                MINIMUM_FARE = 5;
                COST_PER_MIN = 1;
                DISTANCE_PER_KM = 10;
            }
            else
            {
                MINIMUM_FARE = 20;
                COST_PER_MIN = 2;
                DISTANCE_PER_KM = 15;
            }
        }
    }
}
