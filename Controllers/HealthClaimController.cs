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
        private readonly IMembersRepository _IMembersRepository;
        private readonly IClaimsRepository _IClaimsRepository;
        public HealthClaimController(IMembersRepository membersRepository, IClaimsRepository claimsRepository)
        {
            this._IMembersRepository = membersRepository;
            this._IClaimsRepository = claimsRepository;
        }

        [HttpGet]
        [Route("[action]")]
        [Route("api/HealthClaim/GetClaims")]
        public IActionResult GetClaims()
        {
            try
            {
                var item = from Claims in _IClaimsRepository.BindClims()
                           join Memebers in _IMembersRepository.BindMembers()
                           on Claims.MemberID equals Memebers.MemberID
                           select new { Claims.MemberID, Memebers.FirstName, Memebers.LastName, Claims.ClaimDate, Claims.claimammount };
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

        [HttpPost]
        [Route("/GetByClaimDate/{ClaimDate}")]
        public IActionResult GetByClaimDate(string ClaimDate)
        {
            try
            {
                var item = from Claims in _IClaimsRepository.BindClims()
                           join Memebers in _IMembersRepository.BindMembers()
                           on Claims.MemberID equals Memebers.MemberID
                           where Claims.ClaimDate == Convert.ToDateTime(ClaimDate)
                           select new { Claims.MemberID, Memebers.FirstName, Memebers.LastName, Claims.ClaimDate, Claims.claimammount  };
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