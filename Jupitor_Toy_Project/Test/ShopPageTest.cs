using System;
using Jupitor_Toy_Project.Pages;
using Jupitor_Toy_Project.Utilities;
using NUnit.Framework;

namespace Jupitor_Toy_Project.Test
{
    [TestFixture]
    public class ShopPageTest : CommonDriver
    {
        [Test]
        public void BuyFunnyCowFluffyBunnyTest()
        {
            //Home page object
            HomePage homePageObj = new HomePage(driver);
            homePageObj.NavigateToShopPage();

            //Shop Page Objects
            ShopPage shopPageObj = new ShopPage(driver);
            //shopPageObj.BuyItems();
           
            shopPageObj.FunnyCow();
            shopPageObj.FluffyBunny();
            shopPageObj.ClickOnCart();
            shopPageObj.validateCart();


        }
        [Test]
        public void AdvancedTest()
        {
            //Home page object
            HomePage homePageObj = new HomePage(driver);
            homePageObj.NavigateToShopPage();

            //Shop Page Objects
            ShopPage shopPageObj = new ShopPage(driver);
            shopPageObj.TwoStuffedFrog();
            shopPageObj.FiveFluffyBunny();
            shopPageObj.ThreeValentine();
            shopPageObj.ClickOnCart();
            shopPageObj.VerifyThePriceForStuffedFrog();
            shopPageObj.VerifyThePriceForFluffyBunny();
            shopPageObj.VerifyThePriceForValentineBeer();
            shopPageObj.FluffyBunnySubTotal();
            shopPageObj.StuffedFrogSubTotal();
            shopPageObj.ValentineBearSubTotal();
            shopPageObj.VerifySumOfAllProduct();
        }

    }
}
