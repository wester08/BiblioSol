

namespace BiblioSol.Shared.Dtos
{
    public class GetCategoryResponseDto
    {
        public IEnumerable<CategoryDto> Categories { get; set; } = Enumerable.Empty<CategoryDto>();
    }

}
