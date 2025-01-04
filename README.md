# 📋 **Proyecto de Gestión de Contactos con C#, SQLite y ADO.NET (Async)**
---
## 🌟 Descripción del Proyecto
Este proyecto es una aplicación de escritorio sencilla creada con Windows Forms en C#. Permite gestionar una lista de contactos almacenados en una base de datos SQLite. La base de datos se aloja en la carpeta AppData del usuario para garantizar que se mantenga aislada de los archivos del proyecto.

## 🛠️ Tecnologías Utilizadas
 - C# y Windows Forms: Para la interfaz gráfica de usuario (GUI).
 - SQLite: Como base de datos ligera y local.
 - ADO.NET (Async): Para la comunicación con la base de datos utilizando operaciones asíncronas.
 - Regex: Para la validación de datos (por ejemplo, números de teléfono).
   
## 🚀 Funcionalidades
- 📇 **Gestión de Contactos**:
  Agregar, eliminar, listar y visualizar contactos con nombre, correo electrónico y teléfono.
- 🌐 **Operaciones Asíncronas**:
  Las interacciones con la base de datos son asíncronas para evitar bloquear la interfaz de usuario.
- 📂 **Base de Datos en AppData**:
  El archivo de base de datos se guarda automáticamente en:<br>
  ``C:\Users\<Usuario>\AppData\Local\<NombreDelProyecto>``.
- 📂 **Estructura del Proyecto**:
  1. Form1.cs: Controla la lógica de la interfaz de usuario.
  2. ContactService.cs: Maneja las interacciones con la base de datos.
  3. Contact.cs: Representa el modelo de datos para un contacto.
  4. Database: Carpeta utilizada inicialmente para la base de datos (ya no en uso, se reemplazó por AppData).

## 📥 Requisitos
 - **Instalar .NET Framework 4.5 o superior.**  (for async/await support)
 - **Añadir el paquete NuGet**: System.Data.SQLite.

## 🚧 Buenas Prácticas Implementadas
- Uso de async/await para mejorar la experiencia del usuario.
- Separación de responsabilidades con un diseño modular.
- Validación de datos para garantizar entradas correctas.

## 👨‍💻 Instalación y Ejecución
1. 🛠️ Clonar el Repositorio: Clona el proyecto en tu entorno local.
2. 📦 Instalar Dependencias:
Asegúrate de instalar System.Data.SQLite desde NuGet.
3. 🏃‍♂️ Ejecutar la Aplicación:
Abre el proyecto en Visual Studio, compílalo y ejecuta la aplicación.

## 📬 Contacto
¿Tienes preguntas o sugerencias? No dudes en contactarme. 😊
