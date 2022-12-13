using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BibliotecaWeb.Data;
using BibliotecaWeb.Models;

namespace BibliotecaWeb.Apis
{
    [Route("api/[controller]")]
    [ApiController]
    public class apiEditorialesController : ControllerBase
    {
        private readonly smartsof_biblioContext _context;

        public apiEditorialesController(smartsof_biblioContext context)
        {
            _context = context;
        }

        // GET: api/apiEditoriales
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Editoriale>>> GetEditoriales()
        {
            return await _context.Editoriales.ToListAsync();
        }

        // GET: api/apiEditoriales/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Editoriale>> GetEditoriale(int id)
        {
            var editoriale = await _context.Editoriales.FindAsync(id);

            if (editoriale == null)
            {
                return NotFound();
            }

            return editoriale;
        }

        // PUT: api/apiEditoriales/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEditoriale(int id, Editoriale editoriale)
        {
            if (id != editoriale.Id)
            {
                return BadRequest();
            }

            _context.Entry(editoriale).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EditorialeExists(id))
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

        // POST: api/apiEditoriales
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Editoriale>> PostEditoriale(Editoriale editoriale)
        {
            _context.Editoriales.Add(editoriale);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEditoriale", new { id = editoriale.Id }, editoriale);
        }

        // DELETE: api/apiEditoriales/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEditoriale(int id)
        {
            var editoriale = await _context.Editoriales.FindAsync(id);
            if (editoriale == null)
            {
                return NotFound();
            }

            _context.Editoriales.Remove(editoriale);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EditorialeExists(int id)
        {
            return _context.Editoriales.Any(e => e.Id == id);
        }
    }
}
