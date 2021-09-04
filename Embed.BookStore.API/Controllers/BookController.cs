using AutoMapper;
using Embed.BookStore.API.Services.BookService;
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
    public class BookController : ControllerBase
    {
        private readonly ILogger<BookController> _logger;
        private readonly IMapper _mapper;
        private readonly IBookService _bookService;
        public BookController(IBookService bookService, ILogger<BookController> logger, IMapper mapper)
        {
            this._logger = logger;
            this._mapper = mapper;
            this._bookService = bookService;

        }

        /// <summary>
        /// API to get list of available books
        /// </summary>
        /// <returns></returns>
        [HttpGet("summary")]
        public async Task<IActionResult> GetBooksSummary()
        {
            return Ok(await _bookService.GetBooksSummary(""));
        }

        /// <summary>
        /// API to search and return list of search books
        /// </summary>
        /// <param name="keyword"></param>
        /// <returns></returns>
        [HttpGet("summary/{keyword}")]
        public async Task<IActionResult> GetBooksSummary(string keyword)
        {
            return Ok(await _bookService.GetBooksSummary(keyword));
        }

        /// <summary>
        /// API to return detail of book
        /// </summary>
        /// <param name="ISBNCode"></param>
        /// <returns></returns>
        [HttpGet("detail/{ISBNCode}")]
        public async Task<IActionResult> GetBookDetail(string ISBNCode)
        {
            return Ok(await _bookService.GetBookDetail(ISBNCode));
        }
    }
}
