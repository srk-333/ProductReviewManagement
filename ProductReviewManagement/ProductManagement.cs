using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductReviewManagement
{
    public class ProductManagement
    {
        //Method to Add Multiple Product in List.
        public List<ProductReview> AddMultipleProductReviewList()
        {
            List<ProductReview> products = new List<ProductReview>()
            {
                new ProductReview(){ ProductId=1,UserId=1,Review="good",Rating=11,IsLike=true },
                new ProductReview(){ ProductId=2,UserId=2,Review="bad",Rating=17,IsLike=false },
                new ProductReview(){ ProductId=3,UserId=5,Review="bad",Rating=13,IsLike=true },
                new ProductReview(){ ProductId=4,UserId=6,Review="good",Rating=1,IsLike=true },
                new ProductReview(){ ProductId=3,UserId=1,Review="good",Rating=2,IsLike=false },
                new ProductReview(){ ProductId=2,UserId=4,Review="bad",Rating=3,IsLike=false },
                new ProductReview(){ ProductId=1,UserId=2,Review="good",Rating=20,IsLike=true },
                new ProductReview(){ ProductId=1,UserId=5,Review="bad",Rating=21,IsLike=true },
                new ProductReview(){ ProductId=4,UserId=6,Review="good",Rating=23,IsLike=false },
                new ProductReview(){ ProductId=3,UserId=1,Review="bad",Rating=18,IsLike=true }
            };
            return products;
        }
        //Method to get all Product List
        public void IterateOverProductList(List<ProductReview> products)
        {
            foreach (ProductReview productReview in products)
            {
                Console.WriteLine("ProductId="+productReview.ProductId + "\t" + "UserId:"+productReview.UserId + "\t" + "Review:"+productReview.Review + "\t" +
                                  "Rating:"+productReview.Rating + "\t" + "IsLike:"+productReview.IsLike);
            }
        }
        //Method to Retrieve Top 3 records
        public void RetrieveTop3Records(List<ProductReview> products)
        {         
            try
            {
                //LINQ query
                var sortedRatings = (from product in products orderby product.Rating descending select product).ToList();
                Console.WriteLine("After Sorting");
                IterateOverProductList(sortedRatings);
                var top3Records = sortedRatings.Take(3).ToList();
                Console.WriteLine();
                Console.WriteLine("Get Top 3 Records");
                IterateOverProductList(top3Records);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}