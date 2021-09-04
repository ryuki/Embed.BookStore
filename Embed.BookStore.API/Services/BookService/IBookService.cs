using Embed.BookStore.API.Dtos.Book;
using Embed.BookStore.API.Dtos.Store;
using Embed.BookStore.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Embed.BookStore.API.Services.BookService
{
    public interface IBookService
    {
        Task<ServiceResponse<List<GetBookSummaryDto>>> GetBooksSummary(string keyword);


        Task<ServiceResponse<GetBookDetailDto>> GetBookDetail(string ISBNCode);

    }
}
