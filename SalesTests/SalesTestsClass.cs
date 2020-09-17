using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Sales;

namespace SalesTests
{
    //Example Flight is (economyRows = 20, int economySeats = 160, int firstClassRows = 5, int firstClassSeats = 20)
    //Total seats 160 + 20 = 180

    //private const double EconomyCharge = 1000.00
    //private const double FirstClassCharge = 2000.00

    //private const double AsiaWorldDiscount = 0.90 GlobalWorldDiscount = 0.80

    //private int memberType
    //private int memberCode
    //constants const int NonMember = 0 AsiaWorld = 1 GlobalWorld = 2

    //private int priceCode
    /*Constants const int Economy = 0 FirstClass = 1*/


    [TestFixture]
    public class SalesTestsClass
    {
        Sales.Flight testFlightObj;
        Sales.Invoice testInvoiceObj, testInvoiceObj1, testInvoiceObj2, testInvoiceObj3;
        Sales.Customer testCustObj, testCustObj1, testCustObj2, testCustObj3;
        Sales.Seat testSeatObj;
        Sales.Activity testActivityObj;

        [SetUp]
        public void Init()
        {

            //Flight(int economyRows, int economySeats, int firstClassRows, int firstClassSeats)
            testFlightObj = new Sales.Flight(20, 160, 5, 20);

            //Activity(Flight theFlight)
            testActivityObj = new Sales.Activity(testFlightObj);

            //Customer(int memberType, String firstName, String lastName, String creditNumber, String creditType, String expiry)
            testCustObj = new Sales.Customer(1, "Raja", "Arumuga", "1000200030004000", "Visa", "11/22");
            testCustObj1 = new Sales.Customer(1, "KT", "Lau", "1000200030004000", "Visa", "01/20");

            //Invoice(int priceCode, Customer theCust, int rowNum, int startSeatNum, int seatsBooked)
            testInvoiceObj = new Sales.Invoice(0, testCustObj, 1, 1, 2);
            testInvoiceObj1 = new Sales.Invoice(0, testCustObj, 1, 1, 2);
            testInvoiceObj2 = new Sales.Invoice(1, testCustObj, 1, 1, 2);
            testInvoiceObj3 = new Sales.Invoice(1, testCustObj1, 1, 1, 2);

            //Seat(int numAvail, int code) code is priceCode
            testSeatObj = new Sales.Seat(160, 0);

    }


    //Test Case: 1 ******Four test cases on seats taken (e.g. the calculations of seats and discount)***************************************************
    [Test]
        //double getDiscount(int memberCode)
        public void a1_IsDiscountCorrect()
        {
            double actual1 = testInvoiceObj.getDiscount(1);          
            double expected1 = 0.9;

            //discount rate for AsiaWorldMember AreEqual to 0.9
            Assert.AreEqual(expected1, actual1, "Discount rate not correct");         
        }

        [Test]
        public void a2_IsDiscountCorrect()
        {           
            double actual2 = testInvoiceObj.getDiscount(0);
            double expected2 = 1;

            //discount rate for Non-member AreEqual to 1
            Assert.AreEqual(expected2, actual2, "Discount rate not correct");
        }

        [Test]
        public void a3_IsDiscountCorrect()
        {           
            double actual3 = testInvoiceObj.getDiscount(-1);            
            double expected3 = 1;

            //discount rates for out-of-range member code AreEqual to Non-member's discount rate
            Assert.AreEqual(expected3, actual3, "Discount rate not correct");
        }


//Test Case:2 ****Four test cases on seats taken (e.g. the calculations of seats and discount)********************************************************
        [Test]
        //Boolean bookSeats(int num)
        public void b1_IsbookAllSeatsSuccessful()
        {
            bool actual = testSeatObj.bookSeats(10);

            //book 10 seats in economy class is successful
            Assert.IsTrue(actual, "Booking seats unsuccessful");
        }

        [Test]
        public void b2_IsbookAllSeatsSuccessful()
        {
            bool actual = testSeatObj.bookSeats(160);

            //book 160 seats in economy class is UNsuccessful
            Assert.IsTrue(actual, "Booking seats unsuccessful");
        }

