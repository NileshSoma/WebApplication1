using LumenWorks.Framework.IO.Csv;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{

    public class ClaimsRepository  : IClaimsRepository
    {

        public int MemberID { get; set; }
        public DateTime? ClaimDate { get; set; }
        public decimal? claimammount { get; set; }

        public List<ClaimsRepository> BindClims()
        {
            var csvClaimsTable = new DataTable();
            List<ClaimsRepository> objClaims = new List<ClaimsRepository>();
            using (var csvclaimesReader = new CsvReader(new StreamReader(System.IO.File.OpenRead(@"D:\1\New folder (2)\WebApplication1\Services\Claim.csv")), true))
            {
                csvClaimsTable.Load(csvclaimesReader);
            }
            for (int i = 0; i < csvClaimsTable.Rows.Count; i++)
            {
                objClaims.Add(new ClaimsRepository { MemberID = Convert.ToInt32(csvClaimsTable.Rows[i][0]), ClaimDate = Convert.ToDateTime(csvClaimsTable.Rows[i][1].ToString()), claimammount = Convert.ToDecimal(csvClaimsTable.Rows[i][2]) });
            }
            
            return objClaims;
        }
    }

}
