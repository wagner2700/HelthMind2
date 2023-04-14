using HelthMind2.Context;
using HelthMind2.Model;
using HelthMind2.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

namespace HelthMind2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicoController : ControllerBase
    {
        private readonly MedicoRepository medicoRepository;

        public MedicoController(DataBaseContext context)
        {
            medicoRepository = new MedicoRepository(context);
        }

        [HttpGet]
        public ActionResult<List<MedicoModel>> Get()
        {
            try
            {
                var lista = medicoRepository.Listar();

                if (lista != null)
                {
                    return Ok(lista);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            }

        [HttpPost]
        public ActionResult<MedicoModel> Post([FromBody] MedicoModel medicoModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);

            }

            try
            {
                medicoRepository.Inserir(medicoModel);
                var location = new Uri(Request.GetEncodedUrl() + "/" + medicoModel.MedicoId);
                return Created(location, medicoModel);
            }
                catch(Exception error)
            {
                return BadRequest(new { message = $"Não foi possivel{error.Message}" });
            }
        }


        [HttpGet("{id:int}")]
        public ActionResult<MedicoModel> Get([FromRoute] int id)
        {
            try
            {
                var medicoModel = medicoRepository.ConsultarPorId(id);

                return Ok(medicoModel);

            }catch (KeyNotFoundException ex) 
            {
                throw ex;
            }
        }
    }
}
