using API.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace API.Controllers;


public class CategoriaController : BaseApiController
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;

    public CategoriaController(IUnitOfWork _unitOfWork, IMapper mapper)
    {
        unitOfWork = _unitOfWork;
        this.mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<List<CategoriasDTO>> Get()
    {
        var categorias = await unitOfWork.Categorias.GetAllAsync();
        return this.mapper.Map<List<CategoriasDTO>>(categorias);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<CategoriaDTO>> Get(int id)
    {
        var categoria = await unitOfWork.Categorias.GetByIdAsync(id);
        if(categoria == null){
            return NotFound();
        }
        return this.mapper.Map<CategoriaDTO>(categoria);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<CategoriasDTO>> Post(CategoriaPostDTO categoriaCreacion)
    {
        var categoria = mapper.Map<Categoria>(categoriaCreacion);
        this.unitOfWork.Categorias.Add(categoria);
        await unitOfWork.SaveAsync();
        if (categoria == null)
        {
            return BadRequest();
        }
        return this.mapper.Map<CategoriasDTO>(categoria); 
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<CategoriasDTO>> Put(int id, [FromBody] CategoriasDTO categoriaEdicion)
    {
        var categoria = mapper.Map<Categoria>(categoriaEdicion);
        if (categoria == null)
        {
            return NotFound();
        }
        unitOfWork.Categorias.Update(categoria);
        await unitOfWork.SaveAsync();
        return this.mapper.Map<CategoriasDTO>(categoria);

    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var categoria = await unitOfWork.Categorias.GetByIdAsync(id);
        if (categoria == null)
        {
            return NotFound();
        }
        unitOfWork.Categorias.Remove(categoria);
        await unitOfWork.SaveAsync();
        return NoContent();
    }
}