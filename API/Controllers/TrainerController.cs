using API.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace API.Controllers;
public class TrainerController : BaseApiController
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;

    public TrainerController(IUnitOfWork _unitOfWork, IMapper mapper)
    {
        unitOfWork = _unitOfWork;
        this.mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<List<TrainersDTO>> Get()
    {
        var trainers = await unitOfWork.Trainers.GetAllAsync();
        return this.mapper.Map<List<TrainersDTO>>(trainers);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<TrainerDTO>> Get(string id)
    {
        var trainer = await unitOfWork.Trainers.GetByIdAsync(id);
        if(trainer == null){
            return NotFound();
        }
        return this.mapper.Map<TrainerDTO>(trainer);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<TrainersDTO>> Post(TrainerPostDTO trainerCreacion)
    {
        var trainer = mapper.Map<Trainer>(trainerCreacion);
        this.unitOfWork.Trainers.Add(trainer);
        await unitOfWork.SaveAsync();
        if (trainer == null)
        {
            return BadRequest();
        }
        return this.mapper.Map<TrainersDTO>(trainer); 
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<TrainersDTO>> Put(int id, [FromBody] TrainersDTO trainerEdicion)
    {
        var trainer = mapper.Map<Trainer>(trainerEdicion);
        if (trainer == null)
        {
            return NotFound();
        }
        unitOfWork.Trainers.Update(trainer);
        await unitOfWork.SaveAsync();
        return this.mapper.Map<TrainersDTO>(trainer);

    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(string id)
    {
        var trainer = await unitOfWork.Trainers.GetByIdAsync(id);
        if (trainer == null)
        {
            return NotFound();
        }
        unitOfWork.Trainers.Remove(trainer);
        await unitOfWork.SaveAsync();
        return NoContent();
    }
}