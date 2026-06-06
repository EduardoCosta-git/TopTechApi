using Microsoft.AspNetCore.Mvc;
using TopTechApi.Data;
using TopTechApi.Models;
using System;
using System.Linq;

namespace TopTechApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaPecaController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CategoriaPecaController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var lista = _context.CategoriasPeca.ToList();
            return Ok(lista);
        }

        [HttpGet("{id}")]
        public IActionResult GetPorId(int id)
        {
            var item = _context.CategoriasPeca.Find(id);
            if (item == null) return NotFound();
            return Ok(item);
        }

        [HttpPost]
        public IActionResult Post(CategoriaPeca item)
        {
            try
            {
                _context.CategoriasPeca.Add(item);
                _context.SaveChanges();
                return StatusCode(201, item);
            }
            catch (Exception)
            {
                return StatusCode(500, "Erro interno ao salvar a categoria.");
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, CategoriaPeca item)
        {
            if (id != item.Id) return BadRequest();

            try
            {
                _context.CategoriasPeca.Update(item);
                _context.SaveChanges();
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest("Erro ao atualizar. A categoria pode não existir.");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var item = _context.CategoriasPeca.Find(id);
            if (item == null) return NotFound();

            try
            {
                _context.CategoriasPeca.Remove(item);
                _context.SaveChanges();
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(500, "Erro interno ao excluir a categoria.");
            }
        }
    }
}