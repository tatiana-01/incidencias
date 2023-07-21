using API.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace API.Controllers;
public class TipoHardwareController : BaseApiController
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;

    public TipoHardwareController(IUnitOfWork _unitOfWork, IMapper mapper)
    {
        unitOfWork = _unitOfWork;
        this.mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<List<TipoHardwaresDTO>> Get()
    {
        var tiposHardwares = await unitOfWork.TiposHardwares.GetAllAsync();
        return this.mapper.Map<List<TipoHardwaresDTO>>(tiposHardwares);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<TipoHardwareDTO>> Get(int id)
    {
        var tipoHardware = await unitOfWork.TiposHardwares.GetByIdAsync(id);
        if(tipoHardware == null){
            return NotFound();
        }
        return this.mapper.Map<TipoHardwareDTO>(tipoHardware);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<TipoHardwaresDTO>> Post(TipoHardwarePostDTO tipoHardwareCreacion)
    {
        var tipoHardware = mapper.Map<TipoHardware>(tipoHardwareCreacion);
        this.unitOfWork.TiposHardwares.Add(tipoHardware);
        await unitOfWork.SaveAsync();
        if (tipoHardware == null)
        {
            return BadRequest();
        }
        return this.mapper.Map<TipoHardwaresDTO>(tipoHardware); 
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<TipoHardwaresDTO>> Put(int id, [FromBody] TipoHardwaresDTO tipoHardwareEdicion)
    {
        var tipoHardware = mapper.Map<TipoHardware>(tipoHardwareEdicion);
        if (tipoHardware == null)
        {
            return NotFound();
        }
        unitOfWork.TiposHardwares.Update(tipoHardware);
        await unitOfWork.SaveAsync();
        return this.mapper.Map<TipoHardwaresDTO>(tipoHardware);

    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var tipoHardware = await unitOfWork.TiposHardwares.GetByIdAsync(id);
        if (tipoHardware == null)
        {
            return NotFound();
        }
        unitOfWork.TiposHardwares.Remove(tipoHardware);
        await unitOfWork.SaveAsync();
        return NoContent();
    }
}