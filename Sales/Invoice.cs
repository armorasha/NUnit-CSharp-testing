using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sales
{
    public class Invoice
    {
        AsiaWorldMember asiaWorldMember;
        GlobalWorldMember globalWorldMember;
        Flight flight;

        //private const double EconomyCharge = 1000.00;
        //private const double FirstClassCharge = 2000.00;

        //private const double AsiaWorldDiscount = 0.90;
        //private const double GlobalWorldDiscount = 0.80;

        private int priceCode;
        private int numberOfSeats;
        private Customer theCust;
        private int rowNum;
        private int startSeatNum;

        public String toString()
        {
            return "Price Code =" + priceCode + ", seats booked =" + numberOfSeats + ", sitting at row " + rowNum;
        }

        public Invoice(int priceCode, Customer theCust, int rowNum, int startSeatNum, int seatsBooked)
        {

            //private const double EconomyCharge = 1000.00;
            //private const double FirstClassCharge = 2000.00;

            //private const double AsiaWorldDiscount = 0.90;
            //private const double GlobalWorldDiscount = 0.80;

            this.priceCode = priceCode;
            this.theCust = theCust;
            this.rowNum = rowNum;
            this.startSeatNum = startSeatNum;
            this.numberOfSeats = seatsBooked;
        }

        public int getNumberOfSeats()
        {
            return numberOfSeats;
        }

        public int getPriceCode()
        {
            return priceCode;
        }

        public Customer getTheCust()
        {
            return theCust;
        }

        public int getStartSeatNum()
        {
            return startSeatNum;
        }

        public int getRowNum()
        {
            return this.rowNum;
        }

        public void setNumberOfSeats(int numberOfSeats)
        {
            // Added code to raise zero, null, out of range exception errors
            if (numberOfSeats == 0)
            {
                throw new ArgumentException("Number of seats cannot be zero");
            }

            if ((numberOfSeats > 160 && getPriceCode() == 0) || (numberOfSeats > 20 && getPriceCode() == 1))
            {
                throw new ArgumentOutOfRangeException("Number of seats out of range");
            };

            this.numberOfSeats = numberOfSeats;
        }


        public void setPriceCode(int priceCode)
        {
            this.priceCode = priceCode;
        }

        public void setTheCust(Customer theCust)
        {
            this.theCust = theCust;
        }

        public void setRowNum(int rowNum)
        {
            this.rowNum = rowNum;
        }

        public void setStartSeatNum(int startSeatNum)
        {
            this.startSeatNum = startSeatNum;
        }
        public double getDiscount(int memberCode)
        {
            //private int memberCode;
            /*constants const int NonMember = 0; AsiaWorld = 1; GlobalWorld = 2;*/

            asiaWorldMember = new AsiaWorldMember();
            globalWorldMember = new GlobalWorldMember();

            if (memberCode == Customer.AsiaWorld)
                //return AsiaWorld discount
                return asiaWorldMember.getdiscount();

            if (memberCode == Customer.GlobalWorld)
                //return GlobalWorld discount;
                return globalWorldMember.getdiscount();

            return 1;
        }

        public double getCharge(int priceCode)
        {
            //private int priceCode;
            /*Constants const int Economy = 0; FirstClass = 1;*/


            //??????????   flight = new Flight();   ??????
            if (priceCode == Seat.Economy)
            {
                //return economy charge;
                return Sales.Flight.EconomyCharge;
            }
            else
            {
                if (priceCode == Seat.FirstClass)
                {
                    //return first class charge;
                    return Sales.Flight.FirstClassCharge;
                }
                else
                {
                    return -1;
                }
            }
        }  
    }
}
