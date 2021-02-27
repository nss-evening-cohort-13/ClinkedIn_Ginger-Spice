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
                return NotFound("This user id does not exist");
            }

            return Ok(user);
        }

        [HttpGet("{id}/Services")]
        public IActionResult GetListOfServiceById(int id)
        {
            var user = _repo.GetUser(id);

            if (user.Services == null)
            {
                return NotFound("This user's service list is empty");
            }

            return Ok(user.Services);
        }

        [HttpPut("{id}/add-friend/{friendId}")]
        public IActionResult AddFriend(int id, int friendId)
        {
            _repo.AddFriend(id, friendId);
            return Created($"api/Users/{id}/add-friend/{friendId}", $"Friend added");
        }



        [HttpGet("{id}/Services/Request/{service}")]
        public IActionResult GetListOfServiceAndRequest(int id, string service)
        {
            var user = _repo.GetUser(id);

            if(!Enum.TryParse<Services>( service, false, out var myServices))
            {
                return BadRequest("This user doesn't have that service available");
            }

            var checkIfServiceIsAvailable = from userService in user.Services
                                            where userService == myServices
                                            select userService;

            if (checkIfServiceIsAvailable == null)
            {
                return NotFound("This page is not found");
            }

            return Ok(checkIfServiceIsAvailable);
            
            
        }

        [HttpGet("interest/{interest}")]
        public IActionResult GetByInterest(string interest)
        {
            var users = _repo.GetAll();

            if (!Enum.TryParse<Interests>(interest, true, out var myInterest))
            {
                return BadRequest("This interest does not exist");
            }

            //Interests myInterest = (Interests) Enum.Parse(typeof(Interests), interest, true);

            var userWithInterest = from u in users
                                   where u.Interests.Contains(myInterest)
                                   select u;

            return Ok(userWithInterest);

        }
    }
}
