using AutoMapper;
using Embed.BookStore.API.Dtos.Book;
using Embed.BookStore.API.Dtos.Order;
using Embed.BookStore.API.Dtos.Store;
using Embed.BookStore.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Embed.BookStore.API
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Book, GetBookDto>();
            CreateMap<Store, GetStoreDto>();
            CreateMap<Order, SetOrderDto>();
        }
    }
}
