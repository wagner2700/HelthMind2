
using HelthMind2.Context;
using HelthMind2.Model;
using HelthMind2.Repository;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage;
using System.Security.Cryptography;

namespace HelthMind2.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PacienteController : ControllerBase
{
    private readonly PacienteRepository pacienteRepository;

    public PacienteController(DataBaseContext context)
    {
        pacienteRepository = new PacienteRepository(context);
    }

    [HttpGet]
    public ActionResult<List<PacienteModel>> Get()
    {
        try
        {
            var listaPacientes = pacienteRepository.ListarPacientes();

            if(listaPacientes != null)
            {
                return Ok(listaPacientes);
            }
            else
            {
                return NotFound();
            }
        }catch(Exception e)
        {  
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }

    [HttpGet("{id:int}")]
    public ActionResult<PacienteModel>Get([FromRoute] int id)
    {
        try
        {
            var pacienteModel = pacienteRepository.ConsultarPorId(id);
            if( pacienteRepository != null)
            {
                return Ok(pacienteModel);
            }
            else
            {
                return NotFound();
            }
        }catch(Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError);
        }


    }


    [HttpPost]
    public ActionResult<PacienteModel>Post([FromBody] PacienteModel pacienteModel)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        try
            {
                pacienteRepository.InserirPaciente(pacienteModel);
                var location = new Uri(Request.GetEncodedUrl() + "/" + pacienteModel.PacienteId);
                return Created(location, pacienteModel);
            }catch(Exception error)
        {
            return BadRequest(new { message = $"Não foi possível cadastrar . Detalhes: {error.Message}" });
        }
    }

    [HttpPut("{id:int}")]
    public ActionResult<PacienteModel> Put([FromRoute] int id , [FromBody] PacienteModel pacienteModel)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        if (pacienteModel.PacienteId != id)
        {
            return NotFound();
        }

        try
        {
            pacienteRepository.AlterarPaciente(pacienteModel);
            return NoContent();
        }catch(Exception error)
        {
            return BadRequest(new { message = $"Não foi possível alterar {error}" });
        }
    }

    [HttpDelete("{id:int}")]
    public ActionResult<PacienteModel> Delete([FromRoute] int id)
    {
        try
        {
            var pacienteModel = pacienteRepository.ConsultarPorId(id);

            if(pacienteModel != null)
            {
                pacienteRepository.ExcluirPaciente(pacienteModel);

                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }catch(Exception e)
        {
            return BadRequest();
        }
    }

   
}
