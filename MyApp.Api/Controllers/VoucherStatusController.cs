﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyApp.Api.IServices;
using MyApp.Shared.Models;

namespace MyApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VoucherStatusController : ControllerBase
    {
        private readonly IVoucherStatusService _voucherStatusService;
        public VoucherStatusController(IVoucherStatusService voucherStatusService)
        {
            _voucherStatusService = voucherStatusService;
        }
        [HttpGet("getall")]
        public async Task<IActionResult> GetAlll()
        {

            var pro = await _voucherStatusService.GetAllItems();
            return Ok(pro);
        }
        [HttpGet("get/{id}")]
        public async Task<ActionResult<VoucherStatusModel>> Get(Guid id)
        {
            try
            {
                return Ok(await _voucherStatusService.GetItem(id));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, "Không lấy được dữ liệu");
            }
        }
        [HttpPost("create")]
        public async Task<ActionResult<VoucherStatusModel>> Post([FromBody] VoucherStatusModel model)
        {
            var result = await _voucherStatusService.AddItem(model);
            if (result.IsSuccess)
            {
                return Ok("Đã thêm thành công");
            }
            return Ok("Lỗi!");
        }

        [HttpPut("update/{id}")]
        public async Task<ActionResult<VoucherStatusModel>> Put(VoucherStatusModel model)
        {
            var result = await _voucherStatusService.UpdateItem(model);
            if (result.IsSuccess)
            {
                return Ok("Đã sửa thành công");
            }
            return Ok("Lỗi!");
        }
        [HttpDelete("delete/{id}")]
        public async Task<ActionResult<VoucherStatusModel>> Delete(Guid id)
        {
            var result = await _voucherStatusService.DeleteItem(id);
            if (result.IsSuccess)
            {
                return Ok("Đã xoá thành công");
            }
            return Ok("Lỗi!");
        }
    }
}
