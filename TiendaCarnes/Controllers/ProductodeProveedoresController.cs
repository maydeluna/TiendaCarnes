using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TiendaCarnes.Entidades;
using Microsoft.AspNetCore.Http;
using TiendaCarnes.DTOs;
using AutoMapper;



namespace TiendaCarnes.Controllers

{
    [ApiController]
    [Route("api/productodeprovedoores")]
    public class ProductodeProvedooresController : ControllerBase

    {
        private readonly ApplicationDbContext dbContext;
        private readonly IMapper mapper;

        public ProductodeProvedooresController(ApplicationDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        [HttpGet]
        [HttpGet("/listadoProductodeProvedoores")]

        public async Task<ActionResult<List<ProductodeProvedoores>>> GetAll()
        {
            return await dbContext.ProductodeProvedoores.ToListAsync();
        }
        [HttpGet("{id:int}", Name = "obtenerProductosDisponibles")]
        public async Task<ActionResult<ProductosProvedooresDTOTienda>> GetById(int id)
        {
            var ProductodeProvedoores = await dbContext.ProductodeProvedoores
                .Include(TiendaDB => TiendaDB.TiendaProductoProvedoores)
                .ThenInclude(TiendaProductoProvedooresDB => TiendaProductoProvedooresDB.Tienda)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (ProductodeProvedoores == null)
            {
                return NotFound();
            }

            ProductodeProvedoores.TiendaProductoProvedoores = ProductodeProvedoores.TiendaProductoProvedoores.OrderBy(x => x.Orden).ToList();

            return mapper.Map<ProductosProvedooresDTOTienda>(ProductodeProvedoores);
        }
        [HttpPost]
        public async Task<ActionResult> Post(ProductosCreacionDTO productosCreacionDTO)
        {
            if (productosCreacionDTO.TiendaId == null)
            {
                return BadRequest("No se puede iniciar");
            }

            var tiendaid = await dbContext.Tienda.Where(tiendaBD => productosCreacionDTO.TiendaId.Contains(tiendaBD.Id)).Select(x => x.Id).ToListAsync();

            if (productosCreacionDTO.TiendaId.Count != tiendaid.Count)
            {
                return BadRequest("No hay tienda :c");
            }

            var productos = mapper.Map<ProductodeProvedoores>(productosCreacionDTO);



            dbContext.Add(productos);
            await dbContext.SaveChangesAsync();
            var ProductodeProveedoresDTO = mapper.Map<ProductodeProveedoresDTO>(productos);

            return CreatedAtRoute("obtenerProductos", new { id = productos.Id }, ProductodeProveedoresDTO);
        }
        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(ProductosCreacionDTO productodeProveedoresDTO, int id)
        {
            var exist = await dbContext.ProductodeProvedoores.AnyAsync(x => x.Id == id);
            if (!exist)
            {
                return NotFound();
            }

            var productos = mapper.Map<ProductodeProvedoores>(productodeProveedoresDTO);
            productos.Id = id;

            dbContext.Update(productos);
            await dbContext.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var existe = await dbContext.ProductodeProvedoores.AnyAsync(x => x.Id == id);

            if (!existe)
            {
                return NotFound();
            }

            dbContext.Remove(new ProductodeProvedoores()
            {
                Id = id
            });
            await dbContext.SaveChangesAsync();
            return Ok();
        }

    }

}
