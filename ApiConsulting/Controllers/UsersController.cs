using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiConsulting.Controllers
{
    /// <summary>
    /// API for Users table
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly MyDbContext _context;

        /// <summary>
        /// Basic constructor
        /// </summary>
        /// <param name="context"></param>
        public UsersController(MyDbContext context)
        {
            _context = context;
        }

        // GET: api/Users
        /// <summary>
        /// Return all the values from Users table
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }

        // GET: api/Users/5
        /// <summary>
        /// Get user by id
        /// </summary>
        /// <param name="id">User Id</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        // GET: api/Users/find
        /// <summary>
        /// Query Users by given search fields. At least one parameter should be provided.
        /// </summary>
        /// <param name="id">SQL user Id</param>
        /// <param name="erpId">ERP user Id</param>
        /// <param name="firstName">User's first name</param>
        /// <param name="lastName">User's last name</param>
        /// <param name="username">User's username</param>
        /// <returns></returns>
        [HttpGet("find")]
        public async Task<ActionResult<IEnumerable<User>>> FindUsers(
            [FromQuery] int? id = null,
            [FromQuery] string? erpId = null,
            [FromQuery] string? firstName = null,
            [FromQuery] string? lastName = null,
            [FromQuery] string? username = null)
        {
            var query = _context.Users.AsQueryable();

            if (id.HasValue)
            {
                query = query.Where(u => u.Id == id.Value);
            }
            if (!string.IsNullOrEmpty(erpId))
            {
                query = query.Where(u => u.ErpId == erpId);
            }
            if (!string.IsNullOrEmpty(firstName))
            {
                query = query.Where(u => u.FirstName == firstName);
            }
            if (!string.IsNullOrEmpty(lastName))
            {
                query = query.Where(u => u.LastName == lastName);
            }
            if (!string.IsNullOrEmpty(username))
            {
                query = query.Where(u => u.Username == username);
            }

            return await query.ToListAsync();
        }

        /// <summary>
        /// Update user data from PUT body
        /// </summary>
        /// <param name="id">Id of user to be updated</param>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] User user)
        {
            // Retrieve the existing user from the database
            var existingUser = await _context.Users.FindAsync(id);

            if (existingUser == null)
            {
                return NotFound();
            }

            // Update the fields that are present in the request body
            if (user.FirstName != null) existingUser.FirstName = user.FirstName;
            if (user.LastName != null) existingUser.LastName = user.LastName;
            if (user.Username != null) existingUser.Username = user.Username;
            if (user.Password != null) existingUser.Password = user.Password;
            if (user.ErpId != null) existingUser.ErpId = user.ErpId;
            existingUser.Active = user.Active; // Active is a bool, handle it based on your needs

            // Save the changes to the database
            await _context.SaveChangesAsync();

            return NoContent();
        }

        /// <summary>
        /// Add user, make sure that ID is not in use and that all the required fields are given
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        // POST: api/Users
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUser", new { id = user.Id }, user);
        }

        /// <summary>
        /// Delete user
        /// </summary>
        /// <param name="id">Id of the user record to be deleted</param>
        /// <returns></returns>
        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.Id == id);
        }
    }
}
