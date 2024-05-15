namespace TemplateFastEndpoints.API.Utils;

public class PaginatedResponse<T> where T : class
{
    public PaginatedResponse(IEnumerable<T> data, int pageNumber, int pageSize,int totalPages, int totalRecords)
    {
        Data = data;
        PageNumber = pageNumber;
        PageSize = pageSize;
        TotalPages = totalPages;
        TotalRecords = totalRecords;
    }

    public IEnumerable<T> Data { get; set; }
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
    public int TotalPages { get; set; }
    public int TotalRecords { get; set; }
}