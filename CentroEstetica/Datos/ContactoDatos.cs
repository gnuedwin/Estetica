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

            using(var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_listar", conexion); 
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oLista.Add(new ClienteModel() { 
                            IdCliente = Convert.ToInt32(dr["IdCliente"]),
                            Nombre = dr["Nombre"].ToString(),
                            Telefono = dr["Telefono"].ToString(),
                            Correo = dr["Correo"].ToString()
                        });
                    }
                }
            }
        }

    }
}
