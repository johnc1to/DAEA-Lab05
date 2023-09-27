using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab05
{
    public class DetalleCliente
    {
        public string? Idcliente { get; set; }
        public string? Nombrecompañia { get; set; }
        public string? Nombrecontacto { get; set; }
        public string? Cargocontacto { get; set; }
        public string? Direccion { get; set; }
        public string? Ciudad { get; set; }
        public string? Region { get; set; }
        public string? Codpostal { get; set; }
        public string? Pais { get; set; }
        public string? Telefono { get; set; }
        public string? Fax { get; set; }
        public string? Activo { get; set; }
    }

    public class Clientes
    {
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public List<DetalleCliente> Detalles { get; set; }

        public Clientes()
        {
            Detalles = new List<DetalleCliente>();
        }
    }
}