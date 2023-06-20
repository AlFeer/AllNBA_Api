using AllNbaApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace AllNbaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StarController : ControllerBase
    {
        private readonly DataContext _context;

        public StarController(DataContext context)
        {
            _context = context;
        }
        
        [HttpGet]
        public async Task<ActionResult<List<Star>>> Get()
        {
            return Ok(await _context.Stars.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Star>> Get(int id)
        {
            var star = await _context.Stars.FindAsync(id);
            if (star is null)
            {
                return BadRequest("Cannot found");
            }
            return Ok(star);
        }

        [HttpPost]
        public async Task<ActionResult<List<Star>>> AddStar(Star star)
        {
            _context.Stars.Add(star);
            await _context.SaveChangesAsync();
            return Ok(await _context.Stars.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Star>>> UpdateStar(Star request)
        {
            var star = await _context.Stars.FindAsync(request.Id);
            if (star is null)
            {
                return BadRequest("Cannot found");
            }

            star.Name = request.Name;
            star.Fullname = request.Fullname;
            star.Number = request.Number;
            star.Position = request.Position;

            await _context.SaveChangesAsync();

            return Ok(await _context.Stars.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Star>> Delete(int id)
        {
            var star = await _context.Stars.FindAsync(id);
            if (star is null)
            {
                return BadRequest("Cannot found");
            }

             _context.Stars.Remove(star);

            await _context.SaveChangesAsync();

            return Ok(await _context.Stars.ToListAsync());
        }
    }
}
