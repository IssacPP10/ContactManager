using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManager
{
    public class connection
    {
        public static string GetConnectionString()
        {
            // Paso 1: Obtener la ruta de la carpeta 'AppData'
            string appDataDirectory = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "ContactManager");

            // Paso 2: Crear el directorio si no existe
            Directory.CreateDirectory(appDataDirectory);  // Si el directorio no existe, lo crea

            // Paso 3: Especificar la ruta de la base de datos
            string databasePath = System.IO.Path.Combine(appDataDirectory, "contacts.db");

            // Paso 4: Verificar si el archivo de base de datos existe
            if (File.Exists(databasePath))
            {
                Console.WriteLine("El archivo de base de datos existe en: " + databasePath);
            }
            else
            {
                Console.WriteLine("El archivo de base de datos NO existe en: " + databasePath);
            }

            // Paso 5: Usar la ruta en la cadena de conexión de SQLite
            Console.WriteLine("Esta es la ruta de la base de datos: " + databasePath);
            return $"Data Source={databasePath};Version=3;";
        }
    }
}
