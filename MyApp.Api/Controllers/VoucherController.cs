using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyApp.Api.IServices;
using MyApp.Shared.Models;

namespace MyApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VoucherController : ControllerBase
    {
        private readonly IVoucherService _voucherService;
        public VoucherController(IVoucherService voucherService)
        {
            _voucherService = voucherService;
        }
        [HttpGet("getall")]
        public async Task<IActionResult> GetAlll()
        {

            var pro = await _voucherService.GetAllItems();
            return Ok(pro);
        }
        [HttpGet("get/{id}")]
        public async Task<ActionResult<VoucherModel>> Get(Guid id)
        {
            try
            {
                return Ok(await _voucherService.GetItem(id));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, "Không lấy được dữ liệu");
            }
        }
        [HttpPost("create")]
        public async Task<ActionResult<VoucherModel>> Post([FromBody] VoucherModel model)
        {
            var result = await _voucherService.AddItem(model);
            if (result.IsSuccess)
            {
                return Ok("Đã thêm thành công");
            }
            return Ok("Lỗi!");
        }

        [HttpPut("update/{id}")]
        public async Task<ActionResult<VoucherModel>> Put(VoucherModel model)
        {
            var result = await _voucherService.UpdateItem(model);
            if (result.IsSuccess)
            {
                return Ok("Đã sửa thành công");
            }
            return Ok("Lỗi!");
        }
        [HttpDelete("delete/{id}")]
        public async Task<ActionResult<VoucherModel>> Delete(Guid id)
        {
            var result = await _voucherService.DeleteItem(id);
            if (result.IsSuccess)
            {
                return Ok("Đã xoá thành công");
            }
            return Ok("Lỗi!");
        }
    }
}
