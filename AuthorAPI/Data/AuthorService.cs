using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuthorAPI.Models;
using AuthorAPI.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace AuthorAPI.Data
{
    public class AuthorService : IAuthorService
    {
        private static LibraryContext _libraryContext;

        public AuthorService()
        {
            _libraryContext = new();
        }
        
        public async Task<IList<Author>> GetAuthorsAsync()
        {
            return await _libraryContext.Authors.Include(a => a.Books).ToListAsync();
        }

        //Example from Troels github
        public async Task<Author> AddAuthorAsync(Author newAuthor)
        {
            EntityEntry<Author> justAdded = await _libraryContext.Authors.AddAsync(newAuthor);
            await _libraryContext.SaveChangesAsync();
            return justAdded.Entity;
        }
        
        
        //For some reason this does not work, it says that the sequence is empty????
        
        /*public async Task AddAuthorAsync(Author newAuthor)
        {
            int maxId = _libraryContext.Authors.Max(a => a.Id);
            newAuthor.Id = maxId;
            await _libraryContext.Authors.AddAsync(newAuthor);
            await _libraryContext.SaveChangesAsync();
        }*/
    }
}