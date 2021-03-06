using AsyncAPIDemo.Context;
using AsyncAPIDemo.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncAPIDemo.Services
{
    public class BookRepository : IBookRepository, IDisposable
    {
        public BookContext Context { get; }
        public BookRepository(BookContext Context)
        {
            this.Context = Context;
        }

        public async Task<Book> GetBookAsync(Guid Id)
        {
            return await Context.Books
                .Include(b => b.Author)
                .FirstOrDefaultAsync(item => item.Id == Id);
        }

        public async Task<IEnumerable<Book>> GetBooksAsync()
        {
            return await Context.Books.Include(b => b.Author).ToListAsync();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (Context != null)
                {
                    Context.Dispose();
                }
            }

        }
    }
}
