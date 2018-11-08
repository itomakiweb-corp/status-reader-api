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
        }

        [Route("all")]
        [HttpGet]
        public ActionResult<List<UserFeeling>> GetAll()
        {
            var l = _context.UserFeelings.ToList();
            return l;
        }

        [HttpGet]
        public ActionResult<UserFeeling> GetByUserId([FromQuery]string userId)
        {
            try
            {
                var result = _context.UserFeelings.FirstOrDefault(data => data.UserId == userId);
                if (result == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(result);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        [HttpPost]
        public ActionResult<UserScore> Create(UserFeeling item)
        {
            try
            {
                var data = new UserFeeling
                {
                    UserId = item.UserId,
                    UserName = item.UserName,
                    Comment1 = item.Comment1,
                    Comment2 = item.Comment2,
                    Comment3 = item.Comment3,
                    IssuedTime = item.IssuedTime,
                    elapsedMilliSec = item.elapsedMilliSec
                };
                _context.UserFeelings.Add(data);
                _context.SaveChanges();

                var score = new UserScore();
                score.UserId = item.UserId;
                score.UserName = item.UserName;
                score.IssuedTime = item.IssuedTime;
                score.CurrentScore = 1000;
                score.TotalScore = 10000;
                score.Rank = 1;
                return Ok(score);
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
