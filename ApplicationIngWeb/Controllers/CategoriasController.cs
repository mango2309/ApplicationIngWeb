using ApplicationIngWeb.Data;
using ApplicationIngWeb.Models.Domain;
using ApplicationIngWeb.Models.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
                Nombre = request.Nombre,
                UrlHandle = request.UrlHandle,
            };

            await dbContext.Categorias.AddAsync(category);
            await dbContext.SaveChangesAsync();

            //Modelo de Dominio a DTO

            var response = new CategoriaDTO
            {
                CategoriaDtoId = category.CategoriaId,
                Nombre = category.Nombre,
                UrlHandle = request.UrlHandle,
            };

            return Ok(response);
        }
    }
}
