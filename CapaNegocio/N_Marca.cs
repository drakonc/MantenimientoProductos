using CapaDatos;
using CapaEntidades;
using System.Collections.Generic;

namespace CapaNegocio
{
    public class N_Marca
    {
        D_Marca objDato = new D_Marca();

        public List<E_Marca>ListarMarcas(string buscar)
        {
            return objDato.ListarMarcas(buscar);
        }

        public void InsertarMarca(E_Marca Marca)
        {
            objDato.InsertarMarca(Marca);
        }

        public void EditarMarca(E_Marca Marca)
        {
            objDato.EditarMarca(Marca);
        }

        public void EliminarMarca(E_Marca Marca)
        {
            objDato.EliminarMarca(Marca);
        }
    }
}
