using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using LumenWorks.Framework.IO.Csv;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HealthClaimController : ControllerBase
    {

        [HttpGet]
        [Route("[action]")]
        [Route("api/HealthClaim/GetClaims")]
        public IActionResult GetClaims()
        {

            Claims obj = new Claims();
            Members objmembers = new Members();
            try
            {
                var item = from Claims in obj.BindClims()
                           join Memebers in objmembers.BindMembers()
                           on Claims.MemberID equals Memebers.MemberID
                           select new { Claims.MemberID, Claims.ClaimDate, Claims.claimammount, Memebers.FirstName, Memebers.LastName };
                if (item != null)
                {
                    return Ok(item);
                }
                else if (item == null)
                {
                    return NotFound(item);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
            return NotFound("Not found");
        }

        [HttpGet]        
        [Route("/GetByClaimDate/{ClaimDate}")]
        public IActionResult GetByClaimDate(string ClaimDate)
        {

            Claims obj = new Claims();
            Members objmembers = new Members();
            try
            {
                var item = from Claims in obj.BindClims()
                           join Memebers in objmembers.BindMembers()
                           on Claims.MemberID equals Memebers.MemberID
                           where Claims.ClaimDate == Convert.ToDateTime(ClaimDate)
                           select new { Claims.MemberID, Claims.ClaimDate, Claims.claimammount, Memebers.FirstName, Memebers.LastName };
                if (item != null)
                {
                    return Ok(item);
                }
                else if (item == null)
                {
                    return NotFound(item);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
            return NotFound("Not found");
        }
    }
}