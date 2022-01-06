using System.Collections.Generic;
using System.Threading.Tasks;
using AuthorBlazor.Models;

namespace AuthorBlazor.Data.Implementations
{
    public class AuthorHandler : IAuthorHandler
    {
        private static RestClient _restClient;

        public AuthorHandler()
        {
            _restClient = new RestClient();
        }

        public async Task<IList<Author>> GetAuthorsAsync()
        {
            return await _restClient.GetAllAuthors();
        }

        public async Task AddAuthorAsync(Author newAuthor)
        {
            await _restClient.AddAuthorAsync(newAuthor);
        }
    }
}