using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TodoApi.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TodoApi.Controllers
{
    [Route("api/userfeelings")]
    [ApiController]
    public class UserFeelingsController : Controller
    {
        private readonly UserFeelingContext _context;
        public UserFeelingsController(UserFeelingContext context)
        {
            _context = context;

            //if (_context.UserFeelings.Count() == 0)
            //{
            //    _context.UserFeelings.Add(new UserFeeling { Name = "item1" });
            //    _context.SaveChanges();
            //}
        }

        // GET: api/<controller>
        [HttpGet]
        public ActionResult<List<UserFeeling>> GetAll()
        {
            var l = _context.UserFeelings.ToList();
            return l;
        }

        // GET api/<controller>/5
        [HttpGet("{id}", Name = "GetFeelings")]
        public ActionResult<UserFeeling> GetById(long id)
        {
            var item = _context.UserFeelings.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return item;
        }

        // POST api/<controller>
        [HttpPost]
        public ActionResult Create(UserFeeling item)
        {
            try
            {
                if (item.Id <= 0)
                {
                    if (_context.UserFeelings.Count() == 0)
                    {
                        item.Id = 1;
                    }
                    else
                    {
                        var last = _context.UserFeelings.Last();
                        if (last != null)
                        {
                            item.Id = last.Id + 1;
                        }
                    }
                }
                _context.UserFeelings.Add(item);
                _context.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
                //return inter
            }
            //return CreatedAtRoute("GetFeellings", new { id = item.Id }, item);
        }

        //// PUT api/<controller>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var item = _context.UserFeelings.Find(id);
            if (item == null)
            {
                return NotFound();
            }

            _context.UserFeelings.Remove(item);
            _context.SaveChanges();
            return Ok();
        }
    }
}
