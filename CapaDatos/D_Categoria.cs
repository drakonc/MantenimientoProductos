using System.Data;
using CapaEntidades;
using System.Configuration;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace CapaDatos
{
    public class D_Categoria
    {
        SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);

        public List<E_Categoria>ListarCategorias(string buscar)
        {
            SqlDataReader LeerFilas;
            SqlCommand cmd = new SqlCommand("SP_BUSCARCATEGORIA",conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();
            cmd.Parameters.AddWithValue("@BUSCAR",buscar);
            LeerFilas = cmd.ExecuteReader();
            List<E_Categoria> Listar = new List<E_Categoria>();
            while (LeerFilas.Read())
            {
                Listar.Add(new E_Categoria
                {
                    IdCategoria = LeerFilas.GetInt32(0),
                    CodigoCategoria = LeerFilas.GetString(1),
                    NombreCategoria = LeerFilas.GetString(2),
                    DescripcionCategoria = LeerFilas.GetString(3),
                });
            }
            conexion.Close();
            LeerFilas.Close();
            return Listar;
        }

        public void InsertarCategoria(E_Categoria Categoria)
        {
            SqlCommand cmd = new SqlCommand("SP_INSAERTARCATEGORIA", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open(); 
            cmd.Parameters.AddWithValue("@NOMBRE", Categoria.NombreCategoria);
            cmd.Parameters.AddWithValue("@DESCRIPCION", Categoria.DescripcionCategoria);
            cmd.ExecuteNonQuery();
            conexion.Close();
        }

        public void EditarCategoria(E_Categoria Categoria)
        {
            SqlCommand cmd = new SqlCommand("SP_EDITARCATEGORIA", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();
            cmd.Parameters.AddWithValue("@IDCATEGORIA", Categoria.IdCategoria);
            cmd.Parameters.AddWithValue("@NOMBRE", Categoria.NombreCategoria);
            cmd.Parameters.AddWithValue("@DESCRIPCION", Categoria.DescripcionCategoria);
            cmd.ExecuteNonQuery();
            conexion.Close();
        }

        public void EliminarCategoria(E_Categoria Categoria)
        {
            SqlCommand cmd = new SqlCommand("SP_ELIMINARCATEGORIA", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();
            cmd.Parameters.AddWithValue("@IDCATEGORIA", Categoria.IdCategoria);
            cmd.ExecuteNonQuery();
            conexion.Close();
        }
    }

}
