using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.Andrey_and_Billiard
{
    class AndreyAndBilliard
    {
        class Customer
        {
            public string Name { get; set; }
            public Dictionary<string, decimal> ShopList { get; set; }
            public decimal Bill { get; set; }
        }

        static void Main()
        {
            var availableProducts = new Dictionary<string, decimal>();
            var customers = new List<Customer>();

            availableProducts = CreateProductsData();
            customers = GenerateCustomersOrders(availableProducts);

            var totalBill = 0M;

            foreach (var customer in customers.OrderBy(customer => customer.Name))
            {
                Console.WriteLine(customer.Name);
               
                foreach (var product in customer.ShopList)
                {
                    var productName = product.Key;
                    var productQty = product.Value;

                    customer.Bill += availableProducts[productName] * productQty;

                    Console.WriteLine($"-- {productName} - {productQty}");
                }

                Console.WriteLine($"Bill: {customer.Bill:f2}");

                totalBill += customer.Bill;
            }

            Console.WriteLine($"Total bill: {totalBill:f2}");

        }

        private static List<Customer> GenerateCustomersOrders(Dictionary<string, decimal> availableProducts)
        {
            var inputLine = Console.ReadLine();

            var customers = new List<Customer>();

            while (inputLine != "end of clients")
            {
                var order = inputLine.Split('-', ',');

                var customerName = order[0];
                var product = string.Empty;
                var quantity = 0M;
                var shopList = new Dictionary<string, decimal>();

                for (int pos = 1; pos < order.Length; pos += 2)
                {
                    product = order[pos];
                    quantity = decimal.Parse(order[pos + 1]);

                    if (availableProducts.ContainsKey(product) && quantity > 0)
                    {
                        shopList.Add(product, quantity);
                    }
                }

                if (shopList.Count > 0)
                {
                    if (customers.Find(customer => customer.Name == customer))
                    {

                    }
                    customers.Add(new Customer
                    { Name = customerName, ShopList = shopList });
                }
                
                inputLine = Console.ReadLine();
            }

            return customers;
        }

        private static Dictionary<string, decimal> CreateProductsData()
        {
            var productsCount = int.Parse(Console.ReadLine());

            var productsPrices = new Dictionary<string, decimal>();

            for (int i = 0; i < productsCount; i++)
            {
                var inputLine = Console.ReadLine().Split('-');

                var productName = inputLine[0];
                var productPrice = decimal.Parse(inputLine[1]);

                if (!productsPrices.ContainsKey(productName))
                {
                    productsPrices[productName] = productPrice;
                }
                else
                {
                    productsPrices[productName] = productPrice;
                }
            }

            return productsPrices;
        }
    }
}
