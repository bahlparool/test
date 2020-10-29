using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArgusMedia.API_stubs
{
    class Billing
    {
        int serviceCharge = 10;
        double starter = 4;
        double main = 7;
        double drink = 2.5;
        double totalFood;
        double totalServiceCharge;

        //Every item will be individuly priced in the bill, if there were 2 mains ordered, then they will appear in 2 separate lines and a sub-total is not needed
        public double calcFood(int starters, int mains, int drinks)
        {    
            totalFood = (starters*starter) + (mains*main) + (drinks*drink);
            return totalFood;
        }

        public double calcServiceCharge(double foodBill)
        {
            totalServiceCharge = foodBill * serviceCharge / 100;
            return totalServiceCharge;
        }

        public double calcBill()
        {
            return totalFood + totalServiceCharge;
        }
    }
}
