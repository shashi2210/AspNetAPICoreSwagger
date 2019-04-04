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
    /// User Controller
    /// </summary>
    [Produces("application/json", "application/xml")]
    [Route("api/{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("2.0")]
    public class UserControllerV2 : ControllerBase
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
        /// Get use by ID
        /// </summary>
        /// <param name="id">USer id to be fetched</param>
        /// <returns>User object</returns>
        [HttpDelete]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<User> DelUser(int id)
        {
            if (id != 3)
            {
                return NotFound();
            }
            return NoContent();

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