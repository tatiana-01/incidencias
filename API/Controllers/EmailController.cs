using API.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace API.Controllers;


public class EmailController : BaseApiController
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;

    public EmailController(IUnitOfWork _unitOfWork, IMapper mapper)
    {
        unitOfWork = _unitOfWork;
        this.mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<List<EmailsDTO>> Get()
    {
        var emails = await unitOfWork.Emails.GetAllAsync();
        return this.mapper.Map<List<EmailsDTO>>(emails);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<EmailDTO>> Get(int id)
    {
        var email = await unitOfWork.Emails.GetByIdAsync(id);
        if(email == null){
            return NotFound();
        }
        return this.mapper.Map<EmailDTO>(email);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<EmailsDTO>> Post(EmailPostDTO emailCreacion)
    {
        var email = mapper.Map<Email>(emailCreacion);
        this.unitOfWork.Emails.Add(email);
        await unitOfWork.SaveAsync();
        if (email == null)
        {
            return BadRequest();
        }
        return this.mapper.Map<EmailsDTO>(email); 
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<EmailsDTO>> Put(int id, [FromBody] EmailPostDTO emailEdicion)
    {
        var email = mapper.Map<Email>(emailEdicion);
        email.id = id;
        if (email == null)
        {
            return NotFound();
        }
        unitOfWork.Emails.Update(email);
        await unitOfWork.SaveAsync();
        return this.mapper.Map<EmailsDTO>(email);

    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var email = await unitOfWork.Emails.GetByIdAsync(id);
        if (email == null)
        {
            return NotFound();
        }
        unitOfWork.Emails.Remove(email);
        await unitOfWork.SaveAsync();
        return NoContent();
    }
}