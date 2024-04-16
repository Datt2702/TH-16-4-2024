using ThucHanhAPI.Models;
using ThucHanhAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace ThucHanhAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthorController : ControllerBase
    {
        private readonly ILibraryService _libraryService;

        public AuthorController(ILibraryService libraryService)
        {
            _libraryService = libraryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAuthors()
        {
            var authors = await _libraryService.GetAuthorsAsync();
            if (authors == null)
            {
                return StatusCode(StatusCodes.Status204NoContent, "No author in database.");
            }

            return StatusCode(StatusCodes.Status200OK, authors);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAuthors(Guid id)
        {
            Author author = await _libraryService.GetAuthorAsync(id);

            if (author == null)
            {
                return StatusCode(StatusCodes.Status204NoContent, $"No author found for id: {id}");
            }

            return StatusCode(StatusCodes.Status200OK, author);
        }

        [HttpPost]
        public async Task<ActionResult<Author>> AddAuthor(Author author)
        {
            var dbBook = await _libraryService.AddAuthorAsync(author);

            if (dbBook == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"{author} could not be added.");
            }

            return CreatedAtAction("GetAuthor", new { id = author.Id }, author);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAuthor(int id, Author author)
        {
            if (id != author.Id)
            {
                return BadRequest();
            }

            Author dbBook = await _libraryService.UpdateAuthorAsync(author);

            if (dbBook == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"{author} could not be updated");
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(Guid id)
        {
            var author = await _libraryService.GetAuthorAsync(id);
            (bool status, string message) = await _libraryService.DeleteAuthorAsync(author);

            if (status == false)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, message);
            }

            return StatusCode(StatusCodes.Status200OK, author);
        }
    }
}
//A man who doesn’t spend time with his family can never be a real man.
//Copyright by Duc Dat aka NoFallDamage