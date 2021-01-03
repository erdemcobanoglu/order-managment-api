using DataAccessLayer.EFCore;
using ILoggerFactory = Microsoft.Extensions.Logging.ILoggerFactory;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Logging;
using System.Linq;
using EntityLayer;

namespace DataAccessLayer.Seed
{
    public class SeedData
    {
        private static ILogger<SeedData> _logger;
        private static EFContext _context;
        public static void Seed(EFContext context, ILoggerFactory loggerFactory)
        {
            _context = context;
            _logger = loggerFactory.CreateLogger<SeedData>();


            try
            {
                SeedCustomers();
                SeedProducts();

                context.SaveChangesAsync();

                _logger.LogInformation("Seeded Data");
            }
            catch (Exception ex)
            {

                _logger.LogError(ex.Message);
            }
        }

        private static void SeedProducts()
        {
            if (!_context.Products.Any())
            { 
                List<Product> products = new List<Product>
                {
                    new Product{Name="Biker Yaka Kapitone Yelek", Price = 79.99M, QuantityPerUnit = 10, Barcode = "0W2972Z8 - CVL", Description = "Fermuar kapama Yandan cepli",CreatedDate = DateTime.Now}
                };

                _context.Products.AddRange(products);
            }
        }

        private static void SeedCustomers()
        {
            if (!_context.Customers.Any())
            { 
                List<Customer> customers = new List<Customer>
                {
                    new Customer{ Name = "gizem", Address="istanbul maltepe", CreatedDate = DateTime.Now}
                };

                _context.Customers.AddRange(customers);
            }
        }
    }
}
