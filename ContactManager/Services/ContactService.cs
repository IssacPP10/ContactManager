using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using ContactManager.Models;
using System.IO;

namespace ContactManager.Services
{
    public class ContactService
    {
        // Ruta de la base de datos (Relativa al directorio de ejecución)
        //private string connectionString = @"Data Source=Database\\contacts.db;Version=3;";
        
        // Ruta de la base de datos (Absoluta)
        //private string connectionString = @"Data Source=C:\Users\PC\source\repos\ContactManager\ContactManager\Database\contacts.db;Version=3;";

        // Ruta de la base de datos (Relativa al directorio de ejecución)
        private string connectionString = connection.GetConnectionString();

        // Crear la tabla y la base de datos si no existen
        public async Task InitializeDatabaseAsync()
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                await connection.OpenAsync(); // Conexión asincrona
                string sql = "CREATE TABLE IF NOT EXISTS Contacts (id INTEGER PRIMARY KEY, name TEXT, email TEXT, phone TEXT)";
                using (var command = new SQLiteCommand(sql, connection))
                {
                    await command.ExecuteNonQueryAsync();
                }
                connection.Close();
            }
        }

        // Agregar un nuevo contacto con async
        public async Task AddContactAsync(Contact contact)
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                await connection.OpenAsync();
                string sql = "INSERT INTO Contacts (name, email, phone) VALUES (@name, @email, @phone)";
                using (var command = new SQLiteCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@name", contact.name);
                    command.Parameters.AddWithValue("@email", contact.email);
                    command.Parameters.AddWithValue("@phone", contact.phone);
                    await command.ExecuteNonQueryAsync();
                }
                connection.Close();
            }
        }

        // Obtener todos los contactos con async
        public async Task<List<Contact>> GetContactsAsync()
        {
            var contacts = new List<Contact>();
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                await connection.OpenAsync();
                string sql = "SELECT * FROM Contacts";
                using (var command = new SQLiteCommand(sql, connection))
                {
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            Contact contact = new Contact();
                            contact.id = reader.GetInt32(0);
                            contact.name = reader.GetString(1);
                            contact.email = reader.GetString(2);
                            contact.phone = reader.GetString(3);
                            contacts.Add(contact);
                        }
                    }
                }
                connection.Close();
            }
            return contacts;
        }

        // Eliminar un contacto por id
        public async Task DeleteContact(int id)
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                await connection.OpenAsync();
                string sql = "DELETE FROM Contacts WHERE id = @id";
                using (var command = new SQLiteCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    await command.ExecuteNonQueryAsync();
                }
                connection.Close();
            }
        }

    }
}
