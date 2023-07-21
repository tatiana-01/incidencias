using API.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;
public class IncidenciaController : BaseApiController
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;

    public IncidenciaController(IUnitOfWork _unitOfWork, IMapper mapper)
    {
        unitOfWork = _unitOfWork;
        this.mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<List<IncidenciasDTO>> Get()
    {
        var incidencias = await unitOfWork.Incidencias.GetAllAsync();
        return this.mapper.Map<List<IncidenciasDTO>>(incidencias);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IncidenciasDTO>> Get(int id)
    {
        var incidencia = await unitOfWork.Incidencias.GetByIdAsync(id);
        if (incidencia == null)
        {
            return NotFound();
        }
        return this.mapper.Map<IncidenciasDTO>(incidencia);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IncidenciasDTO>> Post(IncidenciaPostDTO incidenciaCreacion)
    {
        var incidencia = mapper.Map<Incidencia>(incidenciaCreacion);
        this.unitOfWork.Incidencias.Add(incidencia);
        await unitOfWork.SaveAsync();
        if (incidencia == null)
        {
            return BadRequest();
        }
        return this.mapper.Map<IncidenciasDTO>(incidencia);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IncidenciasDTO>> Put(int id, [FromBody] IncidenciasDTO incidenciaEdicion)
    {
        var incidencia = mapper.Map<Incidencia>(incidenciaEdicion);
        if (incidencia == null)
        {
            return NotFound();
        }
        unitOfWork.Incidencias.Update(incidencia);
        await unitOfWork.SaveAsync();
        return this.mapper.Map<IncidenciasDTO>(incidencia);

    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var incidencia = await unitOfWork.Incidencias.GetByIdAsync(id);
        if (incidencia == null)
        {
            return NotFound();
        }
        unitOfWork.Incidencias.Remove(incidencia);
        await unitOfWork.SaveAsync();
        return NoContent();
    }
}