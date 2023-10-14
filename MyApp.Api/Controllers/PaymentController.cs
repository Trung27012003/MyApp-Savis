using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyApp.Api.IServices;
using MyApp.Shared.Models;

namespace MyApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService _paymentService;
        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }
        [HttpGet("getall")]
        public async Task<IActionResult> GetAlll()
        {

            var pro = await _paymentService.GetAllItems();
            return Ok(pro);
        }
        [HttpGet("get/{id}")]
        public async Task<ActionResult<PaymentModel>> Get(Guid id)
        {
            try
            {
                return Ok(await _paymentService.GetItem(id));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, "Không lấy được dữ liệu");
            }
        }
        [HttpPost("create")]
        public async Task<ActionResult<PaymentModel>> Post([FromBody] PaymentModel model)
        {
            var result = await _paymentService.AddItem(model);
            if (result.IsSuccess)
            {
                return Ok("Đã thêm thành công");
            }
            return Ok("Lỗi!");
        }

        [HttpPut("update/{id}")]
        public async Task<ActionResult<PaymentModel>> Put(PaymentModel model)
        {
            var result = await _paymentService.UpdateItem(model);
            if (result.IsSuccess)
            {
                return Ok("Đã sửa thành công");
            }
            return Ok("Lỗi!");
        }
        [HttpDelete("delete/{id}")]
        public async Task<ActionResult<PaymentModel>> Delete(Guid id)
        {
            var result = await _paymentService.DeleteItem(id);
            if (result.IsSuccess)
            {
                return Ok("Đã xoá thành công");
            }
            return Ok("Lỗi!");
        }
    }
}
