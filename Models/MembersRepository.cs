using LumenWorks.Framework.IO.Csv;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class MembersRepository : IMembersRepository
    {
        public int MemberID { get; set; }
        public DateTime? EnrollmentDate { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public List<MembersRepository> BindMembers()
        {
            List<MembersRepository> objEnrolementes = new List<MembersRepository>();
            var csvEnroleTable = new DataTable();

            using (var csvEnroleReader = new CsvReader(new StreamReader(System.IO.File.OpenRead(@"D:\1\New folder (2)\WebApplication1\Services\Member.csv")), true))
            {
                csvEnroleTable.Load(csvEnroleReader);
            }

            for (int i = 0; i < csvEnroleTable.Rows.Count; i++)
            {
                objEnrolementes.Add(new MembersRepository { MemberID = Convert.ToInt32(csvEnroleTable.Rows[i][0]), EnrollmentDate = DateTime.Parse(csvEnroleTable.Rows[i][1].ToString()), LastName = csvEnroleTable.Rows[i][3].ToString(), FirstName = csvEnroleTable.Rows[i][2].ToString() });
            }
            return objEnrolementes;
        }
    }
}
