
using System.Text.Json;
using SQLiteToJsonApp.Entities;
using SQLiteToJsonApp.TransactionServices;

namespace SQLiteToJsonApp.Querys;

public class TransactionProcessor
{
    public void ProcessTransactions()
    {
        string jsonConfig;

        try
        {
            jsonConfig = File.ReadAllText("config.json");
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("Error: No se pudo encontrar el archivo 'config.json'. Asegúrate de que esté en la carpeta correcta.");
            return;
        }

        var config = JsonSerializer.Deserialize<Config>(jsonConfig);

        if (config == null || string.IsNullOrEmpty(config.RutaDb))
        {
            Console.WriteLine("Error: La configuración no es válida o falta la propiedad 'RutaDb' en el archivo config.json.");
            return;
        }

        string connectionString = $"Data Source={config.RutaDb}";

        int idApi;

        while (true)
        {
            while (true)
            {
                Console.Write("Ingrese el IdApi (número de 5 dígitos): ");
                string input = Console.ReadLine() ?? string.Empty;


             
                if (!string.IsNullOrEmpty(input) && input.Length == 5 && int.TryParse(input, out idApi))
                {
                    break;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Por favor, ingrese un número válido de 5 dígitos.");
                }
            }

            string query = "SELECT * FROM \"Transaction\" WHERE IdApi = @idApi";

            TransactionService transactionService = new();
            List<Transaction> transactions = transactionService.GetTransactions(connectionString, query, idApi);

            if (transactions.Count > 0)
            {
                var transaccionesEnEspanol = transactions.Select(t => new
                {
                    IdTransaccion = t.TransactionId,
                    t.IdApi,
                    Documento = t.Document,
                    Referencia = t.Reference,
                    Producto = t.Product,
                    MontoTotal = t.TotalAmount,
                    MontoReal = t.RealAmount,
                    MontoIngreso = t.IncomeAmount,
                    MontoDevuelto = t.ReturnAmount,
                    Descripcion = t.Description,
                    IdEstadoTransaccion = t.IdStateTransaction,
                    EstadoTransaccion = t.StateTransaction,
                    FechaCreacion = t.DateCreated,
                    FechaActualizacion = t.DateUpdated
                });

                string json = JsonSerializer.Serialize(transaccionesEnEspanol, new JsonSerializerOptions { WriteIndented = true });
                Console.WriteLine(json);
                break;
            }
            else
            {
                Console.Clear();
                Console.WriteLine($"No se encontraron transacciones para IdApi: {idApi}. Intente nuevamente.\n");
            }
        }
    }
}
