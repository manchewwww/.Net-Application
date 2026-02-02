using AutoPartsShop.Dtos;
using AutoPartsShop.Services;
using Microsoft.AspNetCore.Mvc;

namespace AutoPartsShop.Controllers
{
    [ApiController]
    [Route("api/importjobs")]
    public class ImportJobController : ControllerBase
    {
        private readonly IImportJobService _service;

        public ImportJobController(IImportJobService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<ActionResult<ImportJobResponse>> AddImportJobAsync([FromBody] ImportJobCreateRequest request)
        {
            var created = await _service.AddImportJobAsync(request);
            if (created == null)
            {
                return BadRequest();
            }
            return Ok(created);
        }

        [HttpGet]
        public async Task<IEnumerable<ImportJobResponse>> GetAllImportJobsAsync()
        {
            return await _service.GetAllImportJobsAsync();
        }

        [HttpGet("{id:long}")]
        public async Task<ActionResult<ImportJobResponse?>> GetImportJobByIdAsync(long id)
        {
            var entity = await _service.GetImportJobByIdAsync(id);
            return Ok(entity);
        }

        [HttpPut("{id:long}")]
        public async Task<ActionResult> UpdateImportJobAsync(long id, [FromBody] ImportJobUpdateRequest request)
        {
            var updated = await _service.UpdateImportJobAsync(id, request);
            return Ok(updated);
        }

        [HttpDelete("{id:long}")]
        public async Task<ActionResult<ImportJobResponse>> DeleteImportJobAsync(long id)
        {
            await _service.DeleteImportJobAsync(id);
            return Ok();
        }
    }
}
