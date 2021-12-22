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
        public List<ClaimPoco> GetList()
        {
            return _claims;
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
