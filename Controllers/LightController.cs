using CarAPI.Context;
using CarAPI.DTOs;
using CarAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LightController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public LightController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/lights
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Light>>> GetLights()
        {
            return await _context.Lights.ToListAsync();
        }

        // GET: api/lights/{carId}
        [HttpGet("{carId}")]
        public async Task<ActionResult<Light>> GetLight(int carId)
        {

            var car = await _context.Cars.Include(c => c.Light).FirstOrDefaultAsync(c => c.Id == carId);

            if (car == null)
            {
                return NotFound();
            }

            var existingLight = car.Light;

            if (existingLight == null)
            {
                return BadRequest("The car does not have lights.");
            }


            return existingLight;
        }

        // POST: api/lights/{carId}
        [HttpPost("{carId}")]
        public async Task<ActionResult<Light>> AddLight(int carId, [FromBody] Light light)
        {
            var car = await _context.Cars.FindAsync(carId);
            if (car == null)
            {
                return NotFound();
            }

            light.CarId = carId;
            _context.Lights.Add(light);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetLight), new { id = car.Id }, light);
        }

        // PUT: api/lights/{carId}
        [HttpPut("{carId}")]
        public async Task<IActionResult> UpdateLightByCarId(int carId, LightUpdateDto updatedLight)
        {
            var car = await _context.Cars.Include(c => c.Light).FirstOrDefaultAsync(c => c.Id == carId);

            if (car == null)
            {
                return NotFound();
            }

            var existingLight = car.Light;

            if (existingLight == null)
            {
                return BadRequest("The car does not have lights.");
            }

            if (updatedLight.HeadLights != null)
            {
                existingLight.HeadLights = updatedLight.HeadLights;
            }
            if (updatedLight.FogLights != null)
            {
                existingLight.FogLights = updatedLight.FogLights;
            }
            if (updatedLight.Angle != null)
            {
                existingLight.Angle = (int)updatedLight.Angle;
            }

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LightExists(existingLight.LightId))
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

        // DELETE: api/lights/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLight(int id)
        {
            var light = await _context.Lights.FindAsync(id);
            if (light == null)
            {
                return NotFound();
            }

            _context.Lights.Remove(light);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LightExists(int id)
        {
            return _context.Lights.Any(e => e.LightId == id);
        }
    }
}
