namespace Api.Helpers
{
    public class PagedList<T>: List<T>
    {
        public int TotalResults { get; private set; }
        public int CurrentPage { get; private set; }  
        public int PageSize { get; private set; }

        public PagedList(List<T> items, int total, int pageSize, int pageNumber) : base(items)
        {
            TotalResults = total;
            PageSize = pageSize;
            CurrentPage = pageNumber;
        }

        public static PagedList<T> BuildPageList(IQueryable<T> source, int pageSize, int pageNumber)
        {
            var count = source.Count();
            var items = source
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            return new PagedList<T>(items, count, pageSize, pageNumber);
        }
    }
}
