using API.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace API.Controllers;


public class TelefonoTrainerController : BaseApiController
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;

    public TelefonoTrainerController(IUnitOfWork _unitOfWork, IMapper mapper)
    {
        unitOfWork = _unitOfWork;
        this.mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<List<TelefonoTrainersDTO>> Get()
    {
        var telefonosTrainers = await unitOfWork.TelefonosTrainers.GetAllAsync();
        return this.mapper.Map<List<TelefonoTrainersDTO>>(telefonosTrainers);
    }

    [HttpGet("{idTrainer}/{idTelefono}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<TelefonoTrainersDTO>> Get(string idTrainer, int idTelefono)
    {
        var telefonoTrainer = await unitOfWork.TelefonosTrainers.GetByIdAsync(idTrainer,idTelefono);
        if(telefonoTrainer == null){
            return NotFound();
        }
        return this.mapper.Map<TelefonoTrainersDTO>(telefonoTrainer);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<TelefonoTrainersDTO>> Post(TelefonoTrainersDTO telefonoTrainerCreacion)
    {
        var telefonoTrainer = mapper.Map<TelefonoTrainer>(telefonoTrainerCreacion);
        this.unitOfWork.TelefonosTrainers.Add(telefonoTrainer);
        await unitOfWork.SaveAsync();
        if (telefonoTrainer == null)
        {
            return BadRequest();
        }
        return this.mapper.Map<TelefonoTrainersDTO>(telefonoTrainer); 
    }

    [HttpPut("{idTrainer}/{idTelefono}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<TelefonoTrainersDTO>> Put(string idTrainer, int idTelefono, [FromBody] TelefonoTrainersDTO telefonoEdicion)
    {
        var telefono = mapper.Map<TelefonoTrainer>(telefonoEdicion);
        if (telefono == null)
        {
            return NotFound();
        }
        unitOfWork.TelefonosTrainers.Update(telefono);
        await unitOfWork.SaveAsync();
        return this.mapper.Map<TelefonoTrainersDTO>(telefono);

    }

    [HttpDelete("{idTrainer}/{idTelefono}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(string idTrainer, int idTelefono)
    {
        var telefonoTrainer = await unitOfWork.TelefonosTrainers.GetByIdAsync(idTrainer,idTelefono);
        if (telefonoTrainer == null)
        {
            return NotFound();
        }
        unitOfWork.TelefonosTrainers.Remove(telefonoTrainer);
        await unitOfWork.SaveAsync();
        return NoContent();
    }
}