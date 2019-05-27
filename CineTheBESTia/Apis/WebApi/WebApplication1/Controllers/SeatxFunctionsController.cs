using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DbContext;
using Domain;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeatxFunctionsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public SeatxFunctionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/SeatxFunctions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SeatxFunction>>> GetSeatxFunction()
        {
            return await _context.SeatxFunction.ToListAsync();
        }

        // GET: api/SeatxFunctions/GetFunctionbyId/5
        [HttpGet("GetFunctionbyId/{id}")]
        public async Task<ActionResult<IEnumerable<SeatxFunction>>> GetFunctionbyId(int id)
        {
            var seatxFunction = _context.SeatxFunction.Where(e => e.function.Id == id).ToList();

            if (seatxFunction == null)
            {
                return NotFound();
            }

            return seatxFunction;
        }

        // GET: api/SeatxFunctions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SeatxFunction>> GetSeatxFunctio(int id)
        {
            var seatxFunction = await _context.SeatxFunction.FindAsync(id);

            if (seatxFunction == null)
            {
                return NotFound();
            }

            return seatxFunction;
        }

        // PUT: api/SeatxFunctions/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSeatxFunction(int id, SeatxFunction seatxFunction)
        {
            if (id != seatxFunction.Id)
            {
                return BadRequest();
            }

            _context.Entry(seatxFunction).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SeatxFunctionExists(id))
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

        // POST: api/SeatxFunctions
        [HttpPost]
        public async Task<ActionResult<SeatxFunction>> PostSeatxFunction(SeatxFunction seatxFunction)
        {
            _context.SeatxFunction.Add(seatxFunction);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSeatxFunction", new { id = seatxFunction.Id }, seatxFunction);
        }

        // DELETE: api/SeatxFunctions/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<SeatxFunction>> DeleteSeatxFunction(int id)
        {
            var seatxFunction = await _context.SeatxFunction.FindAsync(id);
            if (seatxFunction == null)
            {
                return NotFound();
            }

            _context.SeatxFunction.Remove(seatxFunction);
            await _context.SaveChangesAsync();

            return seatxFunction;
        }

        private bool SeatxFunctionExists(int id)
        {
            return _context.SeatxFunction.Any(e => e.Id == id);
        }
    }
}
