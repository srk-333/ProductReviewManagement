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
            Console.ReadKey();
        }
        //Method to Invoke Product Management class
        public static void InvokeProductManag()
        {
            ProductManagement p = new ProductManagement();
            var products =  p.AddMultipleProductReviewList();
            p.IterateOverProductList(products);
            p.RetrieveTop3Records(products);
            p.GetRecordesAsPerRatingsAndProductId(products);
            p.CountOfRecordsByProductId(products);
            p.RecordsByProductIdAndReview(products);
            p.SkipTop5Records(products);
            Console.WriteLine("Work on Data Table ");
            DisplayProducts.CreateDataTable();
            DisplayProducts.GetDataFromDataTable();
            DisplayProducts.GetAllLikedReviews();
            DisplayProducts.AverageRatingOfEachProductId(products);
            DisplayProducts.RecordWithReviewGood(products);
            DisplayProducts.RetrieveRecordsWithUserId10(products);             
        }     
    }
}