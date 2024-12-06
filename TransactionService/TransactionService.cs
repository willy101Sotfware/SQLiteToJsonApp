using Microsoft.Data.Sqlite;
using SQLiteToJsonApp.Entities;

namespace SQLiteToJsonApp.TransactionServices;

public class TransactionService
{
  public List<Transaction> GetTransactions(string connectionString, string query, int idApi)
  {
    var transactions = new List<Transaction>();

    using (var connection = new SqliteConnection(connectionString))
    {
      connection.Open();

      using (var command = new SqliteCommand(query, connection))
      {
        command.Parameters.AddWithValue("@idApi", idApi);

        using (var reader = command.ExecuteReader())
        {
          while (reader.Read())
          {
            var transaction = new Transaction
            {
              TransactionId = reader.GetInt32(0),
              IdApi = reader.GetInt32(1),
              Document = reader.IsDBNull(2) ? null : reader.GetString(2),
              Reference = reader.IsDBNull(3) ? null : reader.GetString(3),
              Product = reader.IsDBNull(4) ? null : reader.GetString(4),
              TotalAmount = reader.GetDouble(5),
              RealAmount = reader.GetDouble(6),
              IncomeAmount = reader.GetDouble(7),
              ReturnAmount = reader.GetDouble(8),
              Description = reader.IsDBNull(9) ? null : reader.GetString(9),
              IdStateTransaction = reader.GetInt32(10),
              StateTransaction = reader.IsDBNull(11) ? null : reader.GetString(11),
              DateCreated = reader.IsDBNull(12) ? null : reader.GetString(12),
              DateUpdated = reader.IsDBNull(13) ? null : reader.GetString(13)
            };

            transactions.Add(transaction);
          }
        }
      }
    }

    return transactions;
  }
}

