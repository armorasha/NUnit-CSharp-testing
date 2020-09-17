using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sales
{
    public class GlobalWorldMember : Membership
    {
        private double discountRate;

        public double getdiscount()
        {
            discountRate = 0.8;
            return discountRate;
        }
    }
}
