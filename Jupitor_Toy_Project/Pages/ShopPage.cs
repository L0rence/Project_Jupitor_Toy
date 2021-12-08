using System;
using System.Threading;
using Jupitor_Toy_Project.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using static Jupitor_Toy_Project.Utilities.CommonMethods;

namespace Jupitor_Toy_Project.Pages
{
    public class ShopPage
    {
        private readonly IWebDriver driver;

        public ShopPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        //Page factory design Testing 
        IWebElement FunnuCowBuyBtn => driver.FindElement(By.XPath("//*[@id='product-6']/div/p/a"));
        IWebElement FluffyBunnyBtn => driver.FindElement(By.XPath("//li[@id='product-4']//a[@class='btn btn-success'][normalize-space()='Buy']"));
        IWebElement ClickCart => driver.FindElement(By.XPath("//a[@href='#/cart']"));
        IWebElement CheckOutMessage => driver.FindElement(By.XPath("//p[@class='cart-msg']"));
        IWebElement StuffedFrog => driver.FindElement(By.XPath("//li[@id='product-2']//a[@class='btn btn-success'][normalize-space()='Buy']"));
        IWebElement ValentineBear => driver.FindElement(By.XPath("//li[@id='product-7']//a[@class='btn btn-success'][normalize-space()='Buy']"));
        IWebElement ActualStuffedFrogPrice => driver.FindElement(By.XPath("//td[normalize-space()='$10.99']"));
        IWebElement ActualFluffyBunnyPrice => driver.FindElement(By.XPath("//td[normalize-space()='$9.99']"));
        IWebElement ActualValentineBeerPrice => driver.FindElement(By.XPath("//td[normalize-space()='$14.99']"));
        IWebElement FluffyBunny_quantity => driver.FindElement(By.XPath("//input[@value='5']"));
        IWebElement StuffedFrog_quantity => driver.FindElement(By.XPath("//input[@value='2']"));
        IWebElement Valentine_quantity => driver.FindElement(By.XPath("//input[@value='3']"));
        IWebElement StuffedFrog_SubTotalTxt => driver.FindElement(By.XPath("//td[normalize-space()='$21.98']"));
        IWebElement FluffyBunny_SubTotalTxt => driver.FindElement(By.XPath("//td[normalize-space()='$49.95']"));
        IWebElement ValentineBear_SubTotalTxt => driver.FindElement(By.XPath("//td[normalize-space()='$44.97']"));

       
        // Action Methods
        public void FunnyCow()
        {
            int j;
            for (j = 0; j < 2; j++)
            {
                FunnuCowBuyBtn.Click();
                Wait.ElementExists(driver, "Xpath", "FunnuCowBuyBtn", 400);
            }
        }
        public void FluffyBunny()
        {
            FluffyBunnyBtn.Click();
        }
        
        //5 Fluffybunny
        public void FiveFluffyBunny()
        {
            int i;
            for (i = 0; i < 5; i++)
            {
                FluffyBunnyBtn.Click();
                Wait.ElementExists(driver, "Xpath", "FluffyBunnyBtn", 400);
            }
            
        }
        //2 Stuffed frog
        public void TwoStuffedFrog()
        {
            int k;
            for (k = 0; k < 2; k++)
            {
                StuffedFrog.Click();
                Wait.ElementExists(driver, "Xpath", "StuffedFrog", 400);
            }
        }
        //3 Valentine
        public void ThreeValentine()
        {
            int k;
            for (k = 0; k < 3; k++)
            {
                ValentineBear.Click();
                Wait.ElementExists(driver, "Xpath", "ValentineBear", 400);
            }
        }
        
        public void ClickOnCart()
        {
            ClickCart.Click();
        }

        //Verify Price for Stuffed Frog 
        public void VerifyThePriceForStuffedFrog()
        {
            var expected_Stuffed_frog_price = "$10.99";
            var actualStuffed_frog_price = ActualStuffedFrogPrice.Text;
            Assert.AreEqual(expected_Stuffed_frog_price, actualStuffed_frog_price, "Verify Stuffed Frog Price are ===>>>>" + actualStuffed_frog_price);
            Console.WriteLine("Verify Each Stuffed Frog Price are ===>>>>" + actualStuffed_frog_price);
        }

        //Verify Price for Fluffy Bunny 
        public void VerifyThePriceForFluffyBunny()
        {
            var expected_Fluffy_bunny_price = "$9.99";
            var actualFluffyBunny_price = ActualFluffyBunnyPrice.Text;
            Assert.AreEqual(expected_Fluffy_bunny_price, actualFluffyBunny_price, "Verify Stuffed Frog Price are ==>>>>>" + actualFluffyBunny_price);
            Console.WriteLine("Verify Each Stuffed Frog Price are ==>>>>>" + actualFluffyBunny_price);
        }

