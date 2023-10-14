using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyApp.Api.IServices;
using MyApp.Shared.Models;

namespace MyApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VoucherProductController : ControllerBase
    {
        private readonly IVoucherProductService _voucherProductService;
        public VoucherProductController(IVoucherProductService voucherProductService)
        {
            _voucherProductService = voucherProductService;
        }
        [HttpGet("getall")]
        public async Task<IActionResult> GetAlll()
        {

            var pro = await _voucherProductService.GetAllItems();
            return Ok(pro);
        }
        [HttpGet("get/{id}")]
        public async Task<ActionResult<VoucherProductModel>> Get(Guid id)
        {
            try
            {
                return Ok(await _voucherProductService.GetItem(id));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, "Không lấy được dữ liệu");
            }
        }
        [HttpPost("create")]
        public async Task<ActionResult<VoucherProductModel>> Post([FromBody] VoucherProductModel model)
        {
            var result = await _voucherProductService.AddItem(model);
            if (result.IsSuccess)
            {
                return Ok("Đã thêm thành công");
            }
            return Ok("Lỗi!");
        }

        [HttpPut("update/{id}")]
        public async Task<ActionResult<VoucherProductModel>> Put(VoucherProductModel model)
        {
            var result = await _voucherProductService.UpdateItem(model);
            if (result.IsSuccess)
            {
                return Ok("Đã sửa thành công");
            }
            return Ok("Lỗi!");
        }
        [HttpDelete("delete/{id}")]
        public async Task<ActionResult<VoucherProductModel>> Delete(Guid id)
        {
            var result = await _voucherProductService.DeleteItem(id);
            if (result.IsSuccess)
            {
                return Ok("Đã xoá thành công");
            }
            return Ok("Lỗi!");
        }
    }
}
