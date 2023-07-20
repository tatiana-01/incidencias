using API.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class PuestoController : BaseApiController
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;

    public PuestoController(IUnitOfWork _unitOfWork, IMapper mapper)
    {
        unitOfWork = _unitOfWork;
        this.mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<List<PuestosDTO>> Get()
    {
        var puestos = await unitOfWork.Puestos.GetAllAsync();
        return this.mapper.Map<List<PuestosDTO>>(puestos);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<PuestoDTO>> Get(int id)
    {
        var puesto = await unitOfWork.Puestos.GetByIdAsync(id);
        if (puesto == null)
        {
            return NotFound();
        }
        return this.mapper.Map<PuestoDTO>(puesto);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<PuestosDTO>> Post(PuestoPostDTO puestoCreacion)
    {
        var puesto = mapper.Map<Puesto>(puestoCreacion);
        this.unitOfWork.Puestos.Add(puesto);
        await unitOfWork.SaveAsync();
        if (puesto == null)
        {
            return BadRequest();
        }
        return this.mapper.Map<PuestosDTO>(puesto);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<PuestosDTO>> Put(int id, [FromBody] PuestosDTO puestoEdicion)
    {
        var puesto = mapper.Map<Puesto>(puestoEdicion);
        if (puesto == null)
        {
            return NotFound();
        }
        unitOfWork.Puestos.Update(puesto);
        await unitOfWork.SaveAsync();
        return this.mapper.Map<PuestosDTO>(puesto);

    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var salon = await unitOfWork.Puestos.GetByIdAsync(id);
        if (salon == null)
        {
            return NotFound();
        }
        unitOfWork.Puestos.Remove(salon);
        await unitOfWork.SaveAsync();
        return NoContent();
    }
}