        [Test]
        public void b3_IsbookAllSeatsSuccessful()
        {
            bool actual = testSeatObj.bookSeats(200);

            //book 200 seats in economy class is UNsuccessful
            Assert.IsFalse(actual, "Booking seats successful");
        }


//Test Case: 3 ******Four test cases on seats taken (e.g. the calculations of seats and discount)*********************************************************
        //Boolean bookSeats(int priceCode, int number, Customer theCustomer) number is seat number
        [Test]
        public void c1_IsActivitybookSeatsSuccessful()
        {
            bool actual = testActivityObj.bookSeats(0, 64, testCustObj);

            //book 64 seats in economy class is successful
            Assert.IsTrue(actual, "Booking seats to a economy customer is unsuccessful");
        }

        [Test]
        public void c2_IsActivitybookSeatsSuccessful()
        {
            bool actual = testActivityObj.bookSeats(1, 21, testCustObj);

            //book 21 seats in first class is UNsuccessful
            Assert.IsFalse(actual, "Booking seats to a first class customer is successful");
        }

        [Test]
        public void c3_IsActivitybookSeatsSuccessful()
        {
            bool actual = testActivityObj.bookSeats(1, 10, testCustObj);

            //book 10 seats in first class is successful
            Assert.IsTrue(actual, "Booking seats to a first class customer is unsuccessful");
        }



        //Test Case: 4 ******Four test cases on seats taken (e.g. the calculations of seats and discount)********************************************************
        //Invoice getCustomerBooking(Customer cust) returns the given booked customer's Invoice
        //Boolean bookSeats(int priceCode, int number, Customer theCustomer)number is total number of seats booked
        //Invoice(int priceCode, Customer theCust, int rowNum, int startSeatNum, int seatsBooked)
        [Test]
        public void d1_IsgetCustomerBookingCorrect()
        {
            testActivityObj.bookSeats(0, 2, testCustObj);

            Sales.Invoice actual1 = testActivityObj.getCustomerBooking(testCustObj);
            Sales.Invoice expected1 = testInvoiceObj;

            //all variables AreEqual
            Assert.AreEqual(expected1.getPriceCode(), actual1.getPriceCode(), "Price code not equal");           
            Assert.AreEqual(expected1.getTheCust(), actual1.getTheCust(), "The Customers not equal");
            Assert.AreEqual(expected1.getRowNum(), actual1.getRowNum(), "Row num not equal");
            Assert.AreEqual(expected1.getStartSeatNum(), actual1.getStartSeatNum(), "Start seat number not equal");
            Assert.AreEqual(expected1.getNumberOfSeats(), actual1.getNumberOfSeats(), "No of seats not equal");

            //Assert.AreEqual(expected1, actual1, "???"); 
            //This will not work for comparing object's data without a getter in source code similar to getTheCust().         
        }

        [Test]
        public void d2_IsgetCustomerBookingCorrect()
        {
            testActivityObj.bookSeats(0, 2, testCustObj1);

            Sales.Invoice actual1 = testActivityObj.getCustomerBooking(testCustObj1);
            Sales.Invoice expected1 = testInvoiceObj;

            //variables AreEqual & AreNotEqual
            Assert.AreEqual(expected1.getPriceCode(), actual1.getPriceCode(), "Price code not equal");           
            Assert.AreNotEqual(expected1.getTheCust(), actual1.getTheCust(), "The Customers equal");
            Assert.AreEqual(expected1.getRowNum(), actual1.getRowNum(), "Row num not equal");
            Assert.AreEqual(expected1.getStartSeatNum(), actual1.getStartSeatNum(), "Start seat number not equal");    
            Assert.AreEqual(expected1.getNumberOfSeats(), actual1.getNumberOfSeats(), "No of seats not equal");

            //Assert.AreEqual(expected1, actual1, "???"); 
            //This will not work for comparing object's data without a getter in source code similar to getTheCust().         
        }



//Test Case: 5 *******One test case on null (e.g. IsNull) value************************************************************************************
        [Test]
        public void e1_CustomerIsNull()
        {
            testInvoiceObj.setTheCust(null);

            //Customer objects IsNull
            Assert.IsNull(testInvoiceObj.getTheCust(), "Customer object is not null");//IsNull is to test null objects
        }


//Test Case: 6  *******One test case on same Object (e.g. AreSame)*********************************************************************************
        [Test]
        public void f1_CustomerAreSame()
        {           
            Assert.AreSame(testCustObj1, testInvoiceObj3.getTheCust());//AreSame is to test if objects are same with same reference
        }

