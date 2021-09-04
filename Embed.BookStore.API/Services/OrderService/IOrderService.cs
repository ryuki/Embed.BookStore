using Embed.BookStore.API.Dtos.Order;
using Embed.BookStore.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Embed.BookStore.API.Services.OrderService
{
    public interface IOrderService
    {
        Task<ServiceResponse<GetOrderDto>> OrderBook(SetOrderDto order);
    }
}
