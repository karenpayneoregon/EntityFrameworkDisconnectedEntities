using System.Collections.Generic;
using System.Linq;

namespace EntityLibrary.Classes
{
    public class DeferredExecution
    {
        /// <summary>
        /// Only setup a DbContext with the understanding they
        /// this entails memory usage and caching of data unlike
        /// when implementing with a local using statement.
        /// </summary>
        protected NorthWindContext _context = new NorthWindContext();

        /// <summary>
        /// This is a perfect good query to return all products which will
        /// throw an exception
        ///
        /// The operation cannot be completed because the DbContext has been disposed.
        ///
        /// This is because a "using" statement was used, once the return statement has
        /// been reached the DbContext has been disposed as indicated in the exception
        /// message, no different from any using statement's resources like when
        /// using a connection object for SqlClientConnection or SqlClientCommand.
        /// </summary>
        /// <returns>
        /// IQueryable of Products which since there is no explicit type the caller
        /// must cast e.g.
        /// 
        /// var results = ops.GetProductsIQueryable1();
        /// var resultsList = results.Cast&lt;List&lt;Product&gt;&gt;().ToList();
        ///
        /// Alternately but since the DbContext has been disposed, same error.
        /// var results = ops.GetProductsIQueryable1().Cast&lt;List&lt;Product&gt;&gt;().ToList();
        /// 
        /// </returns>
        public IQueryable GetProductsIQueryable1()
        {
            using (var context = new NorthWindContext())
            {
                return from product in context.Products select product;
            }
        }
        /// <summary>
        /// Return all products which will not actually return any
        /// data until back in the calling button click event.
        ///
        /// Does not fall as the first method above does as a active context
        /// Created as class level in this case
        /// </summary>
        /// <returns></returns>
        public IQueryable<Product> GetProductsIQueryable2() 
        {
            return from product in _context.Products select product;
        }
        /// <summary>
        /// This version disposes the DbContext so if we needed to
        /// update information we would need to create a new instance
        /// of the DbContext and attach to, in this case Products.
        /// </summary>
        /// <returns></returns>
        public List<Product> GetProductsAsList() 
        {
            using (var context = new NorthWindContext())
            {
                context.Configuration.LazyLoadingEnabled = false;
                return (from product in context.Products select product).ToList();
            }
        }
    }
}
