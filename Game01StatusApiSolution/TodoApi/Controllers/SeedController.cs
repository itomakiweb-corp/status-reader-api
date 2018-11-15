using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TodoApi.Models;

namespace TodoApi.Controllers
{
    [Route("api/seed")]
    [ApiController]
    public class SeedController : ControllerBase
    {
        private readonly SeedContext _context;
        public SeedController(SeedContext context)
        {
            _context = context;
        }

        [Route("all")]
        [HttpGet]
        public ActionResult<List<Seed>> GetAll()
        {
            var l = _context.Seeds.ToList();
            return l;
        }

        [HttpGet]
        public ActionResult<List<Seed>> GetByUserId([FromQuery]string userId)
        {
            try
            {
                var result = _context.Seeds.Where(
                    data => data.UploadUserId == userId);
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
        public ActionResult<Seed> Create(Seed item)
        {
            try
            {
                var current = DateTimeOffset.Now.ToString();
                var data = new Seed {
                    SeedType = item.SeedType,
                    SeedTitle = item.SeedTitle,
                    SeedUrl = item.SeedUrl,
                    KeySteries = item.KeySteries,
                    InputStartTime = item.InputStartTime,
                    InputEndTime = item.InputEndTime,
                    CreatedTime = current,
                    UpdatedTime = current,
                    UploadUserId = item.UploadUserId,
                    UploadUserName = item.UploadUserName
                };
                var result =_context.Seeds.Add(data);
                _context.SaveChanges();
                return Ok(result.Entity);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }
    }
}