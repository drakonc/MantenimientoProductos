using System.Data;
using CapaEntidades;
using System.Configuration;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace CapaDatos
{
    public class D_Marca
    {
        SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);

        public List<E_Marca> ListarMarcas(string buscar)
        {
            SqlDataReader LeerFilas;
            SqlCommand cmd = new SqlCommand("SP_BUSCARMARCA", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();
            cmd.Parameters.AddWithValue("@BUSCAR", buscar);
            LeerFilas = cmd.ExecuteReader();
            List<E_Marca> Listar = new List<E_Marca>();
            while (LeerFilas.Read())
            {
                Listar.Add(new E_Marca
                {
                    IdMarca = LeerFilas.GetInt32(0),
                    CodigoMarca = LeerFilas.GetString(1),
                    NombreMarca = LeerFilas.GetString(2),
                    DescripcionMarca = LeerFilas.GetString(3)
                }); ;
            }
            conexion.Close();
            LeerFilas.Close();
            return Listar;
        }

        public void InsertarMarca(E_Marca Marca)
        {
            SqlCommand cmd = new SqlCommand("SP_INSAERTARMARCA", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();
            cmd.Parameters.AddWithValue("@NOMBRE", Marca.NombreMarca);
            cmd.Parameters.AddWithValue("@DESCRIPCION", Marca.DescripcionMarca);
            cmd.ExecuteNonQuery();
            conexion.Close();
        }

        public void EditarMarca(E_Marca Marca)
        {
            SqlCommand cmd = new SqlCommand("SP_EDITARMARCA",conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();
            cmd.Parameters.AddWithValue("@IDMARCA", Marca.IdMarca);
            cmd.Parameters.AddWithValue("@NOMBRE", Marca.NombreMarca);
            cmd.Parameters.AddWithValue("@DESCRIPCION", Marca.DescripcionMarca);
            cmd.ExecuteNonQuery();
            conexion.Close();
        }

        public void EliminarMarca(E_Marca Marca)
        {
            SqlCommand cmd = new SqlCommand("SP_ELIMINARMARCA", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();
            cmd.Parameters.AddWithValue("@IDMARCA", Marca.IdMarca);
            cmd.ExecuteNonQuery();
            conexion.Close();
        }

    }
}
