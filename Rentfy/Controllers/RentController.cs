﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rentfy.Application.DTO;
using Rentfy.Application.Interfaces;
using System;
using System.Threading.Tasks;

namespace Rentfy.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentController : BaseApiController
    {
        private readonly IRentAppService _rentAppService;

        public RentController(IRentAppService rentAppService)
        {
            _rentAppService = rentAppService ?? throw new ArgumentNullException(nameof(rentAppService));
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Route("{id}")]
        public async Task<IActionResult> GetRent(long id)
        {
            var result = await _rentAppService.GetRentById(id);

            return ResultRequest(result);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateRent(RentDto rentDto)
        {
            var result = await _rentAppService.CreateRent(rentDto);

            return ResultRequest(result);
        }

        [HttpPatch("cancel/{rentId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CancelRent(long rentId)
        {
            var result = await _rentAppService.CancelRent(rentId);

            return ResultRequest(result);
        }

        [HttpPatch("start/{rentId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> StartRent(long rentId)
        {
            var result = await _rentAppService.StartRent(rentId);

            return ResultRequest(result);
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteRent(long id)
        {
            var result = await _rentAppService.DeleteRentById(id);

            return ResultRequest(result);
        }
    }
}