        [Test]
        public void f2_CustomerAreNotSame()
        {
            Assert.AreNotSame(testCustObj, testInvoiceObj3.getTheCust()); //AreNotSame is to test if objects are not same with different references
        }


        //Test Case: 7 ******Two test cases to test for exceptions ************************************************************************************************
        //(e.g. you may need to add your codes in the method to raise the expected exceptions)
        //Flight(int economyRows, int economySeats, int firstClassRows, int firstClassSeats)
        [Test]
        public void g1_FlightEconomySeatsThrowsExceptionWhenZero()
        {
            //Throw an exception if number Of economy class seats are zero
            Assert.Throws<ArgumentException>(() => new Sales.Flight(20, 0, 5, 20));
        }

        [Test]
        public void g2_FlightEconomySeatsDoesNotThrowsExceptionWhenNotZero()
        {
            //DoesNotThrow an exception if number Of economy class seats are not zero
            Assert.DoesNotThrow(() => new Sales.Flight(20, 160, 5, 20));
        }


//Test Case: 8 ******Two test cases to test for exceptions ************************************************************************************************
        [Test]
        public void h1_SetNumberOfSeatsThrowsExceptionWhenZero()
        {
            //throw an exception if setNumberOfSeats is 0 for Economy class
            Assert.Throws<ArgumentException>(() => testInvoiceObj.setNumberOfSeats(0));
        }
        [Test]
        public void h2_SetNumberOfSeatsThrowsExceptionWhenOutOfRange()
        {
            //exception codes added in setNumberOfSeats method in Invoice class
            //throws out of range exception if setNumberOfSeats is 161 for Economy class
            Assert.Throws<ArgumentOutOfRangeException>(() => testInvoiceObj.setNumberOfSeats(161));
        }

        [Test]
        public void h3_SetNumberOfSeatsThrowsExceptionWhenOutOfRange()
        {
            //throws out of range exception if setNumberOfSeats is 21 for First class
            Assert.Throws<ArgumentOutOfRangeException>(() => testInvoiceObj2.setNumberOfSeats(21));
        }


//Test Case: 9 ******Two tester opted test cases ******************************************************************************************************
        //Customer(int memberType, String firstName, String lastName, String creditNumber, String creditType, String expiry)
        [Test]
        public void i1_IsCustomerCorrect()
        {
            testCustObj2 = new Sales.Customer(2, "KT", "Lau", "1000200030004000", "Visa", "12/24");

            int actual1 = testCustObj2.getMemberType();
            string actual2 = testCustObj2.getFirstName();
            string actual3 = testCustObj2.getLastName();
            string actual4 = testCustObj2.getCreditNumber();
            string actual5 = testCustObj2.getCreditType();
            string actual6 = testCustObj2.getExpiry();


            int expected1 = 2;
            string expected2 = "KT";
            string expected3 = "Lau";
            string expected4 = "1000200030004000";
            string expected5 = "Visa";
            string expected6 = "12/24";

            //all variables AreEqual
            Assert.AreEqual(expected1, actual1, "Member type not equal");
            Assert.AreEqual(expected2, actual2, "First name not equal");
            Assert.AreEqual(expected3, actual3, "Last name type not equal");
            Assert.AreEqual(expected4, actual4, "Credit card number not equal");
            Assert.AreEqual(expected5, actual5, "Credit card type not equal");
            Assert.AreEqual(expected6, actual6, "Credit card expiry not equal");
        }


//Test Case: 10 ******Two tester opted test cases ******************************************************************************************************
        //double getCharge(int priceCode)
        [Test]
        public void j1_IsInvoiceGetChargeCorrect()
        {
            double actual1 = testInvoiceObj.getCharge(0);
            double expected1 = 1000.00;

            //variables AreEqual
            Assert.AreEqual(expected1, actual1, "Charge not equal");         
        }

        [Test]
        public void j2_IsInvoiceGetChargeCorrect()
        {
            double actual1 = testInvoiceObj2.getCharge(1);
            double expected1 = 2222.00;

            //variables AreNotEqual
            Assert.AreNotEqual(expected1, actual1, "Charge equal");
        }

        [Test]
        public void j3_IsInvoiceGetChargeCorrect()
        {
            double actual1 = testInvoiceObj2.getCharge(1);
            double expected1 = 2222.00;

            //variables AreEqual
            Assert.AreEqual(expected1, actual1, "Charge not equal");
        }
    }
}
