# SQLiteToJsonApp

## Descripci�n
**SQLiteToJsonApp** es una aplicaci�n de consola desarrollada en C# que permite leer datos desde una base de datos SQLite y convertir esos datos en un archivo JSON. La aplicaci�n se utiliza principalmente para procesar transacciones almacenadas en una base de datos SQLite, extraer informaci�n relevante y convertirla a un formato JSON legible.

## Caracter�sticas
- Conexi�n con una base de datos SQLite.
- Consulta de transacciones en la base de datos usando un `IdApi` proporcionado por el usuario.
- Conversi�n de los datos de las transacciones a formato JSON.
- Manejo de archivos de configuraci�n (`config.json`).
- Validaci�n de entrada del usuario (solo se aceptan IDs de 5 d�gitos).

## Requisitos
- .NET 8.0
- SQLite
- Archivos de configuraci�n en formato JSON

## Configuraci�n
1. **Base de datos SQLite**: Aseg�rate de tener una base de datos SQLite configurada y accesible desde el proyecto. La base de datos debe tener una tabla llamada `Transaction` con las columnas necesarias como `TransactionId`, `IdApi`, `Document`, `Reference`, `Product`, etc.
   
2. **Archivo `config.json`**: La aplicaci�n requiere un archivo `config.json` en el directorio ra�z del proyecto. Este archivo debe contener la propiedad `RutaDb` con la ruta a la base de datos SQLite. Aqu� tienes un ejemplo del contenido del archivo `config.json`:

```json
{
  "RutaDb": "C:\\ruta\\a\\tu\\base\\de\\datos\\transacciones.db"
}
