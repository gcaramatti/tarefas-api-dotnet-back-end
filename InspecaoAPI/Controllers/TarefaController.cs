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
    public class TarefaController : ControllerBase
    {
        private readonly TarefasData _context;

        public TarefaController(TarefasData context)
        {
            _context = context;
        }

        // GET: api/TarefaModels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TarefaModel>>> GetTarefa()
        {
            return await _context.Tarefa.ToListAsync();
        }

        // GET: api/TarefaModels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TarefaModel>> GetTarefaModel(int id)
        {
            var tarefaModel = await _context.Tarefa.FindAsync(id);

            if (tarefaModel == null)
            {
                return NotFound();
            }

            return tarefaModel;
        }

        // PUT: api/TarefaModels/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTarefaModel(int id, TarefaModel tarefaModel)
        {
            if (id != tarefaModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(tarefaModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TarefaModelExists(id))
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

        // POST: api/TarefaModels
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TarefaModel>> PostTarefaModel(TarefaModel tarefaModel)
        {
            _context.Tarefa.Add(tarefaModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTarefaModel", new { id = tarefaModel.Id }, tarefaModel);
        }

        // DELETE: api/TarefaModels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTarefaModel(int id)
        {
            var tarefaModel = await _context.Tarefa.FindAsync(id);
            if (tarefaModel == null)
            {
                return NotFound();
            }

            _context.Tarefa.Remove(tarefaModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TarefaModelExists(int id)
        {
            return _context.Tarefa.Any(e => e.Id == id);
        }
    }
}
