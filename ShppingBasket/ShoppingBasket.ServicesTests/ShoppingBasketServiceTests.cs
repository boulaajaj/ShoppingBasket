using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShoppingBasket.Domain.Models;
using ShoppingBasket.Services;
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

        }

        [TestMethod()]
        public void GetOrderLineItemFromProductTest()
        {
            //arrage
            
            //act

            //assert
            Assert.Fail();
        }

        static TaxRules GetStateTaxRules()
        {
            return new TaxRules()
            {
                BasicRate = 0.10M,
                ExemptProductTypes = new List<string> { "book", "food", "medical" },
                CentsToRoundUpBy = 5,
                ImportRate = 0.05M
            };
        }

        static IEnumerable<Product> GetProductsFromInput1()
        {
            return new List<Product> {
            new Product {
                Quantity = 1,
                Name ="book",
                Price = 12.49M,
                IsImported = false,
                Type = "book"
            },
            new Product {
                Quantity = 1,
                Name ="music CD",
                Price = 14.99M,
                IsImported = false,
                Type = "music"
            },
            new Product {
                Quantity = 1,
                Name = "chocolate bar",
                Price = 0.85M,
                IsImported = false,
                Type = "food"
            }
        };
        }
    }
}