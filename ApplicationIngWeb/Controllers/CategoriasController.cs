using ApplicationIngWeb.Data;
using ApplicationIngWeb.Models.Domain;
using ApplicationIngWeb.Models.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApplicationIngWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;

        public CategoriasController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }


        [HttpPost]

        public async Task<IActionResult> CreateCategory(CreateCategoryRequestDto request)
        {
            //DTO a modelo de dominio
            var category = new Categoria
            {
                Name = request.Name,
                UrlHandle = request.UrlHandle,
            };

            await dbContext.Categorias.AddAsync(category);
            await dbContext.SaveChangesAsync();

            //Modelo de Dominio a DTO

            var response = new CategoriaDTO
            {
                Id= category.CategoriaId,
                Name= category.Name,
                UrlHandle = request.UrlHandle,
            };

            return Ok(response);
        }

        //GET: https://localhost:7034/api/Categorias
        [HttpGet]
        public async Task<IActionResult> GetAllCategories()
        {
            var categorias = await dbContext.Categorias
                .Select(c => new CategoriaDTO
                {
                    Id = c.CategoriaId,
                    Name = c.Name,
                    UrlHandle = c.UrlHandle
                })
                .ToListAsync();

            return Ok(categorias);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoryById([FromRoute] int id)
        {
            var category = await dbContext.Categorias.FindAsync(id);

            if (category == null)
            {
                return NotFound(); // 404 si no se encuentra la categoría
            }

            var response = new CategoriaDTO
            {
                Id = category.CategoriaId,
                Name = category.Name,
                UrlHandle = category.UrlHandle
            };

            return Ok(response);
        }


        //GET: https://localhost:7034/api/categorias{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategory([FromRoute] int id, [FromBody] UpdateCategoryRequestDto request)
        {
            var existingCategory = await dbContext.Categorias.FindAsync(id);

            if (existingCategory == null)
            {
                return NotFound(); 
            }

            // Actualiza los campos
            existingCategory.Name = request.Name;
            existingCategory.UrlHandle = request.UrlHandle;

            await dbContext.SaveChangesAsync();

            // Devuelve la categoría actualizada como DTO
            var response = new CategoriaDTO
            {
                Id = existingCategory.CategoriaId,
                Name = existingCategory.Name,
                UrlHandle = existingCategory.UrlHandle
            };

            return Ok(response);
        }

        //DELETE: https://localhost:7034/api/categorias{id}

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var category = await dbContext.Categorias.FindAsync(id);

            if (category == null)
            {
                return NotFound(); // 404 si no existe
            }

            dbContext.Categorias.Remove(category);
            await dbContext.SaveChangesAsync();

            return NoContent(); // 204 si se eliminó correctamente
        }


    }
}
