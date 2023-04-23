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
            catch (Exception error)
            {
                return BadRequest(new { message = $"Não foi possivel cadastrar{error.Message}" });
            }
        }


        [HttpGet("{id:int}")]
        public ActionResult<MedicoModel> Get([FromRoute] int id)
        {
            try
            {
                var medicoModel = medicoRepository.ConsultarPorId(id);
                if (medicoModel != null)
                {
                    return Ok(medicoModel);
                }
                else
                {
                    return NotFound();
                }


            } catch (KeyNotFoundException ex)
            {
                throw ex;
            }
        }

        public ActionResult<MedicoModel> Put([FromRoute] int id, [FromBody] MedicoModel medicoModel)
        {
            if (medicoModel.MedicoId != id)
            {
                return NotFound();
            }
            try
            {
                medicoRepository.Inserir(medicoModel);
                return NoContent();
            } catch (Exception error)
            {
                return BadRequest(new { message = $"Não foi possível alterar {error}" });
            }
        }

        [HttpDelete]
        public ActionResult<MedicoModel> Delete([FromRoute] int id)
        {
            try
            {
                var medicoModel = medicoRepository.ConsultarPorId(id);

                if (medicoModel != null)
                {
                    medicoRepository.Excluir(medicoModel);
                    return NoContent();
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }
    }
}