        //Verify Price for Valentine Beer 
        public void VerifyThePriceForValentineBeer()
        {
            var expected_Valentine_Bear_price = "$14.99";
            var actual_Valentine_Bear_price = ActualValentineBeerPrice.Text;
            Assert.AreEqual(expected_Valentine_Bear_price, actual_Valentine_Bear_price, "Verify Stuffed Frog Price are ==>>>>>" + actual_Valentine_Bear_price);
            Console.WriteLine("Verify Each Stuffed Frog Price are ==>>>>>" + actual_Valentine_Bear_price);
        }

        public void validateCart()
        {
            var Actual_text = CheckOutMessage.Text;
            Console.WriteLine("The Actual text is " + Actual_text);
            Assert.AreEqual(Actual_text, "There are 3 items in your cart, you can Checkout or carry on Shopping.");
            //Assert.AreEqual(Actual_text, ExcelLibHelper.ReadData(1, "Cart_Txt").Contains(Actual_text));
            
            if (Actual_text == "There are 3 items in your cart, you can Checkout or carry on Shopping.")
            {
                Console.WriteLine("Test Passed!! ====>" + Actual_text);
            }
            else
            {
                Console.WriteLine("Test Failed !!=========>>>>"  +Actual_text);
            }
            
        }
       
        //************ Sub Total for Fluffy Bunny ********************//

        public void FluffyBunnySubTotal()
        {
                 
                string expected_Fluffy_bunny_price = "$9.99";
                string trimmed = (expected_Fluffy_bunny_price as string).Trim('$');
                Console.WriteLine("Expected Result is  =>>>>>>>>>>" + trimmed);
                //double x = Int32.Parse(trimmed);
                //Console.WriteLine("numbe r is " + x);
                //Double.Parse(expected_Fluffy_bunny_price, System.Globalization.NumberStyles.Currency);
                trimmed = trimmed.Substring(0);
                double Amount_Actual_Fluufy_price = Double.Parse(trimmed);


                //Fluffy Bunny Quantity

                string expected_FB_Quantity = FluffyBunny_quantity.GetAttribute("value");
                double Quantity_of_FB = Double.Parse(expected_FB_Quantity);
                Console.WriteLine("The value of Fluffy bunny is " + Quantity_of_FB);

                //Sub Total of the Stuffed frog Price and Quantity
                double Fluffy_bunny_subTotal = Amount_Actual_Fluufy_price * Quantity_of_FB;
                Console.WriteLine("Sub totoal of the fluffy bunny price and Quantity===>>> " + Fluffy_bunny_subTotal);
               

                //Validate Sub total 
                Assert.AreEqual(Fluffy_bunny_subTotal, 49.95);
                Console.WriteLine("Test passed for Fluffy bunny sub total validation");
           

            //string expected_Fluffy_bunny_price = "$9.99";
            //string trimmed = (expected_Fluffy_bunny_price as string).Trim('$');
            ////Console.WriteLine("Result is  =>>>>>>>>>>" + trimmed);

            //string numbString = trimmed;
            //int number;
            //bool isParsable = Int32.TryParse(numbString, out number);

            //if (isParsable)
            //    Console.WriteLine(number);
            //else
            //    Console.WriteLine("Could not be parsed.");
            ////var value = trimmed * 2;


            //var successfullyParsed = int.TryParse("123", out convertedInt);
            //var actualFluffyBunny_price = ActualFluffyBunnyPrice.Text;

            /*
       public void BuyItems()
       {
           FluffyBunny();
           FunnyCow();
           ClickOnCart();
           validateCart();
           ValidateItemAreInCart();
           bool isDisplayed = ValidateItemAreInCart();
           Assert.IsTrue(isDisplayed);

       }
       */




        }

        //************ Sub Total for Stuffed Frog ********************//

        public void StuffedFrogSubTotal()
        {

            string expected_StuffedFrog_price = "$10.99";
            string trimmed = (expected_StuffedFrog_price as string).Trim('$');
            Console.WriteLine("Expected Stuffed Frog Result is  =>>>>>>>>>>" + trimmed);
            //double x = Int32.Parse(trimmed);
            //Console.WriteLine("numbe r is " + x);
            //Double.Parse(expected_Fluffy_bunny_price, System.Globalization.NumberStyles.Currency);
            trimmed = trimmed.Substring(0);
            double Amount_Actual_Stuffed_price = Double.Parse(trimmed);


            //Fluffy Bunny Quantity

            string expected_StuffedFrog_Quantity = StuffedFrog_quantity.GetAttribute("value");
            double Quantity_of_StuffedFrog = Double.Parse(expected_StuffedFrog_Quantity);
            Console.WriteLine("The value of Fluffy bunny is " + Quantity_of_StuffedFrog);

            //Sub Total of the Stuffed frog Price and Quantity
            double StuffedFrog_subTotal = Amount_Actual_Stuffed_price * Quantity_of_StuffedFrog;
            Console.WriteLine("Sub totoal of the Stuffed Frog price and Quantity===>>> $" + StuffedFrog_subTotal);


            //Validate Sub total 
            Assert.AreEqual(StuffedFrog_subTotal, 21.98);
            Console.WriteLine("Test passed for Stuffed Frog sub total validation");


            //string expected_Fluffy_bunny_price = "$9.99";
            //string trimmed = (expected_Fluffy_bunny_price as string).Trim('$');
            ////Console.WriteLine("Result is  =>>>>>>>>>>" + trimmed);

            //string numbString = trimmed;
            //int number;
            //bool isParsable = Int32.TryParse(numbString, out number);

            //if (isParsable)
            //    Console.WriteLine(number);
            //else
            //    Console.WriteLine("Could not be parsed.");
            ////var value = trimmed * 2;


            //var successfullyParsed = int.TryParse("123", out convertedInt);
            //var actualFluffyBunny_price = ActualFluffyBunnyPrice.Text;

            /*
       public void BuyItems()
       {
           FluffyBunny();
           FunnyCow();
           ClickOnCart();
           validateCart();
           ValidateItemAreInCart();
           bool isDisplayed = ValidateItemAreInCart();
           Assert.IsTrue(isDisplayed);

       }
       */




        }

