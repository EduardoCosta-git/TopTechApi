using Microsoft.AspNetCore.Mvc;
using TopTechApi.Data;
using TopTechApi.Models;
using System;
using System.Linq;

namespace TopTechApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ClientesController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var lista = _context.Clientes.ToList();
            return Ok(lista);
        }

        [HttpGet("{id}")]
        public IActionResult GetPorId(int id)
        {
            var item = _context.Clientes.Find(id);
            if (item == null) return NotFound();
            return Ok(item);
        }

        [HttpPost]
        public IActionResult Post(Cliente item)
        {
            try
            {
                _context.Clientes.Add(item);
                _context.SaveChanges();
                return StatusCode(201, item);
            }
            catch (Exception)
            {
                return StatusCode(500, "Erro interno ao salvar o cliente.");
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Cliente item)
        {
            if (id != item.Id) return BadRequest("O ID da URL é diferente do ID do cliente.");

            try
            {
                _context.Clientes.Update(item);
                _context.SaveChanges();
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest("Erro ao atualizar. O cliente pode não existir no banco.");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var item = _context.Clientes.Find(id);
            if (item == null) return NotFound();

            try
            {
                _context.Clientes.Remove(item);
                _context.SaveChanges();
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(500, "Erro interno ao excluir o cliente.");
            }
        }
    }
}