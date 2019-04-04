using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace NetCoreWebApp2._2.Controllers
{
    /// <summary>
    /// User class
    /// </summary>
    public class User
    {
        /// <summary>
        /// User Name
        /// </summary>
        [Required]
        [MaxLength(200)]
        public string Name { get; set; }
        /// <summary>
        /// User DOB
        /// </summary>
        [Required]
        public DateTime Dob { get; set; }
    }

    /// <summary>
    /// User Controller
    /// </summary>
    [Produces("application/json","application/xml")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        /// <summary>
        /// Get the list of user
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<User> Get()
        {
            return new List<User>
            {
                new User{ Name="User 1"},
                new User{ Name="User 2"},
                new User{ Name="User 3"}
            };

        }

        /// <summary>
        /// Get use by ID
        /// </summary>
        /// <param name="id">USer id to be fetched</param>
        /// <returns>User object</returns>
        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<User> GetUser(int id)
        {
            if (id != 3)
            {
                return NotFound();
            }
            return Ok(new User { Name = "User 3" });

        }

        /// <summary>
        /// fh
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [Consumes("application/json")]
        [HttpPost]
        public ActionResult<User> Post(User user)
        {
            return Ok(user);

        }
    }
}