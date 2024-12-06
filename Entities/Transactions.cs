namespace SQLiteToJsonApp.Entities;

public class Transaction
{
  public int TransactionId { get; set; }
  public int IdApi { get; set; }
  public string? Document { get; set; }
  public string? Reference { get; set; }
  public string? Product { get; set; }
  public double TotalAmount { get; set; }
  public double RealAmount { get; set; }
  public double IncomeAmount { get; set; }
  public double ReturnAmount { get; set; }
  public string? Description { get; set; }
  public int IdStateTransaction { get; set; }
  public string? StateTransaction { get; set; }
  public string? DateCreated { get; set; }
  public string? DateUpdated { get; set; }
}

