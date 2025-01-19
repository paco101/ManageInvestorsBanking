namespace Models.DTOs;

public class FundDTO
{
    public int Id { get; set; }
    public string FundName { get; set; }
    public string ProviderName { get; set; }
    public int Rating { get; set; }
    public string ISIN { get; set; }
    public string FundDescription { get; set; }
    public decimal LastPrice { get; set; }
    public bool IsDeleted { get; set; } = false;
}
