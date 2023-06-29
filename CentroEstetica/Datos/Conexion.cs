using System.Data.SqlClient;
namespace CentroEstetica.Datos
{
    public class Conexion
    {  
        private string cadenaSQl = string.Empty;
        public Conexion()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();

            cadenaSQl = builder.GetSection("ConnectionStrings:CadenaSQl").Value; 

        } 

        public string getCadenaSQL()
        {
            return cadenaSQl;
        }

    }
}
