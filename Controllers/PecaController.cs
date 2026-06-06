using Microsoft.AspNetCore.Mvc;
using TopTechApi.Data;
using TopTechApi.Models;
using System;
using System.Linq;

namespace TopTechApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PecaController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PecaController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var lista = _context.Pecas.ToList();
            return Ok(lista);
        }

        [HttpGet("{id}")]
        public IActionResult GetPorId(int id)
        {
            var item = _context.Pecas.Find(id);
            if (item == null) return NotFound();
            return Ok(item);
        }

        [HttpPost]
        public IActionResult Post(Peca item)
        {
            try
            {
                _context.Pecas.Add(item);
                _context.SaveChanges();
                return StatusCode(201, item);
            }
            catch (Exception)
            {
                return StatusCode(500, "Erro interno ao salvar a peça.");
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Peca item)
        {
            if (id != item.Id) return BadRequest();

            try
            {
                _context.Pecas.Update(item);
                _context.SaveChanges();
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest("Erro ao atualizar. A peça pode não existir.");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var item = _context.Pecas.Find(id);
            if (item == null) return NotFound();

            try
            {
                _context.Pecas.Remove(item);
                _context.SaveChanges();
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(500, "Erro interno ao excluir a peça.");
            }
        }
    }
}