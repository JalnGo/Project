using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ForProject.Data;
using ForProject.Models;

namespace ForProject.Controllers
{
    [Produces("application/json")]
    [Route("api/CreateUsers")]
    public class CreateUsersController : Controller
    {
        private readonly UserContext _context;

        public CreateUsersController(UserContext context)
        {
            _context = context;
        }

        // GET: api/CreateUsers
        [HttpGet]
        public IEnumerable<CreateUser> GetCreateUser()
        {
            return _context.CreateUser;
        }

        // GET: api/CreateUsers/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCreateUser([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var createUser = await _context.CreateUser.SingleOrDefaultAsync(m => m.UserId == id);

            if (createUser == null)
            {
                return NotFound();
            }

            return Ok(createUser);
        }

        // PUT: api/CreateUsers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCreateUser([FromRoute] int id, [FromBody] CreateUser createUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != createUser.UserId)
            {
                return BadRequest();
            }

            _context.Entry(createUser).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CreateUserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/CreateUsers
        [HttpPost]
        public async Task<IActionResult> PostCreateUser([FromBody] CreateUser createUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.CreateUser.Add(createUser);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCreateUser", new { id = createUser.UserId }, createUser);
        }

        // DELETE: api/CreateUsers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCreateUser([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var createUser = await _context.CreateUser.SingleOrDefaultAsync(m => m.UserId == id);
            if (createUser == null)
            {
                return NotFound();
            }

            _context.CreateUser.Remove(createUser);
            await _context.SaveChangesAsync();

            return Ok(createUser);
        }

        private bool CreateUserExists(int id)
        {
            return _context.CreateUser.Any(e => e.UserId == id);
        }
    }
}