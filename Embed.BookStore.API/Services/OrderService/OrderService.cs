using AutoMapper;
using Embed.BookStore.API.Dtos.Order;
using Embed.BookStore.API.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace Embed.BookStore.API.Services.OrderService
{
    public class OrderService : IOrderService
    {
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        public OrderService(IMapper mapper, IConfiguration configuration)
        {
            this._mapper = mapper;
            this._configuration = configuration;
        }

        public async Task<ServiceResponse<GetOrderDto>> OrderBook(SetOrderDto order)
        {
            ServiceResponse<GetOrderDto> orderResponse = new ServiceResponse<GetOrderDto>();

            string newOrderId = Guid.NewGuid().ToString();
            string fileName = string.Format("{0}order-{1}.json", _configuration.GetValue<string>("SourceDirectory") , newOrderId);

            // upload order file to directory
            string jsonString = JsonSerializer.Serialize(order);
            File.WriteAllText(fileName, jsonString);

            GetOrderDto ord = new GetOrderDto();
            ord.storeId = order.storeId;
            ord.ISBNCode = order.ISBNCode;
            ord.contactEmail = order.contactEmail;

            orderResponse.Data = ord;
            orderResponse.Message = "order";
            return orderResponse;
        }
    }
}
