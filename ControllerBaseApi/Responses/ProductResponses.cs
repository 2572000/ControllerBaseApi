using ControllerBaseApi.Entities;

namespace ControllerBaseApi.Responses
{
    public class ProductResponses
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public decimal Price { get; set; }
        public List<ProductReviewResponse>? Reviews { get; set; } = new List<ProductReviewResponse>();

        private ProductResponses()
        {
            
        }

        public static ProductResponses FromModel(Product? product, IEnumerable<ProductReview>? reviews=null)
        {
            if (product == null)
                throw new ArgumentNullException(nameof(product), "Product cannot be null.");

            var response = new ProductResponses
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price
            };

            if (reviews != null)
            {
                response.Reviews = ProductReviewResponse.FromModelList(reviews).ToList();
            }
            return response;
        }

        public static IEnumerable<ProductResponses> FromModelList(IEnumerable<Product> products)
        {
            if(products == null)
                throw new ArgumentNullException(nameof(products), "Products collection cannot be null.");
            return products.Select(p=>FromModel(p));
        }
    }
}
