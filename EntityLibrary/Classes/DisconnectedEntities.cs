using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLibrary.Classes
{
    public class DisconnectedEntities
    {
        /// <summary>
        /// Create a new Product and add the new Product
        /// to the DbContext along with indicating this
        /// item is a new entity via the entry state
        /// </summary>
        public void AddProduct1() 
        {
            var product = new Product()
            {
                ProductName = "Headphones",
                CategoryID = 1,
                UnitPrice = 17.99M
            };

            using (var context = new NorthWindContext())
            {
                context.Entry(product).State = EntityState.Added;
            }
        }
        /// <summary>
        /// Create a new Product and add the new Product
        /// to the DbContext along with indicating this
        /// item is a new entity using Attach method
        /// </summary>
        public void AddProduct2()
        {
            var product = new Product()
            {
                ProductName = "Headphones",
                CategoryID = 1,
                UnitPrice = 17.99M
            };

            using (var context = new NorthWindContext())
            {
                context.Products.Attach(product);
            }
        }
        /// <summary>
        /// Create a new Product and add the new Product
        /// to the DbContext along with indicating this
        /// item is a new entity via the Add method
        /// </summary>
        public void AddProduct3()
        {
            var product = new Product()
            {
                ProductName = "Headphones",
                CategoryID = 1,
                UnitPrice = 17.99M
            };

            using (var context = new NorthWindContext())
            {
                context.Products.Add(product);
            }
        }

        public void DeleteProduct(Product product)
        {
            using (var context = new NorthWindContext())
            {
                context.Entry(product).State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Demonstrates multi-purpose method for add or update
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        public int AddOrUpdate(Product product)
        {
            using (var context = new NorthWindContext())
            {
                context.Entry(product).State = product.ProductID == 0 ? 
                    EntityState.Added : 
                    EntityState.Modified;

                return context.SaveChanges();
            }
        }
        /// <summary>
        /// Example for updating a disconnected entry indicating
        /// this is a modification by setting State property to Modified.
        /// </summary>
        /// <param name="product"></param>
        /// <param name="discontinued"></param>
        public void SaveProduct(Product product, bool discontinued)
        {
            using (var context = new NorthWindContext())
            {
                product.Discontinued = discontinued;
                context.Entry(product).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
