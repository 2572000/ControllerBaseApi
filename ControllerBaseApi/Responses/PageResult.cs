namespace ControllerBaseApi.Responses
{
    public class PageResult<T>
    {
        public IEnumerable<T> Data { get; set; }
        public int TotalCount { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public int TotalPage => (int)Math.Ceiling(TotalCount / (double)PageSize);
        public bool HasPreviousPage => CurrentPage > 1;
        public bool HasNextPage => CurrentPage < TotalPage;

        private PageResult()
        {
            
        }

        public static PageResult<T> Create(IEnumerable<T> data,int totalCount,int page,int pageSize)
        {
            return new PageResult<T>
            {
                Data = data,
                TotalCount = totalCount,
                CurrentPage = page,
                PageSize = pageSize

            };
        }

    }
}
