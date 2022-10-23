using System.Reflection;

namespace Api.Helpers
{
    public class QueryParams
    {
        private const int MaxPagesize = 100;

        private int _pageNumber;
        public int PageNumber
        {
            get { return _pageNumber < 1 ? 1 : _pageNumber; }
            set { _pageNumber = value; }
        }

        private int _pageSize;
        public int PageSize
        {
            get { return _pageSize < 1 ? 1 : _pageSize; }
            set { _pageSize = value > 100 ? MaxPagesize : value; }
        }

        public string? Sort { get; set; }

        public static ValueTask<QueryParams?> BindAsync(
            HttpContext context, ParameterInfo parameter)
        {
            const string sortKey = "sort";
            const string pageNumberKey = "pageNumber";
            const string PageSizeKey = "pageSize";

            int.TryParse(context.Request.Query[pageNumberKey], out var pageNumber);
            int.TryParse(context.Request.Query[PageSizeKey], out var pageSize);

            var result = new QueryParams()
            {
                PageNumber = pageNumber,
                PageSize = pageSize,
                Sort = context.Request.Query[sortKey],
            };

            return ValueTask.FromResult<QueryParams?>(result);
        }
    }
}
