namespace Models.DTOs;

public class InvestmentDTO
{
    public int Id { get; set; }
    public int InvestorId { get; set; }
    public int FundId { get; set; }
    public decimal Quantity { get; set; }
    public DateTime? PurchasedDate { get; set; }
    public string UserTransaction { get; set; }
    public DateTime? TransactionDateTime { get; set; }
    public bool IsDeleted { get; set; } = false;

    public FundDTO Fund { get; set; }
}
