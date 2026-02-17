namespace ControllerBaseApi.Entities
{
    public class ProductReview
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string? Reviewer { get; set; }
        public int Stars { get; set; }
    }
}
