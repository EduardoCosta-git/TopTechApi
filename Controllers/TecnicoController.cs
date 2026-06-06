using Microsoft.AspNetCore.Mvc;
using TopTechApi.Data;
using TopTechApi.Models;
using System;
using System.Linq;

namespace TopTechApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TecnicoController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TecnicoController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var lista = _context.Tecnicos.ToList();
            return Ok(lista);
        }

        [HttpGet("{id}")]
        public IActionResult GetPorId(int id)
        {
            var item = _context.Tecnicos.Find(id);
            if (item == null) return NotFound();
            return Ok(item);
        }

        [HttpPost]
        public IActionResult Post(Tecnico item)
        {
            try
            {
                _context.Tecnicos.Add(item);
                _context.SaveChanges();
                return StatusCode(201, item);
            }
            catch (Exception)
            {
                return StatusCode(500, "Erro interno ao salvar o técnico.");
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Tecnico item)
        {
            if (id != item.Id) return BadRequest();

            try
            {
                _context.Tecnicos.Update(item);
                _context.SaveChanges();
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest("Erro ao atualizar. O técnico pode não existir.");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var item = _context.Tecnicos.Find(id);
            if (item == null) return NotFound();

            try
            {
                _context.Tecnicos.Remove(item);
                _context.SaveChanges();
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(500, "Erro interno ao excluir o técnico.");
            }
        }
    }
}