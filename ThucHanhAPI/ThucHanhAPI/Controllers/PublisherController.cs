using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;
using ThucHanhAPI.Models;
using ThucHanhAPI.Services;

namespace WebApiThucHanh.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PublisherController : ControllerBase
    {
        private readonly ILibraryService _libraryService;

        public Guid ID { get; private set; }

        public PublisherController(ILibraryService libraryService)
        {
            _libraryService = libraryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetPublishers()
        {
            var publishers = await _libraryService.GetPublisherAsync();

            if (publishers == null)
            {
                return StatusCode(StatusCodes.Status204NoContent, "No publishers in database");
            }

            return StatusCode(StatusCodes.Status200OK, publishers);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPublisher(int id)
        {
            Publisher publisher = await _libraryService.GetPublisherAsync(ID);

            if (publisher == null)
            {
                return StatusCode(StatusCodes.Status204NoContent, $"No Publisher found for id: {id}");
            }

            return StatusCode(StatusCodes.Status200OK, publisher);
        }

        [HttpPost]
        public async Task<ActionResult<Publisher>> AddPublisher(Publisher publisher)
        {
            Publisher dbPublisher = await _libraryService.GetPublisherAsync(publisher);

            if (dbPublisher == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"{publisher.Name} could not be added.");
            }

            return CreatedAtAction("GetPublisher", new { id = publisher.ID }, publisher);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePublisher(int id, Publisher publisher)
        {
            if (id != publisher.ID)
            {
                return BadRequest();
            }

            Publisher dbPublisher = await _libraryService.UpdatePublisherAsync(publisher);

            if (dbPublisher == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"{publisher.Name} could not be updated");
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePublisher(int id)
        {
            var publisher = await _libraryService.GetPublisherAsync(id);
            (bool status, string message) = await _libraryService.DeletePublisherAsync(publisher);

            if (status == false)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, message);
            }

            return StatusCode(StatusCodes.Status200OK, publisher);
        }
    }
}
//A man who doesn’t spend time with his family can never be a real man.
//Copyright by Duc Dat aka NoFallDamage