        //************ Sub Total for Valentine Bear ********************//
        public void ValentineBearSubTotal()
        {

            string expected_ValentineBear_price = "$14.99";
            string trimmed = (expected_ValentineBear_price as string).Trim('$');
            Console.WriteLine("Expected ValentineBear Result is  =>>>>>>>>>>" + trimmed);
            //double x = Int32.Parse(trimmed);
            //Console.WriteLine("numbe r is " + x);
            //Double.Parse(expected_Fluffy_bunny_price, System.Globalization.NumberStyles.Currency);
            trimmed = trimmed.Substring(0);
            double Amount_Actual_ValentineBear_price = Double.Parse(trimmed);


            //Fluffy Bunny Quantity

            string expected_ValentineBear_Quantity = Valentine_quantity.GetAttribute("value");
            double Quantity_of_ValentineBear = Double.Parse(expected_ValentineBear_Quantity);
            Console.WriteLine("The value of Valentine Bear is " + Quantity_of_ValentineBear);

            //Sub Total of the Stuffed frog Price and Quantity
            double ValentineBear_subTotal = Amount_Actual_ValentineBear_price * Quantity_of_ValentineBear;
            Console.WriteLine("Sub totoal of the Stuffed Frog price and Quantity===>>> $" + ValentineBear_subTotal);


            //Validate Sub total 
            Assert.AreEqual(ValentineBear_subTotal, 44.97);
            Console.WriteLine("Test passed for Valentine Bear subTotal validation");


            //string expected_Fluffy_bunny_price = "$9.99";
            //string trimmed = (expected_Fluffy_bunny_price as string).Trim('$');
            ////Console.WriteLine("Result is  =>>>>>>>>>>" + trimmed);

            //string numbString = trimmed;
            //int number;
            //bool isParsable = Int32.TryParse(numbString, out number);

            //if (isParsable)
            //    Console.WriteLine(number);
            //else
            //    Console.WriteLine("Could not be parsed.");
            ////var value = trimmed * 2;


            //var successfullyParsed = int.TryParse("123", out convertedInt);
            //var actualFluffyBunny_price = ActualFluffyBunnyPrice.Text;

            /*
       public void BuyItems()
       {
           FluffyBunny();
           FunnyCow();
           ClickOnCart();
           validateCart();
           ValidateItemAreInCart();
           bool isDisplayed = ValidateItemAreInCart();
           Assert.IsTrue(isDisplayed);

       }
       */




        }


        //*x***************Verify that total = sum(sub totals) ********************//
        public void VerifySumOfAllProduct()
        {
            //StuffedFrog Total Sun
            string ActualStuffedFrog_subTotoal = StuffedFrog_SubTotalTxt.Text;
            string trimmed = (ActualStuffedFrog_subTotoal as string).Trim('$');
            trimmed = trimmed.Substring(0);
            double Amount_Actual_StuffedFrog_price = Double.Parse(trimmed);

            //FluffyBunny Total
            string ActualFluffyBunny_subTotoal = FluffyBunny_SubTotalTxt.Text;
            string trimmed1 = (ActualFluffyBunny_subTotoal as string).Trim('$');
            trimmed = trimmed1.Substring(0);
            double Amount_Actual_FluffyBunny_price = Double.Parse(trimmed1);

            //Valentine Bear Total
            string ActualValentineBear_subTotoal = ValentineBear_SubTotalTxt.Text;
            string trimmed3 = (ActualValentineBear_subTotoal as string).Trim('$');
            trimmed = trimmed3.Substring(0);
            double Amount_Actual_ValentineBear_price = Double.Parse(trimmed3);

            double SumOfAllProduct = Amount_Actual_StuffedFrog_price + Amount_Actual_FluffyBunny_price + Amount_Actual_ValentineBear_price;
            Console.WriteLine("Sum Of All The Products are ======>>>> $"+ SumOfAllProduct);
            Assert.AreEqual(SumOfAllProduct, 116.9);
            
        }
       


    }
}
