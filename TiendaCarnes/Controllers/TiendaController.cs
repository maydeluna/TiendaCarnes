using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TiendaCarnes.DTOs;

namespace TiendaCarnes.Controllers
{
    [ApiController]
    [Route("api/tienda")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "EsAdministrador")]

    public class TiendaController: ControllerBase
    {
        private readonly ApplicationDbContext dbContext;

        private readonly IMapper mapper;
        private readonly IConfiguration configuracion;

        public TiendaController(ApplicationDbContext dbContext, IMapper mapper, IConfiguration configuracion)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
            this.configuracion = configuracion;
        }

     

    }

}

