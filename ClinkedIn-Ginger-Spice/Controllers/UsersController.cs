using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClinkedIn_Ginger_Spice.DataAccess;
using ClinkedIn_Ginger_Spice.Models;

namespace ClinkedIn_Ginger_Spice.Controllers
{
    
    [Route("api/Users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        UserRepository _repo;

        public UsersController()
        {
            _repo = new UserRepository();
        }

        [HttpGet]
        public IActionResult GetAllUsers()
        {
            return Ok(_repo.GetAll());
        }


        [HttpPost]
        public IActionResult AddAUser(User user)
        {
            _repo.Add(user);
            return Created($"api/Users/{user.Id}", user);

        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var user = _repo.GetUser(id);

            if (user == null)
            {
                return NotFound("This loaf id does not exist");
            }

            return Ok(user);
        }

        [HttpGet("interest/{interest}")]
        public IActionResult GetByInterest(string interest)
        {
            var users = _repo.GetAll();

            Interests myInterest = (Interests) Enum.Parse(typeof(Interests), interest, true);

            var userWithInterest = from u in users
                                   where u.Interests.Contains(myInterest)
                                   select u;

            return Ok(userWithInterest);

        }
    }
}
