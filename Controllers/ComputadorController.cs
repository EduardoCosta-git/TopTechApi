using Microsoft.AspNetCore.Mvc;
using TopTechApi.Data;
using TopTechApi.Models;
using System;
using System.Linq;

namespace TopTechApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComputadorController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ComputadorController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var lista = _context.Computadores.ToList();
            return Ok(lista);
        }

        [HttpGet("{id}")]
        public IActionResult GetPorId(int id)
        {
            var item = _context.Computadores.Find(id);
            if (item == null) return NotFound();
            return Ok(item);
        }

        [HttpPost]
        public IActionResult Post(Computador item)
        {
            try
            {
                _context.Computadores.Add(item);
                _context.SaveChanges();
                return StatusCode(201, item);
            }
            catch (Exception)
            {
                return StatusCode(500, "Erro interno ao salvar o computador.");
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Computador item)
        {
            if (id != item.Id) return BadRequest();

            try
            {
                _context.Computadores.Update(item);
                _context.SaveChanges();
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest("Erro ao atualizar. O computador pode não existir.");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var item = _context.Computadores.Find(id);
            if (item == null) return NotFound();

            try
            {
                _context.Computadores.Remove(item);
                _context.SaveChanges();
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(500, "Erro interno ao excluir o computador.");
            }
        }
    }
}