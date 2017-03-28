using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FisherInsuranceApi.Data;
using FisherInsuranceApi.Models;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace FisherInsuranceApi.Controllers
{
    //[Route("api/[controller]")]
    [Route("api/claims")]
    public class ClaimsController : Controller
    {

        //private IMemoryStore db;
        //public ClaimsController(IMemoryStore repo)
        //{
        //    db = repo;
        //}
        private readonly FisherContext db;
        public ClaimsController(FisherContext context)
        {
            db = context;
        }


        // GET: api/claims
        [HttpGet]
        public IActionResult GetClaims()
        {
            return Ok(db.Claims);
        }

        // GET api/claims/5
        [HttpGet("{id}", Name ="GetClaim")]
        public IActionResult Get(int id)
        {
            return Ok(db.Claims.Find(id));
        }

        // POST api/claims
        [HttpPost]
        public IActionResult Post([FromBody]Claim claim)
        {
            var newClaim = db.Claims.Add(claim);
            db.SaveChanges();

            return CreatedAtRoute("GetClaim", new { id = claim.Id}, claim);
        }

        // PUT api/claims/id
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Claim claim)
        {
            db.Entry(claim).State = EntityState.Modified;  //required for entity framework. Let's it know record is being modified.
            var newClaim = db.Claims.Find(id);
            if (newClaim == null)
            {
                return NotFound();
            }

            //if error in claim update, catch & report it. 
            try
            {
                newClaim = claim;
                db.SaveChanges();
                return Ok(newClaim);
            }
            catch (Exception e)
            {
                //Console.WriteLine("An error occurred: '{0}'", e);
                var errorMessage = ("Insert claim error, System response: " + e);
                return BadRequest(errorMessage);
            }
        }

        // DELETE api/claims/id
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var claimToDelete = db.Claims.Find(id);
            if (claimToDelete == null)
            {
                return NotFound();
            }
            db.Claims.Remove(claimToDelete);
            db.SaveChangesAsync();

            return NoContent();
        }
    }
}
