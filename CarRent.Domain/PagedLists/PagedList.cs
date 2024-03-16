namespace CarRent.Domain.PagedLists;

public class PagedList<T> : IPagedList<T>
{
    public int IndexFrom { get; set; }
    public int PageIndex { get; set; }
    public int PageSize { get; set; }
    public int TotalCount { get; set; }
    public int TotalPages { get; set; }
    public IList<T> Items { get; set; }
    public bool HasPreviousPage { get; set; }
    public bool HasNextPage { get; set; }


    internal PagedList(IEnumerable<T> source, int pageIndex, int pageSize, int indexFrom, int? totalCount = null)
    {
        if (indexFrom > pageIndex)
        {
            throw new ArgumentException(
                $"indexFrom: {indexFrom} > pageIndex: {pageIndex}, must indexFrom <= pageIndex");
        }

        if (source is IQueryable<T> queryable)
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
            IndexFrom = indexFrom;
            TotalCount = totalCount ?? queryable.Count();
            TotalPages = (int)Math.Ceiling(TotalCount / (double)PageSize);
            Items = queryable.Skip((PageIndex - IndexFrom) * PageSize).Take(PageSize).ToList();
        }
        else
        {
            var enumerable = source.ToList();
            PageIndex = pageIndex;
            PageSize = pageSize;
            IndexFrom = indexFrom;
            TotalCount = totalCount ?? enumerable.Count;
            TotalPages = (int)Math.Ceiling(TotalCount / (double)PageSize);
            Items = enumerable
                .Skip((PageIndex - IndexFrom) * PageSize)
                .Take(PageSize)
                .ToList();
        }
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="PagedList{T}" /> class.
    /// </summary>
    internal PagedList() => Items = Array.Empty<T>();

    /// <summary>
    /// Creates an instance with predefined parameters.
    /// </summary>
    /// <param name="source"></param>
    /// <param name="pageIndex"></param>
    /// <param name="pageSize"></param>
    /// <param name="indexFrom"></param>
    /// <param name="count"></param>
    public PagedList(
        IEnumerable<T> source,
        int pageIndex,
        int pageSize,
        int indexFrom,
        int count)
    {
        PageIndex = pageIndex;
        PageSize = pageSize;
        IndexFrom = indexFrom;
        TotalCount = count;
        Items = source.ToList();
        TotalPages = (int)Math.Ceiling(count / (double)pageSize);
    }
}
