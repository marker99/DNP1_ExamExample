using System.Collections.Generic;
using System.Threading.Tasks;
using AuthorBlazor.Models;

namespace AuthorBlazor.Data
{
    public interface IAuthorHandler
    {
        Task<IList<Author>> GetAuthorsAsync();
        
        Task AddAuthorAsync(Author newAuthor);
    }
}