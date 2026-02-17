using ControllerBaseApi.Entities;

namespace ControllerBaseApi.Data
{
    public class ProductRepository
    {
        private List<Product> _products =
         [
            new Product { Id = 1, Name = "iPhone 15 Pro", Price = 1199.99m },
            new Product { Id = 2, Name = "Samsung Galaxy S24", Price = 999.99m },
            new Product { Id = 3, Name = "Sony WH-1000XM5 Headphones", Price = 349.99m },
            new Product { Id = 4, Name = "Dell XPS 15 Laptop", Price = 1899.00m },
            new Product { Id = 5, Name = "Logitech MX Master 3S Mouse", Price = 99.99m },
            new Product { Id = 6, Name = "Apple Watch Series 9", Price = 429.00m },
            new Product { Id = 7, Name = "iPad Air 5", Price = 699.00m },
            new Product { Id = 8, Name = "HP LaserJet Pro Printer", Price = 249.00m },
            new Product { Id = 9, Name = "Canon EOS R50 Camera", Price = 879.00m },
            new Product { Id = 10, Name = "ASUS TUF Gaming Monitor 27\"", Price = 329.00m }
         ];

        private List<ProductReview> _reviews =
        [
            new ProductReview { Id = 1, ProductId = 1, Reviewer = "Mohamed", Stars = 5 },
            new ProductReview { Id = 2, ProductId = 1, Reviewer = "Ahmed", Stars = 4 },
            new ProductReview { Id = 3, ProductId = 2, Reviewer = "Sara", Stars = 3 },
            new ProductReview { Id = 4, ProductId = 3, Reviewer = "Omar", Stars = 5 },
            new ProductReview { Id = 5, ProductId = 3, Reviewer = "Mona", Stars = 4 },
            new ProductReview { Id = 6, ProductId = 4, Reviewer = "Hassan", Stars = 5 },
            new ProductReview { Id = 7, ProductId = 5, Reviewer = "Yasmine", Stars = 4 },
            new ProductReview { Id = 8, ProductId = 6, Reviewer = "Ali", Stars = 2 },
            new ProductReview { Id = 9, ProductId = 7, Reviewer = "Karim", Stars = 5 },
            new ProductReview { Id = 10, ProductId = 8, Reviewer = "Nour", Stars = 4 }
        ];

        public List<Product> GetProductsPage(int page = 1, int pageSize = 10)
        {
            var products = _products.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            return products;
        }

        public Product? GetProductById(int id)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);
            if (product == null)
                return null;
            return product;
        }

        public List<ProductReview> GetReviewsByProductId(int productId)
        {
            return _reviews.Where(r => r.ProductId == productId).ToList();
        }

        public ProductReview? GetReview(int productId, int reviewId)
        {
            var review = _reviews.FirstOrDefault(r => r.ProductId == productId && r.Id == reviewId);
            if (review == null)
                return null;
            return review;
        }

        public bool AddProduct(Product product)
        {
            if (product == null)
                return false;
            _products.Add(product);
            return true;

        }

        public bool AddReview(ProductReview review)
        {
            if (!_products.Any(p => p.Id == review.ProductId))
                return false;
            _reviews.Add(review);
            return true;
        }

        public bool UpdateProduct(Product updatedProduct)
        {
            var product = _products.FirstOrDefault(p => p.Id == updatedProduct.Id);
            if (product == null)
                return false;
            product.Name = updatedProduct.Name;
            product.Price = updatedProduct.Price;
            return true;
        }

        public bool DeleteProduct(int id)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);
            if (product == null)
                return false;
            _products.Remove(product);

            _reviews.RemoveAll(r => r.ProductId == id);
            return true;
        }

        public bool ExistsById(int id) => _products.Any(p => p.Id == id);
        public bool ExistsByName(string name) => _products.Any(p => p.Name == name);
    }
}

    