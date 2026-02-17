using ControllerBaseApi.Entities;
using Microsoft.AspNetCore.Mvc.ViewEngines;

namespace ControllerBaseApi.Responses
{
    public class ProductReviewResponse
    {
        public int ReviewId { get; set; }
        public int ProductId { get; set; }
        public string? Reviewer { get; set; }
        public int Stars { get; set; }

        private ProductReviewResponse() { }

        public static ProductReviewResponse FromModel(ProductReview? review)
        {
            if(review ==null)
                throw new ArgumentNullException(nameof(review), "Product review cannot be null.");

            return new ProductReviewResponse
            {
                ReviewId = review.Id,
                ProductId = review.ProductId,
                Reviewer = review.Reviewer,
                Stars = review.Stars
            };
        }

        public static IEnumerable<ProductReviewResponse> FromModelList(IEnumerable<ProductReview> reviews)
        {
           
            return reviews.Select(FromModel).ToList();
        }
    }
}