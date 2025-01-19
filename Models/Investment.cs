namespace ManageInvestors.Models
{
    public class Investment
    {
        public int Id { get; set; }
        public int InvestorId { get; set; }
        public int FundId { get; set; }
        public decimal Quantity { get; set; }
        public DateTime? PurchasedDate { get; set; }
        public string UserTransaction { get; set; }
        public DateTime? TransactionDateTime { get; set; }        
        public bool IsDeleted { get; set; } = false;

        public virtual Investor Investor { get; set; }
        public virtual Fund Fund { get; set; }
    }
}
