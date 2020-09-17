using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace Sales
{
    public class Activity
    {
        private Hashtable customerBookings = new Hashtable();

        //private const double EconomyCharge = 1000.00;
        //private const double FirstClassCharge = 2000.00;
       
        //private const double AsiaWorldDiscount = 0.90;
        //private const double GlobalWorldDiscount = 0.80;

        private Flight theFlight;

        public Activity(Flight theFlight)
        {
            this.theFlight = theFlight;
        }

        public Boolean bookSeats(int priceCode, int number, Customer theCustomer) //number is total number of seats booked
        {
            switch (priceCode)
            {
                case Seat.Economy:
                    {
                        ArrayList theEconomy = theFlight.getEconomy();
                        IEnumerator theEnum = theEconomy.GetEnumerator();
                        while (theEnum.MoveNext())
                        {
                            Seat theSeat = (Seat)theEnum.Current;
                            if (theSeat.bookSeats(number))
                            {
                                Invoice newBooking = new Invoice(priceCode, theCustomer, theEconomy.IndexOf(theSeat) + 1, theSeat.getLastBooked(), number);
                                customerBookings.Add(theCustomer, newBooking);
                                return true;
                            }
                        }
                        return false;
                    }
                case Seat.FirstClass:
                    {
                        ArrayList theFirstClass = theFlight.getFirstClass();
                        IEnumerator theEnum = theFirstClass.GetEnumerator();
                        while (theEnum.MoveNext())
                        {
                            Seat theSeat = (Seat)theEnum.Current;
                            if (theSeat.bookSeats(number))
                            {
                                Invoice newBooking = new Invoice(priceCode, theCustomer, theFirstClass.IndexOf(theSeat) + 1, theSeat.getLastBooked(), number);
                                customerBookings.Add(theCustomer, newBooking);
                                return true;
                            }
                        }
                        return false;
                    }
            }
                    return false;
            }

        public Invoice getCustomerBooking(Customer cust)
        {
            return (Invoice)customerBookings[cust];
        }
    }
}
