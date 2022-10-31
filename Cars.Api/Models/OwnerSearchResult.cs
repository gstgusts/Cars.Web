namespace Cars.Api.Models
{
    public class OwnerSearchResult
    {
        public List<OwnerSearchDto> Results { get; set; } = new List<OwnerSearchDto>();

        public PaginationDto Pagination { get; set; }
    }
}
