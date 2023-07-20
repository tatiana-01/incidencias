using API.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace API.Controllers;


public class SalonController : BaseApiController
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;

    public SalonController(IUnitOfWork _unitOfWork, IMapper mapper)
    {
        unitOfWork = _unitOfWork;
        this.mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<List<SalonesDTO>> Get()
    {
        var salones = await unitOfWork.Salones.GetAllAsync();
        return this.mapper.Map<List<SalonesDTO>>(salones);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<SalonDTO>> Get(int id)
    {
        var salon = await unitOfWork.Salones.GetByIdAsync(id);
        if(salon == null){
            return NotFound();
        }
        return this.mapper.Map<SalonDTO>(salon);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<SalonesDTO>> Post(SalonPostDTO salonCreacion)
    {
        var salon = mapper.Map<Salon>(salonCreacion);
        this.unitOfWork.Salones.Add(salon);
        await unitOfWork.SaveAsync();
        if (salon == null)
        {
            return BadRequest();
        }
        return this.mapper.Map<SalonesDTO>(salon);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<SalonesDTO>> Put(int id, [FromBody] SalonesDTO salonEdicion)
    {
        var salon = mapper.Map<Salon>(salonEdicion);
        if (salon == null)
        {
            return NotFound();
        }
        unitOfWork.Salones.Update(salon);
        await unitOfWork.SaveAsync();
        return this.mapper.Map<SalonesDTO>(salon);

    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var salon = await unitOfWork.Salones.GetByIdAsync(id);
        if (salon == null)
        {
            return NotFound();
        }
        unitOfWork.Salones.Remove(salon);
        await unitOfWork.SaveAsync();
        return NoContent();
    }
}
