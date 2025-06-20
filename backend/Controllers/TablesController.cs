using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TableManagement.Data;
using TableManagement.Models;
using System.Threading.Tasks;

namespace TableManagement.Controllers
{
    [ApiController]
    [Route("api/[controller]")] // A URL será automaticamente "api/tables"
    public class TablesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public TablesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/tables
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Table>>> GetTables()
        {
            return await _context.Tables.ToListAsync();
        }

        // GET: api/tables/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Table>> GetTable(int id)
        {
            var table = await _context.Tables.FindAsync(id);
            if (table == null) return NotFound();
            return table;
        }

        // POST: api/tables
        [HttpPost]
        public async Task<ActionResult<Table>> CreateTable(Table newTable)
        {
            _context.Tables.Add(newTable);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetTable), new { id = newTable.Id }, newTable);
        }

        // PUT: api/tables/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTable(int id, Table updatedTable)
        {
            if (id != updatedTable.Id) return BadRequest();
            _context.Entry(updatedTable).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        // DELETE: api/tables/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTable(int id)
        {
            var table = await _context.Tables.FindAsync(id);
            if (table == null) return NotFound();
            _context.Tables.Remove(table);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}