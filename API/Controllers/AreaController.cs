using API.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace API.Controllers;


public class AreaController : BaseApiController
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;

    public AreaController(IUnitOfWork _unitOfWork, IMapper mapper)
    {
        unitOfWork = _unitOfWork;
        this.mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<List<AreasDTO>> Get()
    {
        var areas = await unitOfWork.Areas.GetAllAsync();
        return this.mapper.Map<List<AreasDTO>>(areas);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<AreaDTO>> Get(int id)
    {
        var area = await unitOfWork.Areas.GetByIdAsync(id);
        if(area == null){
            return NotFound();
        }
        return this.mapper.Map<AreaDTO>(area);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<AreasDTO>> Post(AreaPostDTO areaCreacion)
    {
        var area = mapper.Map<Area>(areaCreacion);
        this.unitOfWork.Areas.Add(area);
        await unitOfWork.SaveAsync();
        if (area == null)
        {
            return BadRequest();
        }
        return this.mapper.Map<AreasDTO>(area); 
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<AreasDTO>> Put(int id, [FromBody] AreasDTO areaEdicion)
    {
        var area = mapper.Map<Area>(areaEdicion);
        if (area == null)
        {
            return NotFound();
        }
        unitOfWork.Areas.Update(area);
        await unitOfWork.SaveAsync();
        return this.mapper.Map<AreasDTO>(area);

    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var area = await unitOfWork.Areas.GetByIdAsync(id);
        if (area == null)
        {
            return NotFound();
        }
        unitOfWork.Areas.Remove(area);
        await unitOfWork.SaveAsync();
        return NoContent();
    }
}
