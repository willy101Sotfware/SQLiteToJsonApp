# SQLiteToJsonApp

## Descripción
**SQLiteToJsonApp** es una aplicación de consola desarrollada en C# que permite leer datos desde una base de datos SQLite y convertir esos datos en un archivo JSON. La aplicación se utiliza principalmente para procesar transacciones almacenadas en una base de datos SQLite, extraer información relevante y convertirla a un formato JSON legible.

## Características
- Conexión con una base de datos SQLite.
- Consulta de transacciones en la base de datos usando un `IdApi` proporcionado por el usuario.
- Conversión de los datos de las transacciones a formato JSON.
- Manejo de archivos de configuración (`config.json`).
- Validación de entrada del usuario (solo se aceptan IDs de 5 dígitos).

## Requisitos
- .NET 8.0
- SQLite
- Archivos de configuración en formato JSON

## Configuración
1. **Base de datos SQLite**: Asegúrate de tener una base de datos SQLite configurada y accesible desde el proyecto. La base de datos debe tener una tabla llamada `Transaction` con las columnas necesarias como `TransactionId`, `IdApi`, `Document`, `Reference`, `Product`, etc.
   
2. **Archivo `config.json`**: La aplicación requiere un archivo `config.json` en el directorio raíz del proyecto. Este archivo debe contener la propiedad `RutaDb` con la ruta a la base de datos SQLite. Aquí tienes un ejemplo del contenido del archivo `config.json`:

```json
{
  "RutaDb": "C:\\ruta\\a\\tu\\base\\de\\datos\\transacciones.db"
}
