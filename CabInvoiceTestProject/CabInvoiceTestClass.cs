using CabInvoiceGenerator222Batch;
using System.Data;

namespace CabInvoiceTestProject
{
    [TestClass]
    public class CabInvoiceTestClass
    {
        [TestMethod]
        //[DataRow(4,2,RideType.NORMAL,42)]   //Step 1  (Calculate Fare -Normal Ride)
        public void Given_Distance_And_Time_Should_Return_TotalFare()
        {
            //4*10+2*1=42
            Ride ride = new Ride(4, 2, RideType.NORMAL);
            CabInvoiceGenerator invoiceGenerator = new CabInvoiceGenerator();
            double actual=invoiceGenerator.CalculateTotalFare(ride);
            Assert.AreEqual(actual,42);
        }

        [TestMethod]
        //[DataRow(-4, 2, RideType.NORMAL)]   //Wrong input shall throw custome exception .
        public void Given_WrongDistance_And_Time_Should_Throw_CustomException()
        {
            Ride ride = new Ride(-4, 2, RideType.NORMAL);
            CabInvoiceGenerator invoiceGenerator = new CabInvoiceGenerator();
            var actual = Assert.ThrowsException<CabInvoiceCustomException> (()=>invoiceGenerator.CalculateTotalFare(ride));
            Assert.AreEqual(actual.Message , "Invalid distance");
            //Assert.AreEqual(actual.exceptionTypes , CabInvoiceCustomException.ExceptionTypes.INVALID_DISTANCE );
        }

        //[TestMethod]    //Step 5 - Premium Rides (supports two types of Rides)
        //public void Given_MultipleRides_Should_Return_TotalFare()
        //{
        //    Ride[] rides = new Ride[]
        //    {
        //        new Ride(1,2,RideType.NORMAL),  //10+2=12    +
        //        new Ride(2,1,RideType.PREMIUM)  //30+2=32       //44
        //    };
        //    CabInvoiceGenerator invoiceGenerator = new CabInvoiceGenerator();
        //    double actual = invoiceGenerator.CalculateTotalFare(rides); //method return type later changed as per next UC requirement .
        //                                                                //(so this will not be working in later UCs.If wanted to show demo then open old/previous UC and explain .
        //    Assert.AreEqual(actual, 44);
        //}
        [TestMethod]
        public void Given_MultipleRides_Should_Return_Object()  //Object comparison test .
        {
            Ride[] rides = new Ride[]
            {
                new Ride(1,2,RideType.NORMAL),  //10+2=12    +
                new Ride(2,1,RideType.PREMIUM)  //30+2=32       //44
            };
            InvoiceSummary expectedObj = new InvoiceSummary(44, rides.Length);
            CabInvoiceGenerator invoiceGenerator = new CabInvoiceGenerator();
            InvoiceSummary actual = invoiceGenerator.CalculateTotalFare(rides);
            Assert.AreEqual(expectedObj, actual);
            //Here Assert.AreEqual() and obj.Equals() both are not able to providing expected output .
            //so in order to resolve this we have to override the parent's class Equals() and implement as per our expectations .
        }
    }
}