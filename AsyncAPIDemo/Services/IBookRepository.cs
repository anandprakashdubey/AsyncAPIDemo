using AsyncAPIDemo.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncAPIDemo.Services
{
    public interface IBookRepository
    {
        /*
         Example of Synchronous Implementation 

            IEnumerable<Book> GetBooks();
            Book GetBook(Guid Id);
        */

        Task<IEnumerable<Book>> GetBooksAsync();
        Task<Book> GetBookAsync(Guid Id);

    }
}
