using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    public class E_Marca
    {
        private int __IdMarca;
        private string _CodigoMarca;
        private string _NombreMarca;
        private string _DescripcionMarca;

        public int IdMarca { get => __IdMarca; set => __IdMarca = value; }
        public string CodigoMarca { get => _CodigoMarca; set => _CodigoMarca = value; }
        public string NombreMarca { get => _NombreMarca; set => _NombreMarca = value; }
        public string DescripcionMarca { get => _DescripcionMarca; set => _DescripcionMarca = value; }
    }
}
