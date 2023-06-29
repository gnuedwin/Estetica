using System.Data.SqlClient;
namespace CentroEstetica.Datos
{
    public class Conexion
    {  
        private string cadenaSQl = string.Empty;
        public Conexion()
        {
            var builder = new ConfigurationBinder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsetting.json").Build();
        }

    }
}
