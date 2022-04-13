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
    public class TipoTarefaController : ControllerBase
    {
        private readonly TarefasData _context;

        public TipoTarefaController(TarefasData context)
        {
            _context = context;
        }

        // GET: api/TipoTarefaModels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TipoTarefaModel>>> GetTipoTarefa()
        {
            return await _context.TipoTarefa.ToListAsync();
        }

        // GET: api/TipoTarefaModels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TipoTarefaModel>> GetTipoTarefaModel(int id)
        {
            var tipoTarefaModel = await _context.TipoTarefa.FindAsync(id);

            if (tipoTarefaModel == null)
            {
                return NotFound();
            }

            return tipoTarefaModel;
        }

        // PUT: api/TipoTarefaModels/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTipoTarefaModel(int id, TipoTarefaModel tipoTarefaModel)
        {
            if (id != tipoTarefaModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(tipoTarefaModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TipoTarefaModelExists(id))
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

        // POST: api/TipoTarefaModels
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TipoTarefaModel>> PostTipoTarefaModel(TipoTarefaModel tipoTarefaModel)
        {
            _context.TipoTarefa.Add(tipoTarefaModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTipoTarefaModel", new { id = tipoTarefaModel.Id }, tipoTarefaModel);
        }

        // DELETE: api/TipoTarefaModels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTipoTarefaModel(int id)
        {
            var tipoTarefaModel = await _context.TipoTarefa.FindAsync(id);
            if (tipoTarefaModel == null)
            {
                return NotFound();
            }

            _context.TipoTarefa.Remove(tipoTarefaModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TipoTarefaModelExists(int id)
        {
            return _context.TipoTarefa.Any(e => e.Id == id);
        }
    }
}
