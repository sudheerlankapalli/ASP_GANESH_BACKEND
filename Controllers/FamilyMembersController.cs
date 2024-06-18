using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentRegistration.Data;
using StudentRegistration.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentRegistration.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FamilyMembersController : ControllerBase
    {
        private readonly StudentContext _context;

        public FamilyMembersController(StudentContext context)
        {
            _context = context;
        }

        // GET: api/FamilyMembers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FamilyMember>>> GetFamilyMembers()
        {
            return await _context.FamilyMembers.ToListAsync();
        }

        // GET: api/FamilyMembers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FamilyMember>> GetFamilyMember(int id)
        {
            var familyMember = await _context.FamilyMembers.FindAsync(id);

            if (familyMember == null)
            {
                return NotFound();
            }

            return familyMember;
        }

        // POST: api/FamilyMembers
        [HttpPost]
        public async Task<ActionResult<FamilyMember>> PostFamilyMember(FamilyMember familyMember)
        {
            _context.FamilyMembers.Add(familyMember);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFamilyMember", new { id = familyMember.ID }, familyMember);
        }

        // PUT: api/FamilyMembers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFamilyMember(int id, FamilyMember familyMember)
        {
            if (id != familyMember.ID)
            {
                return BadRequest();
            }

            _context.Entry(familyMember).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FamilyMemberExists(id))
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

        // DELETE: api/FamilyMembers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFamilyMember(int id)
        {
            var familyMember = await _context.FamilyMembers.FindAsync(id);
            if (familyMember == null)
            {
                return NotFound();
            }

            _context.FamilyMembers.Remove(familyMember);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FamilyMemberExists(int id)
        {
            return _context.FamilyMembers.Any(e => e.ID == id);
        }
    }
}
