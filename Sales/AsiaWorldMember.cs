using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sales
{
    public class AsiaWorldMember : Membership
    {
        private double discountRate;

        public double getdiscount()
        {
            discountRate = 0.9;
            return discountRate;
        }
    }
}
