namespace ManageInvestors.Models
{
    public class Fund
    {
        public int Id { get; set; }
        public string FundName { get; set; }
        public string ProviderName { get; set; }
        public int Rating { get; set; }
        public string ISIN { get; set; }
        public string FundDescription { get; set; }
        public decimal? LastPrice { get; set; }
        public bool IsDeleted { get; set; } = false;

        public virtual ICollection<Investment> Investments { get; set; }
            = new List<Investment>();
    }
}
