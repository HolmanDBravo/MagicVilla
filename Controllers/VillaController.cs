using MagicVilla_API.Datos;
using MagicVilla_API.Modelos;
using MagicVilla_API.Modelos.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MagicVilla_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VillaController : ControllerBase
    {   

        private readonly ILogger<VillaController> _logger;
        private readonly ApplicationDbContext _db;
        public VillaController(ILogger<VillaController> logger, ApplicationDbContext db)
        {
            _logger = logger;
            _db = db;
        }


        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<VillaDto>> GetVillas()
        {
            _logger.LogInformation("Obtener las villas");
            return Ok(_db.Villas.ToList());
           
        }

        [HttpGet("id:int", Name="GetVilla")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public  ActionResult<VillaDto> GetVilla(int id)
        {
            if (id == 0)
            {
                _logger.LogError("Erro al traer villa con Id" + id);
                return BadRequest();
            }

            //var villa = VillaStore.villaDtos.FirstOrDefault(x => x.Id == id);
            var villa = _db.Villas.FirstOrDefault(x => x.Id == id);

            if (villa == null)
            { 
                return NotFound(); ;
            }
            return Ok(villa);

        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<VillaDto> CrearVilla([FromBody] VillaDto villaDto)
        {
            if (!ModelState.IsValid)
            { 
                return BadRequest(ModelState);
            }

            if (_db.Villas.FirstOrDefault(x=>x.Nombre.ToLower()==villaDto.Nombre.ToLower()) !=null)
            {
                ModelState.AddModelError("NombreExiste", "La villa ya existe");
                return BadRequest(ModelState);
            }
            if (villaDto == null)
            {
                return BadRequest(villaDto);
            }

            if (villaDto.Id > 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            Villa modelo = new Villa();            
            modelo.Nombre = villaDto.Nombre;
            modelo.Detalle = villaDto.Detalle;
            modelo.MetrosCuadrados = villaDto.MetrosCuadrados;
            modelo.Tarifa= villaDto.Tarifa;
            modelo.Ocupantes = villaDto.Ocupantes;
            modelo.Amenidad = villaDto.Amenidad;
            modelo.ImagenURL = villaDto.ImagenURL;
            
            _db.Villas.Add(modelo);
            _db.SaveChanges();

            return CreatedAtRoute("GetVilla", new {id=villaDto.Id },villaDto);

        }


        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult DeleteVilla(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            var villa = _db.Villas.FirstOrDefault(v => v.Id == id);
            if (villa == null)
            {
                return NotFound();
            }
                
            _db.Villas.Remove(villa);
            _db.SaveChanges();
            return NoContent();
        }

        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult UpdateVilla(int id, [FromBody] VillaDto villaDto)
        {
            if (villaDto == null || id != villaDto.Id)
            {
                return BadRequest();
            }
            //var villa = VillaStore.villaDtos.FirstOrDefault(v => v.Id == id);
            //villa.Nombre = villaDto.Nombre;
            //villa.MetrosCuadrados=  villaDto.MetrosCuadrados;
            //villa.Ocupantes= villaDto.Ocupantes;

            Villa modelo = new Villa();
            modelo.Id = villaDto.Id;
            modelo.Nombre = villaDto.Nombre;
            modelo.Detalle = villaDto.Detalle;
            modelo.MetrosCuadrados = villaDto.MetrosCuadrados;
            modelo.Tarifa = villaDto.Tarifa;
            modelo.Ocupantes = villaDto.Ocupantes;
            modelo.Amenidad = villaDto.Amenidad;
            modelo.ImagenURL    = villaDto.ImagenURL;

            _db.Update(modelo);
            _db.SaveChanges();
            return NoContent();

        }


        [HttpPatch("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult UpdatePartialVilla(int id, JsonPatchDocument<VillaDto> villaPatchDto)
        {
            if (villaPatchDto == null || id == 0)
            {
                return BadRequest();
            }
            var villa = _db.Villas.AsNoTracking().FirstOrDefault(v => v.Id == id);

            VillaDto villaDto = new VillaDto();
            villaDto.Id = villa.Id;
            villaDto.Nombre = villa.Nombre;
            villaDto.Detalle = villa.Detalle;
            villaDto.MetrosCuadrados = villa.MetrosCuadrados;
            villaDto.Tarifa = villa.Tarifa;
            villaDto.Ocupantes = villa.Ocupantes;
            villaDto.Amenidad = villa.Amenidad;
            villaDto.ImagenURL = villa.ImagenURL;

            if(villa ==null) return BadRequest();

            villaPatchDto.ApplyTo(villaDto, ModelState);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Villa modelo = new Villa();
            modelo.Id = villaDto.Id;
            modelo.Nombre = villaDto.Nombre;
            modelo.Detalle = villaDto.Detalle;
            modelo.MetrosCuadrados = villaDto.MetrosCuadrados;
            modelo.Tarifa = villaDto.Tarifa;
            modelo.Ocupantes = villaDto.Ocupantes;
            modelo.Amenidad = villaDto.Amenidad;
            modelo.ImagenURL= villaDto.ImagenURL;

            _db.Villas.Update(modelo);
            _db.SaveChanges();
            return NoContent();

        }


    }
}
