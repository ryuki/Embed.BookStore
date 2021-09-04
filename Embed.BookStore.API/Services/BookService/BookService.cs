using AutoMapper;
using Embed.BookStore.API.Dtos.Book;
using Embed.BookStore.API.Dtos.Store;
using Embed.BookStore.API.Models;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Embed.BookStore.API.Services.BookService
{
    public class BookService : IBookService
    {
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        public BookService(IMapper mapper, IConfiguration configuration)
        {
            this._mapper = mapper;
            this._configuration = configuration;
        }
        /// <summary>
        /// Service to get detail book
        /// </summary>
        /// <param name="ISBNCode"></param>
        /// <returns></returns>
        public async Task<ServiceResponse<GetBookDetailDto>> GetBookDetail(string ISBNCode)
        {
            ServiceResponse<GetBookDetailDto> bookResponse = new ServiceResponse<GetBookDetailDto>();

            IList<GetStoreDto> listStore = new List<GetStoreDto>();
            GetStoreDto store;
            XmlSerializer serializer = new XmlSerializer(typeof(Store));
            string[] fileEntries = Directory.GetFiles(_configuration.GetValue<string>("SourceDirectory"), "*.xml", SearchOption.TopDirectoryOnly);
            foreach (string fileName in fileEntries)
            {
                store = _mapper.Map<GetStoreDto>((Store)serializer.Deserialize(new StreamReader(fileName)));
                listStore.Add(store);
            }

            // get list book in store
            var queryBookInStores = from s in listStore
                        from b in s.books
                        where b.ISBNCode == ISBNCode
                        group b by (b.ISBNCode, b.bookName, b.author, s, b.price, b.stock) into t
                        select new GetBookInStoreDto
                        {
                            store = new GetStoreInfoDto()
                            {
                                storeId = t.Key.s.storeId,
                                storeName = t.Key.s.storeName
                            },
                            price = t.Key.price,
                            stock = t.Key.stock
                        };

            // get list book
            var queryBook = from s in listStore
                            from b in s.books
                            where b.ISBNCode == ISBNCode
                            select new GetBookDetailDto
                            {
                                ISBNCode = b.ISBNCode,
                                bookName = b.bookName,
                                author = b.author
                            };


            GetBookDetailDto result = queryBook.FirstOrDefault<GetBookDetailDto>();
            List<GetBookInStoreDto> bookInStores = queryBookInStores.ToList<GetBookInStoreDto>();

            result.bookInStores = bookInStores;
            bookResponse.Data = result;
            bookResponse.Message = "store";
            return bookResponse;
        }

        /// <summary>
        /// Service to return all of available books
        /// </summary>
        /// <param name="keyword"></param>
        /// <returns></returns>
        public async Task<ServiceResponse<List<GetBookSummaryDto>>> GetBooksSummary(string keyword)
        {
            ServiceResponse<List<GetBookSummaryDto>> bookResponse = new ServiceResponse<List<GetBookSummaryDto>>();

            IList<GetStoreDto> listStore = new List<GetStoreDto>();
            GetStoreDto store;
            XmlSerializer serializer = new XmlSerializer(typeof(Store));
            // scan all file in specific directory
            string[] fileEntries = Directory.GetFiles(_configuration.GetValue<string>("SourceDirectory"), "*.xml", SearchOption.TopDirectoryOnly);
            foreach (string fileName in fileEntries)
            {
                Console.Write("fileName = " + fileName);
                store = _mapper.Map<GetStoreDto>((Store)serializer.Deserialize(new StreamReader(fileName)));
                listStore.Add(store);
            }

            //calculate the store to get min price, max price and total stock
            var query = from s in listStore
                        from b in s.books
                        where b.bookName.Contains(keyword, StringComparison.CurrentCultureIgnoreCase) ||
                        b.author.Contains(keyword, StringComparison.CurrentCultureIgnoreCase) ||
                        b.ISBNCode.Contains(keyword, StringComparison.CurrentCultureIgnoreCase)
                        group b by (b.ISBNCode, b.bookName, b.author) into t
                        select new GetBookSummaryDto { ISBNCode = t.Key.ISBNCode, bookName = t.Key.bookName, author = t.Key.author, priceMin = t.Min(b => b.price), priceMax = t.Max(b => b.price), totalStock = t.Sum(b => b.stock) };

            bookResponse.Data = query.ToList<GetBookSummaryDto>();
            bookResponse.Message = "store";
            return bookResponse;
        }
    }
}
