using Microsoft.AspNetCore.Mvc;
using LoggerMetrics.Dtos;
using LoggerMetrics.Exceptions;
using LoggerMetrics.Services;

namespace LoggerMetrics.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PartsController : ControllerBase
{   
    private readonly IPartService _partService;

    public PartsController(IPartService partService)
    {
        _partService = partService;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Part>> Get()
       => Ok(_partService.Get());

    [HttpGet("{id:int}")]
    public ActionResult<Part> GetById(int id)
        => Ok(_partService.Get(id)); 

    [HttpPost]
    public ActionResult<Part> Create([FromBody] Part part)
    {
        var created = _partService.Create(part);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }
}