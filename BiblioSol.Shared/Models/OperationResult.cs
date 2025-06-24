

namespace BiblioSol.Shared.Models
{
    public class OperationResult<T>
    {
        public bool isSuccess { get; set; }
        public T? Data { get; set; }
        public string? Message { get; set; }
    }
}
