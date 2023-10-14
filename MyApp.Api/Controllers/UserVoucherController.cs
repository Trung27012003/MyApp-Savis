using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyApp.Api.IServices;
using MyApp.Api.Services;
using MyApp.Shared.Models;

namespace MyApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserVoucherController : ControllerBase
    {
        private readonly IUserVoucherService _userVoucherService;
        public UserVoucherController(IUserVoucherService userVoucherService)
        {
            _userVoucherService = userVoucherService;
        }
        [HttpGet("getall")]
        public async Task<IActionResult> GetAlll()
        {

            var pro = await _userVoucherService.GetAllItems();
            return Ok(pro);
        }
        [HttpGet("get/{id}")]
        public async Task<ActionResult<UserVoucherModel>> Get(Guid id)
        {
            try
            {
                return Ok(await _userVoucherService.GetItem(id));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, "Không lấy được dữ liệu");
            }
        }
        [HttpPost("create")]
        public async Task<ActionResult<UserVoucherModel>> Post([FromBody] UserVoucherModel model)
        {
            var result = await _userVoucherService.AddItem(model);
            if (result.IsSuccess)
            {
                return Ok("Đã thêm thành công");
            }
            return Ok("Lỗi!");
        }

        [HttpPut("update/{id}")]
        public async Task<ActionResult<UserVoucherModel>> Put(UserVoucherModel model)
        {
            var result = await _userVoucherService.UpdateItem(model);
            if (result.IsSuccess)
            {
                return Ok("Đã sửa thành công");
            }
            return Ok("Lỗi!");
        }
        [HttpDelete("delete/{id}")]
        public async Task<ActionResult<UserVoucherModel>> Delete(Guid id)
        {
            var result = await _userVoucherService.DeleteItem(id);
            if (result.IsSuccess)
            {
                return Ok("Đã xoá thành công");
            }
            return Ok("Lỗi!");
        }
    }
}
