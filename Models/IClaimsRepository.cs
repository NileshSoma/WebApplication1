using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public  interface IClaimsRepository
    {
        public int MemberID { get; set; }
        public DateTime? ClaimDate { get; set; }
        public decimal? claimammount { get; set; }

        public List<ClaimsRepository> BindClims();
    }
}
