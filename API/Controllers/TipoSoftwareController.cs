using API.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace API.Controllers;
public class TipoSoftwareController : BaseApiController
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;

    public TipoSoftwareController(IUnitOfWork _unitOfWork, IMapper mapper)
    {
        unitOfWork = _unitOfWork;
        this.mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<List<TipoSoftwaresDTO>> Get()
    {
        var tiposSoftwares = await unitOfWork.TiposSoftwares.GetAllAsync();
        return this.mapper.Map<List<TipoSoftwaresDTO>>(tiposSoftwares);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<TipoSoftwareDTO>> Get(int id)
    {
        var tipoSoftware = await unitOfWork.TiposSoftwares.GetByIdAsync(id);
        if(tipoSoftware == null){
            return NotFound();
        }
        return this.mapper.Map<TipoSoftwareDTO>(tipoSoftware);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<TipoSoftwaresDTO>> Post(TipoSoftwarePostDTO tipoSoftwareCreacion)
    {
        var tipoSoftware = mapper.Map<TipoSoftware>(tipoSoftwareCreacion);
        this.unitOfWork.TiposSoftwares.Add(tipoSoftware);
        await unitOfWork.SaveAsync();
        if (tipoSoftware == null)
        {
            return BadRequest();
        }
        return this.mapper.Map<TipoSoftwaresDTO>(tipoSoftware); 
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<TipoSoftwaresDTO>> Put(int id, [FromBody] TipoSoftwaresDTO tipoSoftwareEdicion)
    {
        var tipoSoftware = mapper.Map<TipoSoftware>(tipoSoftwareEdicion);
        if (tipoSoftware == null)
        {
            return NotFound();
        }
        unitOfWork.TiposSoftwares.Update(tipoSoftware);
        await unitOfWork.SaveAsync();
        return this.mapper.Map<TipoSoftwaresDTO>(tipoSoftware);

    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var tipoSoftware = await unitOfWork.TiposSoftwares.GetByIdAsync(id);
        if (tipoSoftware == null)
        {
            return NotFound();
        }
        unitOfWork.TiposSoftwares.Remove(tipoSoftware);
        await unitOfWork.SaveAsync();
        return NoContent();
    }
}