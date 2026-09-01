using CARS.DATA;
using CARS.Models;
using CoreWCF;

namespace CARS.Services
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public class VehiculoService : IVehiculoService
    {
        private readonly CARSDBCONTEXT _carsDBContext;

        public VehiculoService(CARSDBCONTEXT carsDBContext)
        {
            _carsDBContext = carsDBContext;
        }

        public List<Categoria> ObtenerCategorias()
        {
            return _carsDBContext.Categorias.ToList();
        }

        public List<Vehiculo> ObtenerVehiculos()
        {
            return _carsDBContext.Vehiculos.ToList();
        }

        public Vehiculo? ObtenerVehiculo(int id)
        {
            return _carsDBContext.Vehiculos.FirstOrDefault(v => v.IdVehiculo == id);
        }

        public Vehiculo? AgregarVehiculo(Vehiculo vehiculo)
        {
            vehiculo.IdVehiculo = 0;
            _carsDBContext.Vehiculos.Add(vehiculo);
            _carsDBContext.SaveChanges();
            return vehiculo;
        }

        public Vehiculo? ActualizarVehiculo(Vehiculo vehiculo)
        {
            var vehiculoExistente = _carsDBContext.Vehiculos.FirstOrDefault(v => v.IdVehiculo == vehiculo.IdVehiculo);
            if (vehiculoExistente != null)
            {
                vehiculoExistente.Placa = vehiculo.Placa;
                vehiculoExistente.Marca = vehiculo.Marca;
                vehiculoExistente.Modelo = vehiculo.Modelo;
                vehiculoExistente.Anio = vehiculo.Anio;
                vehiculoExistente.Precio = vehiculo.Precio;
                vehiculoExistente.Estado = vehiculo.Estado;
                vehiculoExistente.IdCategoria = vehiculo.IdCategoria;

                _carsDBContext.SaveChanges();
            }
            return vehiculoExistente;
        }

        public bool EliminarVehiculo(int id)
        {
            var vehiculo = _carsDBContext.Vehiculos.Find(id);
            if (vehiculo == null)
            {
                return false;
            }
            _carsDBContext.Vehiculos.Remove(vehiculo);
            _carsDBContext.SaveChanges();
            return true;
        }

        public List<Vehiculo> ObtenerVehiculoPorMarca(string marca)
        {
            return _carsDBContext.Vehiculos.Where(v => v.Marca == marca).ToList();
        }

        public List<Vehiculo> ObtenerVehiculoPorCategoria(int idCategoria)
        {
            return _carsDBContext.Vehiculos.Where(v => v.IdCategoria == idCategoria).ToList();
        }
    }
}