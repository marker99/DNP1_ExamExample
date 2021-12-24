using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuthorAPI.Models;
using AuthorAPI.Persistence;
using Microsoft.EntityFrameworkCore;

namespace AuthorAPI.Data
{
    public class AuthorService : IAuthorService
    {
        private LibraryContext _libraryContext;

        public AuthorService(LibraryContext libraryContext)
        {
            _libraryContext = libraryContext;
        }
        
        public async Task<IList<Author>> GetAuthorsAsync()
        {
            return await _libraryContext.Authors.Include(a => a.Books).ToListAsync();
        }

        public async Task AddAuthorAsync(Author newAuthor)
        {
            int maxId = _libraryContext.Authors.Max(a => a.Id);
            newAuthor.Id = maxId;
            await _libraryContext.Authors.AddAsync(newAuthor);
            await _libraryContext.SaveChangesAsync();
        }
        
    }
}