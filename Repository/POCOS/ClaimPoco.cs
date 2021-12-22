using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class ClaimPoco
    {
        public int ClaimID { get; set; }
        public string ClaimType { get; set; } //car, home, theft
        public string Description { get; set; }
        public double ClaimAmount { get; set; }
        public DateTime DateOfIncident { get; set; }
        public DateTime DateOfClaim { get; set; }
        public bool IsValid { get; set; }
        public ClaimPoco(int id, string type, string des, double price, DateTime incident, DateTime claim)
        {
            ClaimID = id;
            ClaimType = type;
            Description = des;
            ClaimAmount = price;
            DateOfIncident = incident;
            DateOfClaim = claim;
            IsValid = Validity();
        }
        public bool Validity ()
        {
            TimeSpan age = DateOfClaim - DateOfIncident;
            double days = age.TotalDays;
            if (days > 30)
            {
                IsValid = false;
            } else
            {
                IsValid = true;
            }
            return IsValid;
        }
    }
}
