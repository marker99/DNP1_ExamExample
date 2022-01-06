using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using AuthorBlazor.Models;

namespace AuthorBlazor.Data.Implementations
{
    public class RestClient
    {
        private static readonly string URL = "https://localhost:5001";

        public async Task<IList<Author>> GetAllAuthors()
        {
            using HttpClient client = new();
            HttpResponseMessage responseMessage = await client.GetAsync($"{URL}/Author");
            string result = await responseMessage.Content.ReadAsStringAsync();
            IList<Author> authors = JsonSerializer.Deserialize<IList<Author>>(result,
                new JsonSerializerOptions {PropertyNameCaseInsensitive = true});
            return authors;
        }

        public async Task<String> AddAuthorAsync(Author newAuthor)
        {
            using HttpClient client = new();
            string authorAsJson = JsonSerializer.Serialize(newAuthor);
            StringContent authorStringContent = new(authorAsJson, Encoding.UTF8, "application/json");
            HttpResponseMessage responseMessage = await client.PostAsync($"{URL}/Author/{newAuthor.Id}", authorStringContent);
            return $"{responseMessage.StatusCode} | {responseMessage.Content.ReadAsStringAsync().Result}";
        }

    }
}