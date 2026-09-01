using System.ComponentModel.DataAnnotations;

namespace CARS.Models
{
    public class Vehiculo
    {
        [Key]
        public int IdVehiculo { get; set; }
        public string Placa { get; set; } = string.Empty;
        public string Marca { get; set; } = string.Empty;
        public string Modelo { get; set; } = string.Empty;
        public string Anio { get; set; } = string.Empty;
        public decimal Precio { get; set; }
        public bool Estado { get; set; }
        public int IdCategoria { get; set; }
    }
}