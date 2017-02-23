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
    [Route("api/quotes")]
    public class QuoteController : Controller
    {
        private IMemoryStore db;
        public QuoteController(IMemoryStore repo)
        {
            db = repo;
        }

        //Lab 4, exercise 1
        // GET: api/quotes
        [HttpGet]
        public IActionResult GetQuotes()
        {
            return Ok(db.RetrieveAllQuotes);
        }

        // GET api/auto/quotes/5  (get single quote by id)
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            //return Ok("The id is: " + id);
            return Ok(db.RetrieveQuote(id));
        }

        // POST api/auto/quotes
        [HttpPost]
        public IActionResult Post([FromBody] Quote quote)
        {
            //return Created("", value);
            return Ok(db.CreateQuote(quote));
        }

        // PUT api/auto/quotes/id
        [HttpPut("{id}")]
        //public IActionResult Put(int id, [FromBody]string value)
        public IActionResult Put([FromBody] Quote quote)
        {
            //return NoContent();
            return Ok(db.UpdateQuote(quote));
        }

        // DELETE api/auto/quotes/id
        [HttpDelete("{id}")]
        //public IActionResult Delete(int id)
        public IActionResult Delete(int id)
        {
            //return Delete(id);
            db.DeleteQuote(id);
            return Ok();
        }
    }
}
