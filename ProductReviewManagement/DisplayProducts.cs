using System;
using System.Data;
using System.Linq;

namespace ProductReviewManagement
{
    public class DisplayProducts
    {
        /// <summary>
        /// Creates the data table.
        /// </summary>
        public static void CreateDataTable()
        {
            //create obj of DataTable Class.
            DataTable table = new DataTable();
            //Add Columns in Table
            table.Columns.Add("Id");
            table.Columns.Add("ProductName");
            //Add Rows in Table
            table.Rows.Add(1, "Laptop");
            table.Rows.Add(2, "Desktop");
            table.Rows.Add(3, "Tab");
            GetDataFromDataTable(table);
        }
        /// <summary>
        /// Gets the data from data table.
        /// </summary>
        /// <param name="table">The table.</param>
        public static void GetDataFromDataTable(DataTable table)
        {
            //Query syntax of LINQ
            var ProductNames = (from product in table.AsEnumerable() select product.Field<string>("ProductName"));
            //iterate loop to get ProductName.
            foreach (string p in ProductNames)
            {
                Console.WriteLine("Product Name:"+p);
            }
        }
    }
}