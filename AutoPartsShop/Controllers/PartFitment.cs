using AutoPartsShop.Dtos;
using AutoPartsShop.Services;
using Microsoft.AspNetCore.Mvc;

namespace AutoPartsShop.Controllers
{
    [ApiController]
    [Route("api/partfitments")]
    public class PartFitmentController : ControllerBase
    {
        private readonly IPartFitmentService _service;

        public PartFitmentController(IPartFitmentService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<ActionResult<PartFitmentResponse>> AddPartFitmentAsync([FromBody] PartFitmentCreateRequest request)
        {
            var created = await _service.AddPartFitmentAsync(request);
            if (created == null)
            {
                return BadRequest();
            }
            return Ok(created);
        }

        [HttpGet]
        public async Task<IEnumerable<PartFitmentResponse>> GetAllPartFitmentsAsync()
        {
            return await _service.GetAllPartFitmentsAsync();
        }

        [HttpGet("{id:long}")]
        public async Task<ActionResult<PartFitmentResponse?>> GetPartFitmentByIdAsync(long id)
        {
            var entity = await _service.GetPartFitmentByIdAsync(id);
            return Ok(entity);
        }

        [HttpPut("{id:long}")]
        public async Task<ActionResult> UpdatePartFitmentAsync(long id, [FromBody] PartFitmentUpdateRequest request)
        {
            var updated = await _service.UpdatePartFitmentAsync(id, request);
            return Ok(updated);
        }

        [HttpDelete("{id:long}")]
        public async Task<ActionResult<PartFitmentResponse>> DeletePartFitmentAsync(long id)
        {
            await _service.DeletePartFitmentAsync(id);
            return Ok();
        }
    }
}
