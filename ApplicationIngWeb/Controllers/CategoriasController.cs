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
    }
}
