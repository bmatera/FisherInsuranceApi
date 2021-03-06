﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace FisherInsuranceApi.Controllers
{
    //[Route("api/[controller]")]
    [Route("api/claims")]
    public class ClaimsController : Controller
    {
        // GET: api/claims
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/claims/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok("The id is: " + id);
        }

        // POST api/claims
        [HttpPost]
        public IActionResult Post([FromBody]string value)
        {
            return Created("", value);
        }

        // PUT api/claims/id
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]string value)
        {
            return NoContent();
        }

        // DELETE api/claims/id
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Delete(id);
        }
    }
}
