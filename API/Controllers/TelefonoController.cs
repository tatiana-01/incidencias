using API.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace API.Controllers;


public class TelefonoController : BaseApiController
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;

    public TelefonoController(IUnitOfWork _unitOfWork, IMapper mapper)
    {
        unitOfWork = _unitOfWork;
        this.mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<List<TelefonosDTO>> Get()
    {
        var telefonos = await unitOfWork.Telefonos.GetAllAsync();
        return this.mapper.Map<List<TelefonosDTO>>(telefonos);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<TelefonoDTO>> Get(int id)
    {
        var telefono = await unitOfWork.Telefonos.GetByIdAsync(id);
        if(telefono == null){
            return NotFound();
        }
        return this.mapper.Map<TelefonoDTO>(telefono);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<TelefonosDTO>> Post(TelefonoPostDTO telefonoCreacion)
    {
        var telefono = mapper.Map<Telefono>(telefonoCreacion);
        this.unitOfWork.Telefonos.Add(telefono);
        await unitOfWork.SaveAsync();
        if (telefono == null)
        {
            return BadRequest();
        }
        return this.mapper.Map<TelefonosDTO>(telefono); 
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<TelefonosDTO>> Put(int id, [FromBody] TelefonosDTO telefonoEdicion)
    {
        var telefono = mapper.Map<Telefono>(telefonoEdicion);
        if (telefono == null)
        {
            return NotFound();
        }
        unitOfWork.Telefonos.Update(telefono);
        await unitOfWork.SaveAsync();
        return this.mapper.Map<TelefonosDTO>(telefono);

    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var telefono = await unitOfWork.Telefonos.GetByIdAsync(id);
        if (telefono == null)
        {
            return NotFound();
        }
        unitOfWork.Telefonos.Remove(telefono);
        await unitOfWork.SaveAsync();
        return NoContent();
    }
}