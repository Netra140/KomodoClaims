using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class ClaimRepo
    {
        public List<ClaimPoco> _claims = new List<ClaimPoco>();
        public string GetList()
        {
            string list = "";
            for (int i = 0; i < _claims.Count; i++) {
                list += _claims[i].ClaimID;
                list += " " + _claims[i].ClaimType + " " + _claims[i].Description + " $" + _claims[i].ClaimAmount + " " + _claims[i].DateOfIncident + " " + _claims[i].DateOfClaim + " " + _claims[i].IsValid;
                list += "\n";
            }
            return list;
        }
        public void AddClaim (ClaimPoco claim)
        {
            _claims.Add(claim);
            return;
        }
        public void RemoveClaim()
        {
                _claims.RemoveAt(0);
        }
        public ClaimPoco GetNextPoco ()
        {
            return _claims[0];
        }
    }
}
