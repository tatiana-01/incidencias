using API.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;
public class SoftwareController : BaseApiController
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;

    public SoftwareController(IUnitOfWork _unitOfWork, IMapper mapper)
    {
        unitOfWork = _unitOfWork;
        this.mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<List<SoftwaresDTO>> Get()
    {
        var softwares = await unitOfWork.Softwares.GetAllAsync();
        return this.mapper.Map<List<SoftwaresDTO>>(softwares);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<SoftwaresDTO>> Get(int id)
    {
        var software = await unitOfWork.Softwares.GetByIdAsync(id);
        if (software == null)
        {
            return NotFound();
        }
        return this.mapper.Map<SoftwaresDTO>(software);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<SoftwaresDTO>> Post(SoftwarePostDTO softwareCreacion)
    {
        var software = mapper.Map<Software>(softwareCreacion);
        this.unitOfWork.Softwares.Add(software);
        await unitOfWork.SaveAsync();
        if (software == null)
        {
            return BadRequest();
        }
        return this.mapper.Map<SoftwaresDTO>(software);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<SoftwaresDTO>> Put(int id, [FromBody] SoftwaresDTO softwareEdicion)
    {
        var software = mapper.Map<Software>(softwareEdicion);
        if (software == null)
        {
            return NotFound();
        }
        unitOfWork.Softwares.Update(software);
        await unitOfWork.SaveAsync();
        return this.mapper.Map<SoftwaresDTO>(software);

    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var software = await unitOfWork.Softwares.GetByIdAsync(id);
        if (software == null)
        {
            return NotFound();
        }
        unitOfWork.Softwares.Remove(software);
        await unitOfWork.SaveAsync();
        return NoContent();
    }
}