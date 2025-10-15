using Microsoft.AspNetCore.Mvc;
using GestionTecnicos.DAL;
using GestionTecnicos.Models;

namespace GestionTecnicos.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SistemasController : ControllerBase
    {
        private readonly Contexto _context;

        public SistemasController(Contexto context)
        {
            _context = context;
        }

        // GET: api/sistemas
        [HttpGet]
        public IActionResult GetAll()
        {
            var sistemas = _context.Sistemas.ToList();
            return Ok(sistemas);
        }

        // GET: api/sistemas/{id}
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var sistema = _context.Sistemas.Find(id);
            if (sistema == null)
                return NotFound();

            return Ok(sistema);
        }

        // POST: api/sistemas
        [HttpPost]
        public IActionResult Create(Sistemas sistema)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _context.Sistemas.Add(sistema);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetById), new { id = sistema.SistemaId }, sistema);
        }
    }
}
