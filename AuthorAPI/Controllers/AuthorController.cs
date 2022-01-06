using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuthorAPI.Data;
using AuthorAPI.Models;
using AuthorAPI.Persistence;
using Microsoft.AspNetCore.Mvc;

namespace AuthorAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthorController : ControllerBase
    {
        private IAuthorService _authorService;

        public AuthorController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        [HttpGet]
        public async Task<ActionResult<IList<Author>>> GetAuthors([FromQuery] int? authorId)
        {
            try
            {
                IList<Author> authors = await _authorService.GetAuthorsAsync();

                // If an ID was added, sort out all people without that ID
                if (authorId != null)
                {
                    authors = authors.Where(a => a.Id == authorId).ToList();
                }

                return Ok(authors);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }


        [HttpPost]
        [Route("{authorId:int}")]
        public async Task<ActionResult<Author>> AddAuthor([FromBody] Author author)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _authorService.AddAuthorAsync(author);
                return Created($"/{author.Id}", author);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
        
        /*[HttpPost]
        public async Task<ActionResult<Author>> AddAuthor([FromBody] Author author)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                Author added = await _authorService.AddAuthorAsync(author);
                return Created($"/{added.Id}", added);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }*/
        
    }
}