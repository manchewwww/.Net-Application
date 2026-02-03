using AutoPartsShop.Dtos;
using AutoPartsShop.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace AutoPartsShop.Controllers
{
    [ApiController]
    [Route("api/payments")]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService _service;

        public PaymentController(IPaymentService service)
        {
            _service = service;
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<ActionResult<PaymentResponse>> AddPaymentAsync([FromBody] PaymentCreateRequest request)
        {
            var created = await _service.AddPaymentAsync(request);
            if (created == null)
            {
                return BadRequest();
            }
            return Ok(created);
        }

        [HttpGet]
        public async Task<IEnumerable<PaymentResponse>> GetAllPaymentsAsync()
        {
            return await _service.GetAllPaymentsAsync();
        }

        [HttpGet("{id:long}")]
        public async Task<ActionResult<PaymentResponse?>> GetPaymentByIdAsync(long id)
        {
            var entity = await _service.GetPaymentByIdAsync(id);
            return Ok(entity);
        }
        [Authorize(Roles = "Admin")]
        [HttpPut("{id:long}")]
        public async Task<ActionResult> UpdatePaymentAsync(long id, [FromBody] PaymentUpdateRequest request)
        {
            var updated = await _service.UpdatePaymentAsync(id, request);
            return Ok(updated);
        }
        [Authorize(Roles = "Admin")]
        [HttpDelete("{id:long}")]
        public async Task<ActionResult<PaymentResponse>> DeletePaymentAsync(long id)
        {
            await _service.DeletePaymentAsync(id);
            return Ok();
        }
    }
}
