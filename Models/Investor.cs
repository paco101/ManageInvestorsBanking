using System.ComponentModel.DataAnnotations.Schema;

namespace ManageInvestors.Models
{
    public class Investor
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Country { get; set; }
        public bool IsDeleted { get; set; } = false;
        public virtual ICollection<Investment> Investments { get; set; }
            = new List<Investment>();
    }
}
