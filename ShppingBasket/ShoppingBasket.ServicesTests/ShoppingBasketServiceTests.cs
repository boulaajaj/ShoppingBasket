using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShoppingBasket.Domain.Models;
using ShoppingBasket.Services;
using ShoppingBasket.Services.Tests.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBasket.Services.Tests
{
    [TestClass()]
    public class ShoppingBasketServiceTests
    {
        [TestInitialize]
        public void Initialize()
        {
            //to be init
        }


        [TestMethod()]
        public void GetProductTaxRate_GivenProductIsExemptAndNotImported_ExpectingZeroTaxRate()
        {
            //arrage
            var order = new Order()
            {
                TaxRules = new TaxRules()
                {
                    BasicRate = 0.10M,
                    ExemptProductTypes = new List<string> { "book", "food", "medical" },
                    ImportRate = 0.05M
                }
            };
            var product = new Product
            {
                IsImported = false,
                Type = "food"
            };

            //act
            var sb = new ShoppingBasketService();
            var result = sb.SetOrder(order).GetProductTaxRate(product);

            //assert
            Assert.AreEqual(0.00M, result);
        }

        [TestMethod()]
        public void GetProductTaxRate_GivenProductIsNotExemptAndIsImported_ExpectingMaximumTaxRate()
        {
            //arrage
            var order = new Order()
            {
                TaxRules = new TaxRules()
                {
                    BasicRate = 0.15M,
                    ExemptProductTypes = new List<string> { "book", "food", "medical" },
                    ImportRate = 0.05M
                }
            };
            var product = new Product
            {
                IsImported = true,
                Type = "transport"
            };

            //act
            var sb = new ShoppingBasketService();
            var result = sb.SetOrder(order).GetProductTaxRate(product);

            //assert
            Assert.AreEqual(0.20M, result);
        }

        [TestMethod]
        public void TaxRules_GivenTheCetsToRoundUpByAreOutOfValidRange_ExpectingModelError()
        {
            //arrage
            var taxRules = new TaxRules()
            {
                CentsToRoundUpBy = 55
            };

            //act
            var results = ModelValidationHelper.Validate(taxRules);

            //assert
            Assert.AreEqual(1, results.Count);
            Assert.AreEqual("CentsToRoundUpBy cannot be greater than 9 or less than 0.", results[0].ErrorMessage);
        }

        [TestMethod]
        public void TaxRules_GivenTheCetsToRoundUpByIsWithinRange_ExpectingValidModel()
        {
            //arrage
            var taxRules = new TaxRules()
            {
                CentsToRoundUpBy = 5
            };

            //act
            var results = ModelValidationHelper.Validate(taxRules);

            //assert
            Assert.AreEqual(0, results.Count);
        }
    }
}