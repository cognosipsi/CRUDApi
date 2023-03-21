namespace APIsinPlantilla.Connection
{
    public class DBConnection
    {
        private string connectionString = string.Empty;
        public DBConnection()
        {
            //Construir(build) conexion con appsettings.json
            var builder = new ConfigurationBuilder().SetBasePath
                (Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            //Obtener datos desde el appsettings.json
            connectionString = builder.GetSection("ConnectionStrings:conexionMaestra").Value;
            /*Este archivo va a estar protegidoa través de appsettings.json, 
             * aquí solo se accede a este*/
        }

        //Para que sea reconocido desde cualquier parte de nustro proyecto:
        public string cadenaSQL()
        {
            return connectionString;
        }

    }
}


