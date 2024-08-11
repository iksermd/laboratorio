using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaPOS.Models
{
    public class ClienteModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }

        public List<DireccionModel> Direcciones { get; set; }
    }

    public class DireccionModel
    {
        public int Id { get; set; }
        public string Calle { get; set; }
        public string Ciudad { get; set; }
        public string Departamento { get; set; }
        public int ClienteId { get; set; }
    }
}
