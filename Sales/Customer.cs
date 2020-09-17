using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sales
{
    public class Customer
    {
        public const int NonMember = 0;
        public const int AsiaWorld = 1;
        public const int GlobalWorld = 2;
        
        private int memberType;

        private String lastName;
        private String firstName;
        private String creditNumber;
        private String creditType;
        private String expiry;

        //private const double EconomyCharge = 1000.00;
        //private const double FirstClassCharge = 2000.00;
   
        //private const double AsiaWorldDiscount = 0.90;
        //private const double GlobalWorldDiscount = 0.80;

        public Customer(int memberType, String firstName, String lastName, String creditNumber, String creditType, String expiry)
        {
            this.memberType = memberType;
            this.firstName = firstName;
            this.lastName = lastName;
            this.creditNumber = creditNumber;
            this.creditType = creditType;
            this.expiry = expiry;
        }

        public String getCreditNumber()
        {
            return creditNumber;
        }

        public String getLastName()
        {
            return lastName;
        }

        public String getFirstName()
        {
            return firstName;
        }

        public String getCreditType()
        {
            return creditType;
        }

        public String getExpiry()
        {
            return expiry;
        }

        public int getMemberType()
        {
            return memberType;
        }

        public void setCreditNumber(String creditNumber)
        {
            this.creditNumber = creditNumber;
        }

        public void setCreditType(String creditType)
        {
            this.creditType = creditType;
        }

        public void setLastName(String lastName)
        {
            this.lastName = lastName;
        }

        public void setFirstName(String firstName)
        {
            this.firstName = firstName;
        }

        public void setExpiry(String expiry)
        {
            this.expiry = expiry;
        }

        public void setMemberType(int memberType)
        {
            this.memberType = memberType;
        }


    } 
}
