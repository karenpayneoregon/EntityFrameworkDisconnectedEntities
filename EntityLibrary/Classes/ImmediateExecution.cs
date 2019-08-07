using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLibrary.Classes
{
    public class ImmediateExecution
    {
        public List<Product> GetProductsReadOnly()
        {
            using (var context = new NorthWindContext())
            {

                context.Configuration.AutoDetectChangesEnabled = false;
                context.Configuration.LazyLoadingEnabled = false;

                return (from product in context.Products.AsNoTracking()
                        select new Product()
                        {
                            ProductName = product.ProductName,
                            UnitPrice = 12.99M
                        })
                    .OrderBy(p => p.ProductName)
                    .ToList();
            }
        }

        public int CountProducts()
        {
            using (var context = new NorthWindContext())
            {
                return context.Products.AsNoTracking().Count();
            }
        }
        public int CountProducts1() 
        {
            using (var context = new NorthWindContext())
            {
                context.Configuration.AutoDetectChangesEnabled = false;
                return context.Products.AsNoTracking().Count();
            }
        }
        public void ApplyDiscount1(int pCustomerIdentifier, float pCurrentDiscount, float pNewDiscount)
        {
            using (var context = new NorthWindContext())
            {
                var orderDetailsResults = (from order in context.Orders
                    join orderDetail in context.Order_Details on order.OrderID equals orderDetail.OrderID
                    where order.CustomerIdentifier == pCustomerIdentifier
                    select orderDetail)
                    .DistinctBy(details => details.OrderID)
                    .Where(details => details.Discount == pCurrentDiscount)
                    .ToList();

                foreach (var item in orderDetailsResults)
                {
                    item.Discount = pNewDiscount;
                    context.Entry(item).State = EntityState.Modified;
                }

                Console.WriteLine(context.SaveChanges());
            }
        }

        public void ApplyDiscount2(int pCustomerIdentifier, float pCurrentDiscount, float pNewDiscount)
        {
            using (var context = new NorthWindContext())
            {
                context.Configuration.AutoDetectChangesEnabled = false;
                context.Configuration.LazyLoadingEnabled = false;

                var orderDetailsResults = (from order in context.Orders
                    join orderDetail in context.Order_Details on order.OrderID equals orderDetail.OrderID
                    where order.CustomerIdentifier == pCustomerIdentifier
                    select orderDetail).AsNoTracking().ToList();

                orderDetailsResults = orderDetailsResults
                    .DistinctBy(details => details.OrderID)
                    .Where(details => details.Discount == pCurrentDiscount)
                    .ToList();

                foreach (var item in orderDetailsResults) 
                {
                    item.Discount = pNewDiscount;
                    context.Entry(item).State = EntityState.Modified;
                }

                Console.WriteLine(context.SaveChanges());
            }
        }
        public void ApplyDiscount3(int pCustomerIdentifier, float pCurrentDiscount, float pNewDiscount)
        {
            using (var context = new NorthWindContext())
            {
                context.Configuration.AutoDetectChangesEnabled = false;
                context.Configuration.LazyLoadingEnabled = false;

                var orderDetailsResults = (from order in context.Orders
                    join orderDetail in context.Order_Details on order.OrderID equals orderDetail.OrderID
                    where order.CustomerIdentifier == pCustomerIdentifier
                    select orderDetail)
                    .AsNoTracking()
                    .ToList();

                orderDetailsResults = orderDetailsResults
                    .Where(details => details.Discount == pCurrentDiscount)
                    .ToList();

                foreach (var item in orderDetailsResults)
                {
                    item.Discount = pNewDiscount;
                    context.Entry(item).State = EntityState.Modified;
                }

                Console.WriteLine(context.SaveChanges());
            }
        }
    }
}
