using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetAPI.Models;

namespace JetAPI.Controllers
{
    [Route("api")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly Context _context;

        public ProdutosController(Context context)
        {
            _context = context;

            if (_context.Produtos.Count() == 0)
            {
                _context.Produtos.Add(new Produtos { Codigo = 1111, Nome = "Primeiro produto", Preco = 5.5f, Status = "Em estoque" });
                _context.Produtos.Add(new Produtos { Codigo = 2222, Nome = "Segundo produto", Preco = 5.5f, Status = "Em estoque" });
                _context.Produtos.Add(new Produtos { Codigo = 3333, Nome = "Terceiro produto", Preco = 5.5f, Status = "Em estoque" });
                _context.Produtos.Add(new Produtos { Codigo = 4444, Nome = "Quarto produto", Preco = 5.5f, Status = "Em estoque" });
                _context.Produtos.Add(new Produtos { Codigo = 5555, Nome = "Quinto produto", Preco = 5.5f, Status = "Em estoque" });
                _context.SaveChanges();
            }
        }
        // GET: api/
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Produtos>>> GetProdutos()
        {
            return await _context.Produtos.ToListAsync();
        }

        // GET: api/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Produtos>> GetProduto(long id)
        {
            var Produto = await _context.Produtos.FindAsync(id);

            if (Produto == null)
            {
                return NotFound();
            }

            return Produto;
        }

        [HttpPost]
        public async Task<ActionResult<Produtos>> PostProduto(Produtos p)
        {
            _context.Produtos.Add(p);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetProduto), new { id = p.Id }, p);
        }

        // PUT: api/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTodoItem(long id, Produtos p)
        {
            if (id != p.Id)
            {
                return BadRequest();
            }

            _context.Entry(p).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}