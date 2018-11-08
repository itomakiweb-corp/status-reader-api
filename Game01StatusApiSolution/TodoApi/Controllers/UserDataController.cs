using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TodoApi.Models;

namespace TodoApi.Controllers
{
    [Route("api/userdata")]
    [ApiController]
    public class UserDataController : ControllerBase
    {
        private readonly UserDataContext _context;
        public UserDataController(UserDataContext context)
        {
            _context = context;
        }

        [Route("all")]
        [HttpGet]
        public ActionResult<List<UserData>> GetAll()
        {
            var l = _context.UserDatas.ToList();
            return l;
        }

        [HttpGet]
        public ActionResult<UserData> GetByUserId([FromQuery]string authType, [FromQuery]string userId)
        {
            try
            {
                var result = _context.UserDatas.FirstOrDefault(
                    data => data.UserId == userId && data.AuthType == authType);
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
        public ActionResult<UserData> Create(UserData item)
        {
            try
            {
                var data = new UserData { AuthType = item.AuthType, UserId = item.UserId, UserName = item.UserName};
                var result =_context.UserDatas.Add(data);
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