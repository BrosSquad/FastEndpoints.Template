using TemplateFastEndpoints.API.Utils;

namespace TemplateFastEndpoints.API.Extensions;

public static class PaginationExtensions
{
    /// <summary>
    /// Extension method to paginate a source collection.
    /// </summary>
    /// <typeparam name="T">The type of the elements in the source.</typeparam>
    /// <param name="source">The source collection to paginate. Can be IQueryable or IEnumerable.</param>
    /// <param name="pageNumber">The page number to retrieve.</param>
    /// <param name="pageSize">The page size (number of items per page).</param>
    /// <returns>A paginated response containing the items on the requested page and pagination information.</returns>
    public static PaginatedResponse<T> ToPaginatedResult<T>(this IEnumerable<T> source, int pageNumber, int pageSize) where T : class
    {
        var enumerable = source as IQueryable<T> ?? source.AsQueryable();
        var items = enumerable.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();

        var totalRecords = enumerable.Count();
        var totalPages = (int)Math.Ceiling((double)totalRecords / pageSize);
        return new PaginatedResponse<T>(items, pageNumber, pageSize, totalPages, totalRecords);
    }
}