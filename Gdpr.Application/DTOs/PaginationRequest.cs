public class PaginationRequest
{
    public string? Filter { get; set; }
    public int PageNumber { get; set; } = 1;

    private int _pageSize = 10;
    public int PageSize
    {
        get => _pageSize;
        set => _pageSize = value > 50 ? 50 : value; // max limit
    }
}