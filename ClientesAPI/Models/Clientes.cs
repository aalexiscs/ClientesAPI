namespace ClientesAPI.Models
{
    public class Clientes
    {
        public int ClienteID { get; set; }
        public required string Nombre { get; set; }
        public required string Apellido { get; set; }
        public string? Email { get; set; }
    }
}
