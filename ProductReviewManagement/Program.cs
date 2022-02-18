using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductReviewManagement
{
    public class Program
    {
        //Entry Point
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Product Review Management");
            InvokeProductManag();
            //DisplayProducts.CreateDataTable();
            Console.ReadKey();
        }
        //Method to Invoke Product Management class
        public static void InvokeProductManag()
        {
            ProductManagement p = new ProductManagement();
            var products =  p.AddMultipleProductReviewList();
            //p.IterateOverProductList(products);
            p.RetrieveTop3Records(products);
        }
    }
}