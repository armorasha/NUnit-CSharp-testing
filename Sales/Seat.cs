using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sales
{
    public class Seat
    {
        public const int Economy = 0;
        public const int FirstClass = 1;
        
        //private const double EconomyCharge = 1000.00;
        //private const double FirstClassCharge = 2000.00;

        //private const double AsiaWorldDiscount = 0.90;
        //private const double GlobalWorldDiscount = 0.80;



        private int priceCode;
        private int numberAvailable;
        private int currentSeat;
        private int lastBooked;


        //for alloting how many seats for economy/fisrt class in Flight.cs
        //priceCode = 0 for economy and 1 for first class
        public Seat(int numAvail, int code)
        {
            this.priceCode = code;
            this.numberAvailable = numAvail;
            currentSeat = 1;
            lastBooked = 1;
        }

        public Boolean bookSeats(int num)
        {
            if (numberAvailable >= num)
            {
                lastBooked = currentSeat;
                currentSeat += num;
                numberAvailable -= num;
                return true;
            }
            return false;
        }

        public int getPriceCode()
        {
            return priceCode;
        }

        public int getLastBooked()
        {
            return lastBooked;
        }

        public int getCurrentSeat()
        {
            return currentSeat;
        }
    }
}
