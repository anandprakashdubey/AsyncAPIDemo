using AsyncAPIDemo.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncAPIDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        public IBookRepository BookRepository { get; }
        public BookController(IBookRepository BookRepository)
        {
            this.BookRepository = BookRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetBooks()
        {
            var data = await this.BookRepository.GetBooksAsync();
            return Ok(data);
        }

    }
}
