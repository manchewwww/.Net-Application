using Logger.Models;
using Logger.Services;
using Microsoft.AspNetCore.Mvc;

namespace Logger.Controllers;

[ApiController]
[Route("api/items")]
public sealed class ItemsController : ControllerBase
{
    private readonly ItemService _service;

    public ItemsController(ItemService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<List<Item>>> GetAllAsync()
    {
        var items = await _service.GetAllAsync();
        return Ok(items);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Item>> GetByIdAsync(string id)
    {
        var item = await _service.GetByIdAsync(id);
        if (item is null)
        {
            return NotFound();
        }

        return Ok(item);
    }

    [HttpPost]
    public async Task<ActionResult<Item>> CreateAsync(Item item)
    {
        await _service.CreateAsync(item);
        return CreatedAtAction(nameof(GetByIdAsync), new { id = item.Id }, item);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAsync(string id, Item item)
    {
        item.Id = id;
        await _service.UpdateAsync(id, item);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(string id)
    {
        await _service.DeleteAsync(id);
        return NoContent();
    }
}
