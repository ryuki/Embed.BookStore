using AutoMapper;
using Embed.BookStore.API.Dtos.Order;
using Embed.BookStore.API.Services.OrderService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Embed.BookStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class OrderController : ControllerBase
    {

        private readonly ILogger<OrderController> _logger;
        private readonly IMapper _mapper;
        private readonly IOrderService _orderService;
        public OrderController(IOrderService orderService, ILogger<OrderController> logger, IMapper mapper)
        {
            this._logger = logger;
            this._mapper = mapper;
            this._orderService = orderService;

        }

        /// <summary>
        /// API to order book
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> OrderBook(SetOrderDto order)
        {
            return Ok(await _orderService.OrderBook(order));
        }
    }
}
