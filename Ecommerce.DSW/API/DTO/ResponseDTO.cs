namespace API.DTO
{
    public class ResponseDTO<T>
    {
        public T? Resultado { get; set; }
        public bool Correcto { get; set; }
        public string? Mensaje { get; set; }
    }
}
