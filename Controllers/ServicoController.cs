using Microsoft.AspNetCore.Mvc;
using TopTechApi.Data;
using TopTechApi.Models;
using System;
using System.Linq;

namespace TopTechApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicoController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ServicoController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var lista = _context.Servicos.ToList();
            return Ok(lista);
        }

        [HttpGet("{id}")]
        public IActionResult GetPorId(int id)
        {
            var item = _context.Servicos.Find(id);
            if (item == null) return NotFound();
            return Ok(item);
        }

        [HttpPost]
        public IActionResult Post(Servico item)
        {
            try
            {
                _context.Servicos.Add(item);
                _context.SaveChanges();
                return StatusCode(201, item);
            }
            catch (Exception)
            {
                return StatusCode(500, "Erro interno ao salvar o serviço.");
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Servico item)
        {
            if (id != item.Id) return BadRequest();

            try
            {
                _context.Servicos.Update(item);
                _context.SaveChanges();
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest("Erro ao atualizar. O serviço pode não existir.");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var item = _context.Servicos.Find(id);
            if (item == null) return NotFound();

            try
            {
                _context.Servicos.Remove(item);
                _context.SaveChanges();
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(500, "Erro interno ao excluir o serviço.");
            }
        }
    }
}