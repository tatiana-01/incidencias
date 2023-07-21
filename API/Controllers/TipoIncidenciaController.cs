using API.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace API.Controllers;
public class TipoIncidenciaController : BaseApiController
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;

    public TipoIncidenciaController(IUnitOfWork _unitOfWork, IMapper mapper)
    {
        unitOfWork = _unitOfWork;
        this.mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<List<TipoIncidenciasDTO>> Get()
    {
        var tiposIncidencias = await unitOfWork.TiposIncidencias.GetAllAsync();
        return this.mapper.Map<List<TipoIncidenciasDTO>>(tiposIncidencias);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<TipoIncidenciaDTO>> Get(int id)
    {
        var tipoIncidencia = await unitOfWork.TiposIncidencias.GetByIdAsync(id);
        if(tipoIncidencia == null){
            return NotFound();
        }
        return this.mapper.Map<TipoIncidenciaDTO>(tipoIncidencia);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<TipoIncidenciasDTO>> Post(TipoIncidenciaPostDTO tipoIncidenciaCreacion)
    {
        var tipoIncidencia = mapper.Map<TipoIncidencia>(tipoIncidenciaCreacion);
        this.unitOfWork.TiposIncidencias.Add(tipoIncidencia);
        await unitOfWork.SaveAsync();
        if (tipoIncidencia == null)
        {
            return BadRequest();
        }
        return this.mapper.Map<TipoIncidenciasDTO>(tipoIncidencia); 
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<TipoIncidenciasDTO>> Put(int id, [FromBody] TipoIncidenciasDTO tipoIncidenciaEdicion)
    {
        var tipoIncidencia = mapper.Map<TipoIncidencia>(tipoIncidenciaEdicion);
        if (tipoIncidencia == null)
        {
            return NotFound();
        }
        unitOfWork.TiposIncidencias.Update(tipoIncidencia);
        await unitOfWork.SaveAsync();
        return this.mapper.Map<TipoIncidenciasDTO>(tipoIncidencia);

    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var tipoIncidencia = await unitOfWork.TiposIncidencias.GetByIdAsync(id);
        if (tipoIncidencia == null)
        {
            return NotFound();
        }
        unitOfWork.TiposIncidencias.Remove(tipoIncidencia);
        await unitOfWork.SaveAsync();
        return NoContent();
    }
}