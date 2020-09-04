using CapaDatos;
using CapaEntidades;
using System.Collections.Generic;

namespace CapaNegocio
{
    public class N_Categoria
    {
        D_Categoria objDato = new D_Categoria();

        public List<E_Categoria> ListarCategorias(string buscar)
        {
            return objDato.ListarCategorias(buscar);
        }

        public void InsertarCategoria(E_Categoria Categoria)
        {
            objDato.InsertarCategoria(Categoria);
        }

        public void EditarCategoria(E_Categoria Categoria)
        {
            objDato.EditarCategoria(Categoria);
        }

        public void EliminarCategoria(E_Categoria Categoria)
        {
            objDato.EliminarCategoria(Categoria);
        }
    }
}
