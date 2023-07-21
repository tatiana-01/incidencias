using API.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;
public class HardwareController : BaseApiController
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;

    public HardwareController(IUnitOfWork _unitOfWork, IMapper mapper)
    {
        unitOfWork = _unitOfWork;
        this.mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<List<HardwaresDTO>> Get()
    {
        var hardwares = await unitOfWork.Hardwares.GetAllAsync();
        return this.mapper.Map<List<HardwaresDTO>>(hardwares);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<HardwaresDTO>> Get(int id)
    {
        var hardware = await unitOfWork.Hardwares.GetByIdAsync(id);
        if (hardware == null)
        {
            return NotFound();
        }
        return this.mapper.Map<HardwaresDTO>(hardware);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<HardwaresDTO>> Post(HardwarePostDTO hardwareCreacion)
    {
        var hardware = mapper.Map<Hardware>(hardwareCreacion);
        this.unitOfWork.Hardwares.Add(hardware);
        await unitOfWork.SaveAsync();
        if (hardware == null)
        {
            return BadRequest();
        }
        return this.mapper.Map<HardwaresDTO>(hardware);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<HardwaresDTO>> Put(int id, [FromBody] HardwaresDTO hardwareEdicion)
    {
        var hardware = mapper.Map<Hardware>(hardwareEdicion);
        if (hardware == null)
        {
            return NotFound();
        }
        unitOfWork.Hardwares.Update(hardware);
        await unitOfWork.SaveAsync();
        return this.mapper.Map<HardwaresDTO>(hardware);

    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var hardware = await unitOfWork.Hardwares.GetByIdAsync(id);
        if (hardware == null)
        {
            return NotFound();
        }
        unitOfWork.Hardwares.Remove(hardware);
        await unitOfWork.SaveAsync();
        return NoContent();
    }
}
