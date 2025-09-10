namespace PruebaCRUD1.DTOs
{
    public class ResponseDto
    {
        public bool Success { get; set; }
        public string? Message { get; set; }
        public string? ExcepcionMessage { get; set; }
        public dynamic? Datos { get; set; }

    }
}
