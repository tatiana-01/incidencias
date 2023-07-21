using API.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace API.Controllers;


public class EmailTrainerController : BaseApiController
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;

    public EmailTrainerController(IUnitOfWork _unitOfWork, IMapper mapper)
    {
        unitOfWork = _unitOfWork;
        this.mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<List<EmailTrainersDTO>> Get()
    {
        var emailsTrainers = await unitOfWork.EmailsTrainers.GetAllAsync();
        return this.mapper.Map<List<EmailTrainersDTO>>(emailsTrainers);
    }

    [HttpGet("{idTrainer}/{idEmail}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<EmailTrainersDTO>> Get(string idTrainer, int idEmail)
    {
        var emailTrainer = await unitOfWork.EmailsTrainers.GetByIdAsync(idTrainer,idEmail);
        if(emailTrainer == null){
            return NotFound();
        }
        return this.mapper.Map<EmailTrainersDTO>(emailTrainer);
    }

    [HttpGet("{idTrainer}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<EmailTrainersDTO>> Get(string idTrainer)
    {
        var emailTrainer = await unitOfWork.EmailsTrainers.GetByIdTrainerAsync(idTrainer);
        if(emailTrainer == null){
            return NotFound();
        }
        return this.mapper.Map<EmailTrainersDTO>(emailTrainer);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<EmailTrainersDTO>> Post(EmailTrainersDTO emailTrainerCreacion)
    {
        var emailTrainer = mapper.Map<EmailTrainer>(emailTrainerCreacion);
        this.unitOfWork.EmailsTrainers.Add(emailTrainer);
        await unitOfWork.SaveAsync();
        if (emailTrainer == null)
        {
            return BadRequest();
        }
        return this.mapper.Map<EmailTrainersDTO>(emailTrainer); 
    }

    [HttpPut("{idTrainer}/{idEmail}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<EmailTrainersDTO>> Put(string idTrainer, int idEmail, [FromBody] EmailTrainersDTO emailEdicion)
    {
        var email = mapper.Map<EmailTrainer>(emailEdicion);
        if (email == null)
        {
            return NotFound();
        }
        unitOfWork.EmailsTrainers.Update(email);
        await unitOfWork.SaveAsync();
        return this.mapper.Map<EmailTrainersDTO>(email);

    }

    [HttpDelete("{idTrainer}/{idEmail}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(string idTrainer, int idEmail)
    {
        var emailTrainer = await unitOfWork.EmailsTrainers.GetByIdAsync(idTrainer,idEmail);
        if (emailTrainer == null)
        {
            return NotFound();
        }
        unitOfWork.EmailsTrainers.Remove(emailTrainer);
        await unitOfWork.SaveAsync();
        return NoContent();
    }
}