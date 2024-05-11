namespace FCI.CleanEgypt.Contracts.ApiResponse.Pagination;

public class MetaData
{
    public int CurrentPage { get; init; }
    public int TotalPages { get; init; }
    public int PageSize { get; set; }
    public int TotalCount { get; set; }

    public bool HasPrevious => CurrentPage > 1;
    public bool HasNext => CurrentPage < TotalPages;
}