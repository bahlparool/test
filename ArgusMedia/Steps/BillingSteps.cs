using ArgusMedia.API_stubs;
using ArgusMedia.Variables;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace ArgusMedia.Steps
{
    [Binding]
    public sealed class BillingSteps
    {
        private readonly ScenarioContext _scenarioContext;
        Billing bill;
        double totalFood;
        double totalServiceCharge;
        double totalBill;


        public BillingSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            bill = new Billing();
        }

        //ADD REQUEST
        [Given(@"I have received an order")]
        public void GivenIHaveReceivedAnOrder(Table table)
        {
            var order = table.CreateInstance<OrderPlacement>();
            calcualteBill(order.Starters, order.Mains, order.Drinks);
        }

        [Then(@"the API should return the correct bill")]
        public void ThenTheAPIShouldReturnTheCorrectBill(Table table)
        {
            var billCalc = table.CreateInstance<BillCalculation>();
            verifyFoodBill(billCalc.TotalFoodBill, billCalc.TotalServiceCharge, billCalc.TotalBill);
        }

        //UPDATE REQUEST
        [When(@"the order is updated")]
        public void WhenTheOrderIsUpdated(Table table)
        {
            var order = table.CreateInstance<OrderPlacement>();
            calcualteBill(order.Starters, order.Mains, order.Drinks);
        }

        //DELETE REQUEST
        [When(@"an order is cancelled")]
        public void WhenAnOrderIsCancelled(Table table)
        {
            var order = table.CreateInstance<OrderPlacement>();
            cancelBill(order.Starters, order.Mains, order.Drinks);
        }


        /// <summary>
        /// This function is used to imitate the CREATE and PATCH request
        /// </summary>
        /// <param name="starters"></param>
        /// <param name="mains"></param>
        /// <param name="drinks"></param>
        private void calcualteBill(int starters, int mains, int drinks)
        {
            totalFood = bill.calcFood(starters, mains, drinks); ;
            totalServiceCharge = bill.calcServiceCharge(totalFood);
            totalBill = totalFood + totalServiceCharge;
        }

        /// <summary>
        /// This function is used to imitate the DELETE request
        /// </summary>
        /// <param name="starters"></param>
        /// <param name="mains"></param>
        /// <param name="drinks"></param>
        private void cancelBill(int starters, int mains, int drinks)
        {
            totalFood = totalFood - bill.calcFood(starters, mains, drinks); ;
            totalServiceCharge = bill.calcServiceCharge(totalFood);
            totalBill = totalFood + totalServiceCharge;
        }

        /// <summary>
        /// This function is used to verify the response
        /// </summary>
        /// <param name="totalFood"></param>
        /// <param name="totalServiceCharge"></param>
        /// <param name="totalBill"></param>
        private void verifyFoodBill(double totalFood, double totalServiceCharge, double totalBill)
        {
            Assert.IsTrue(totalFood == this.totalFood, "Food total is incorrect");
            Assert.IsTrue(totalServiceCharge == this.totalServiceCharge, "Service charge is incorrect");
            Assert.IsTrue(totalBill == this.totalBill, "Total bill is incorrect");
        }
    }

}
