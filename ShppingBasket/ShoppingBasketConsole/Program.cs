using ShoppingBasket.Domain.Models;
using ShoppingBasket.Services;
using System;
using System.Collections.Generic;

namespace ShoppingBasketConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var orders = GetOrders();
            var shoppingBasket = new ShoppingBasketService();

            foreach (Order order in orders)
            {
                shoppingBasket.SetOrder(order);
                shoppingBasket.PrintReceiptDetails();
                Console.WriteLine(" ");
                Console.WriteLine("-*-*-*-*-*-*-*-");
                Console.WriteLine(" ");

            }
            Console.Read();
        }

        static HashSet<Order> GetOrders()
        {
            HashSet<Order> orders = new HashSet<Order>();
            orders.Add(new Order
            {
                TaxRules = GetStateTaxRules(),
                Products = GetProductsFromInput1()
            });
            orders.Add(new Order
            {
                TaxRules = GetStateTaxRules(),
                Products = GetProductsFromInput2()
            });
            orders.Add(new Order
            {
                TaxRules = GetStateTaxRules(),
                Products = GetProductsFromInput3()
            });

            return orders;
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

        static IEnumerable<Product> GetProductsFromInput2()
        {
            return new List<Product> {
            new Product {
                Quantity = 1,
                Name = "imported box of chocolates",
                Price = 10.00M,
                IsImported = true,
                Type = "food"
            },
            new Product {
                Quantity = 1,
                Name = "imported bottle of perfume",
                Price = 47.50M,
                IsImported = true,
                Type = "perfume"
            }
        };
        }

        static IEnumerable<Product> GetProductsFromInput3()
        {
            return new List<Product> {
            new Product {
                Quantity = 1,
                Name ="imported bottle of perfume",
                Price = 27.99M,
                IsImported = true,
                Type = "perfume"
            },
            new Product {
                Quantity = 1,
                Name ="bottle of perfume",
                Price = 18.99M,
                IsImported = false,
                Type = "perfume"
            },
            new Product {
                Quantity = 1,
                Name ="packet of headache pills",
                Price = 9.75M,
                IsImported = false,
                Type = "medical"
            },
            new Product {
                Quantity = 1,
                Name ="box of imported chocolates",
                Price =11.25M,
                IsImported = true,
                Type = "food"
            }
        };
        }
    }
}
