#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using InspecaoAPI;
using InspecaoAPI.DataClasses;

namespace InspecaoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusController : ControllerBase
    {
        private readonly TarefasData _context;

        public StatusController(TarefasData context)
        {
            _context = context;
        }

        // GET: api/StatusModels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StatusModel>>> GetStatusTarefa()
        {
            return await _context.StatusTarefa.ToListAsync();
        }

        // GET: api/StatusModels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StatusModel>> GetStatusModel(int id)
        {
            var statusModel = await _context.StatusTarefa.FindAsync(id);

            if (statusModel == null)
            {
                return NotFound();
            }

            return statusModel;
        }

        // PUT: api/StatusModels/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStatusModel(int id, StatusModel statusModel)
        {
            if (id != statusModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(statusModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StatusModelExists(id))
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

        // POST: api/StatusModels
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<StatusModel>> PostStatusModel(StatusModel statusModel)
        {
            _context.StatusTarefa.Add(statusModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStatusModel", new { id = statusModel.Id }, statusModel);
        }

        // DELETE: api/StatusModels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStatusModel(int id)
        {
            var statusModel = await _context.StatusTarefa.FindAsync(id);
            if (statusModel == null)
            {
                return NotFound();
            }

            _context.StatusTarefa.Remove(statusModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StatusModelExists(int id)
        {
            return _context.StatusTarefa.Any(e => e.Id == id);
        }
    }
}
