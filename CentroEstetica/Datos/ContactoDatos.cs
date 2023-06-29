using CentroEstetica.Models;
using System.Data.SqlClient;
using System.Data;
namespace CentroEstetica.Datos
{
    public class ContactoDatos
    {
        public List<ClienteModel> Listar()
        {
            var oLista = new List<ClienteModel>();

            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_listar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oLista.Add(new ClienteModel()
                        {
                            IdCliente = Convert.ToInt32(dr["IdCliente"]),
                            Nombre = dr["Nombre"].ToString(),
                            Telefono = dr["Telefono"].ToString(),
                            Correo = dr["Correo"].ToString()
                        });
                    }
                }
            }
            return oLista;
        }
        public ClienteModel Obtener(int IdCliente)
        {
            var oCliente = new ClienteModel();

            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_Obtener", conexion);
                cmd.Parameters.AddWithValue("IdCliente", IdCliente);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        IdCliente = Convert.ToInt32(dr["IdCliente"]);
                        oCliente.Nombre = dr["Nombre"].ToString();
                        oCliente.Telefono = dr["Telefono"].ToString();
                        oCliente.Correo = dr["Correo"].ToString();
                    }
                }
            }
            return oCliente;

        }
        public bool Guardar(ClienteModel ocliente) {
            bool rpta;
            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_Guardar", conexion);
                    cmd.Parameters.AddWithValue("Nombre", ocliente.Nombre);
                    cmd.Parameters.AddWithValue("Telefono", ocliente.Telefono);
                    cmd.Parameters.AddWithValue("Correo", ocliente.Correo); 
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                    
                }
                rpta = true;
            }
            catch(Exception e) 
            { 
                string error = e.Message;
                rpta= false;

            }
            return rpta;

        }
        public bool Editar(ClienteModel ocliente)
        {
            bool rpta;
            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_Editar", conexion);
                    cmd.Parameters.AddWithValue("IdCliente", ocliente.IdCliente);
                    cmd.Parameters.AddWithValue("Nombre", ocliente.Nombre);
                    cmd.Parameters.AddWithValue("Telefono", ocliente.Telefono);
                    cmd.Parameters.AddWithValue("Correo", ocliente.Correo);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();

                }
                rpta = true;
            }
            catch (Exception e)
            {
                string error = e.Message;
                rpta = false;

            }
            return rpta;

        }
        public bool Eliminar(int IdCliente)
        {
            bool rpta;
            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_Eliminar", conexion);
                    cmd.Parameters.AddWithValue("IdCliente", IdCliente);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();

                }
                rpta = true;
            }
            catch (Exception e)
            {
                string error = e.Message;
                rpta = false;

            }
            return rpta;

        }






    }
}
