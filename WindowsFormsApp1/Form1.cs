using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EntityLibrary;
using EntityLibrary.Classes;

namespace WindowsFormsApp1
{
    /// <summary>
    /// Returning data from Entity are declared explicitly as
    /// we are interested in types and deferred execution of
    /// the data returning via Entity Framework from SQL-Server.
    /// </summary>
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Throw exception
        /// The operation cannot be completed because the DbContext has been disposed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GetProductsIQueryableWithExceptionButton_Click(object sender, EventArgs e)
        {
            var ops = new DeferredExecution();
            try
            {
                List<List<Product>> results = ops.GetProductsIQueryable1()
                    .Cast<List<Product>>()
                    .ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show($"The following was an expected exception\n{ex.Message}");
            }
        }
        /// <summary>
        /// Does not throw
        /// 
        /// The operation cannot be completed because the DbContext has been disposed.
        /// As unlike the above code sample a live DbContext is still available.
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GetProductsIQueryableWithoutExceptionButton_Click(object sender, EventArgs e)
        {
            var ops = new DeferredExecution();

            List<Product> results = ops.GetProductsIQueryable2()
                .ToList();
        }
        /// <summary>
        /// In the last example above an exception is thrown when executed
        /// while this code example will not throw an exception because .ToList
        /// executed the query unlike GetProductsIQueryable2 method.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GetProductsToListWithoutExceptionButton_Click(object sender, EventArgs e)
        {
            var ops = new DeferredExecution();
            try
            {
                List<Product> results = ops.GetProductsAsList()
                    .ToList();

                MessageBox.Show(results.Count.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show($"The following was an expected exception\n{ex.Message}");
            }
        }
        private void ImmediateExecutionButton_Click(object sender, EventArgs e)
        {
            var ops = new ImmediateExecution();
            ops.ApplyDiscount3(1, (float) .45, (float) .25);
        }
    }
}
