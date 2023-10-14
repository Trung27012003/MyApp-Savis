using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyApp.Api.IServices;
using MyApp.Api.Services;
using MyApp.Shared.Models;

namespace MyApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartService _cartService;
        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }
        [HttpGet("getall")]
        public async Task<IActionResult> GetAlll()
        {

            var pro = await _cartService.GetAllItems();
            return Ok(pro);
        }
        [HttpGet("get/{id}")]
        public async Task<ActionResult<CartModel>> Get(Guid id)
        {
            try
            {
                return Ok(await _cartService.GetItem(id));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, "Không lấy được dữ liệu");
            }
        }
        [HttpPost("create")]
        public async Task<ActionResult<CartModel>> Post([FromBody] CartModel model)
        {
            var result = await _cartService.AddItem(model);
            if (result.IsSuccess)
            {
                return Ok("Đã thêm thành công");
            }
            return Ok("Lỗi!");
        }

        [HttpPut("update/{id}")]
        public async Task<ActionResult<CartModel>> Put(CartModel model)
        {
            var result = await _cartService.UpdateItem(model);
            if (result.IsSuccess)
            {
                return Ok("Đã sửa thành công");
            }
            return Ok("Lỗi!");
        }
        [HttpDelete("delete/{id}")]
        public async Task<ActionResult<CartModel>> Delete(Guid id)
        {
            var result = await _cartService.DeleteItem(id);
            if (result.IsSuccess)
            {
                return Ok("Đã xoá thành công");
            }
            return Ok("Lỗi!");
        }
    }
}
