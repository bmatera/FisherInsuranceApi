using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FisherInsuranceApi.Data;
using FisherInsuranceApi.Models;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace FisherInsuranceApi.Controllers
{
    //[Route("api/[controller]")]
    [Route("api/claims")]
    public class ClaimsController : Controller
    {
        private IMemoryStore db;
        public ClaimsController(IMemoryStore repo)
        {
            db = repo;
        }

        // GET: api/claims
        [HttpGet]
        public IActionResult GetClaims()
        {
            return Ok(db.RetrieveAllClaims);
        }

        // GET api/claims/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(db.RetrieveClaim(id));
        }

        // POST api/claims
        [HttpPost]
        public IActionResult Post([FromBody]Claim claim)
        {
            return Ok(db.CreateClaim(claim));
        }

        // PUT api/claims/id
        [HttpPut("{id}")]
        public IActionResult Put([FromBody] Claim claim)
        {
            return Ok(db.UpdateClaim(claim));
        }

        // DELETE api/claims/id
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            db.DeleteClaim(id);
            return Ok();
        }
    }
}
