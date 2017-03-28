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
    [Route("api/quotes")]
    public class QuotesController : Controller
    {
        private readonly FisherContext db;

        public QuotesController(FisherContext context)
        {
            db = context;
        }


        // GET: api/quotes
        [HttpGet]
        public IActionResult GetQuotes()
        {
            return Ok(db.Quotes);
        }

        // GET api/quotes/5
        [HttpGet("{id}", Name = "GetQuote")]
        public IActionResult Get(int id)
        {
            return Ok(db.Quotes.Find(id));
        }

        // POST api/quotes
        [HttpPost]
        public IActionResult Post([FromBody]Quote quote)
        {
            var newQuote = db.Quotes.Add(quote);
            db.SaveChanges();

            return CreatedAtRoute("GetQuote", new { id = quote.Id }, quote);
        }

        // PUT api/quotes/id
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Quote quote)
        {
            db.Entry(quote).State = EntityState.Modified;  //required for entity framework. Let's it know record is being modified.
            var newQuote = db.Quotes.Find(id);
            if (newQuote == null)
            {
                return NotFound();
            }

            //if error in quote update, catch & report it. 
            try
            {
                newQuote = quote;
                db.SaveChanges();
                return Ok(newQuote);
            }
            catch (Exception e)
            {
                //Console.WriteLine("An error occurred: '{0}'", e);
                var errorMessage = ("Insert claim error, System response: " + e);
                return BadRequest(errorMessage);
            }
            
        }

        // DELETE api/quotes/id
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var quoteToDelete = db.Quotes.Find(id);
            if (quoteToDelete == null)
            {
                return NotFound();
            }
            db.Quotes.Remove(quoteToDelete);
            db.SaveChangesAsync();

            return NoContent();
        }
    }
}
