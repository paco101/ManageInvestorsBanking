using ManageInvestors.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTOs;

public class InvestorDTO
{
    public int Id { get; set; }
    public string Firstname { get; set; }
    public string Lastname { get; set; }        
    public string Fullname { get { return $"{this.Firstname} {this.Lastname}"; } }
    public string Phone { get; set; }
    public string Email { get; set; }
    public string Address { get; set; }
    public string Country { get; set; }
    public bool IsDeleted { get; set; } = false;
    public ICollection<InvestmentDTO> Investments { get; set; }
        = new List<InvestmentDTO>();
}
