using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace ProductReviewManagement
{
    public class DisplayProducts
    {
        public static DataTable table = new DataTable();
        /// Creates the data table.
        public static void CreateDataTable()
        {         
            //Add Columns in Table
            table.Columns.Add("ProductId");
            table.Columns.Add("UserId");
            table.Columns.Add("Rating");
            table.Columns.Add("Review");
            table.Columns.Add("IsLike");
            //Add Rows in Table
            table.Rows.Add(1, 12, 12, "bad", "false");
            table.Rows.Add(2, 8, 5, "good", "true");
            table.Rows.Add(4, 7, 6, "good", "false");
            table.Rows.Add(7, 4, 2, "nice", "true");
            table.Rows.Add(5, 7, 7, "bad", "false");
            table.Rows.Add(7, 6, 8, "nice", "true");
            table.Rows.Add(2, 5, 19, "good", "false");
            table.Rows.Add(3, 14, 20, "good", "false");
            table.Rows.Add(8, 10, 15, "bad", "true");
            table.Rows.Add(9, 11, 18, "good", "false");
            table.Rows.Add(3, 9, 22, "good", "false");
            table.Rows.Add(1, 8, 26, "bad", "true");
        }
        /// Gets the data from data table.
        public static void GetDataFromDataTable()
        {
            try
            {
                //Query syntax of LINQ
                var ProductNames = from product in table.AsEnumerable() select product;
                //iterate loop to get ProductName.
                foreach (var data in ProductNames)
                {
                    Console.WriteLine("ProductID: " + data.Field<string>("ProductId") + ", UserID: " + data.Field<string>("UserId") + ", Ratings: " + data.Field<string>("Rating") + " , Review: " + data.Field<string>("Review") + " , IsLike: " + data.Field<string>("IsLike"));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        //method to getll all liked reviews
        public static void GetAllLikedReviews()
        {
            var stringTable = from product in table.AsEnumerable()
                              where (string)product["IsLike"] == "true"
                              select product;

            Console.WriteLine("\n");
            foreach (var list in stringTable)
            {
                Console.WriteLine("ProductID: " + list.Field<string>("ProductId") + ", UserID: " + list.Field<string>("UserId") + ", Rating: " + list.Field<string>("Rating") + " , Review: " + list.Field<string>("Review") + " , IsLike: " + list.Field<string>("IsLike"));
            }
        }
        //get average rating rating of each product ID
        public static void AverageRatingOfEachProductId(List<ProductReview> ProductReview)
        {
            var data = from productReviews in ProductReview
                       group productReviews by productReviews.ProductId into g
                       select new
                       {
                           ProductID = g.Key,
                           AverageRating = g.Average(x => x.Rating)
                       };
            Console.WriteLine("\n");
            Console.WriteLine("\nProductID AverageRating");
            foreach (var l in data)
            {
                Console.WriteLine(l.ProductID + " ----------- " + l.AverageRating);
            }
        }
        // all  records with nice review
        public static void RecordWithReviewGood(List<ProductReview> ProductReview)
        {
            var data = from productReviews in ProductReview
                       where (productReviews.Review == "nice")
                       select productReviews;
            Console.WriteLine("\n");
            foreach (var list in data)
            {
                Console.WriteLine("ProductID: " + list.ProductId + " UserID: " + list.UserId + " Rating: " + list.Rating + " Review: " + list.Review + " isLike: " + list.IsLike);
            }
        }
        //Get Records for UserId 10.
        public static void RetrieveRecordsWithUserId10(List<ProductReview> ProductReview)
        {
            var data = from productReviews in ProductReview
                       where productReviews.UserId == 10
                       orderby productReviews.Rating ascending
                       select productReviews;
            Console.WriteLine("\n");
            foreach (var list in data)
            {
                Console.WriteLine("ProductID: " + list.ProductId + " UserID: " + list.UserId + " Rating: " + list.Rating + " Review: " + list.Review + " isLike: " + list.IsLike);
            }
        }
    }
}