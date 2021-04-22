using LumenWorks.Framework.IO.Csv;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{

    public class Claims
    {

        public int MemberID { get; set; }
        public DateTime? ClaimDate { get; set; }
        public decimal? claimammount { get; set; }

        public List<Claims> BindClims()
        {
            var csvClaimsTable = new DataTable();
            List<Claims> objClaims = new List<Claims>();
            using (var csvclaimesReader = new CsvReader(new StreamReader(System.IO.File.OpenRead(@"D:\1\New folder (2)\WebApplication1\Services\Claim.csv")), true))
            {
                csvClaimsTable.Load(csvclaimesReader);
            }
            for (int i = 0; i < csvClaimsTable.Rows.Count; i++)
            {
                objClaims.Add(new Claims { MemberID = Convert.ToInt32(csvClaimsTable.Rows[i][0]), ClaimDate = Convert.ToDateTime(csvClaimsTable.Rows[i][1].ToString()), claimammount = Convert.ToDecimal(csvClaimsTable.Rows[i][2]) });
            }
            
            return objClaims;
        }
    }

    public class Members
    {
        public int MemberID { get; set; }
        public DateTime? EnrollmentDate { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public List<Members> BindMembers()
        {
            List<Members> objEnrolementes = new List<Members>();
            var csvEnroleTable = new DataTable();
            
            using (var csvEnroleReader = new CsvReader(new StreamReader(System.IO.File.OpenRead(@"D:\1\New folder (2)\WebApplication1\Services\Member.csv")), true))
            {
                csvEnroleTable.Load(csvEnroleReader);
            }
            
            for (int i = 0; i < csvEnroleTable.Rows.Count; i++)
            {
                objEnrolementes.Add(new Members { MemberID = Convert.ToInt32(csvEnroleTable.Rows[i][0]), EnrollmentDate = DateTime.Parse(csvEnroleTable.Rows[i][1].ToString()) , LastName = csvEnroleTable.Rows[i][3].ToString(), FirstName = csvEnroleTable.Rows[i][2].ToString() });
            }
            return objEnrolementes;
        }
    }

    


}
