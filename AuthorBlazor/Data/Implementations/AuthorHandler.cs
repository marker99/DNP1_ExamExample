using System.Collections.Generic;
using System.Threading.Tasks;
using AuthorBlazor.Models;

namespace AuthorBlazor.Data.Implementations
{
    public class AuthorHandler : IAuthorHandler
    {
        public Task<IList<Author>> GetAuthorsAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task AddAuthorAsync(Author newAuthor)
        {
            throw new System.NotImplementedException();
        }
    }
}