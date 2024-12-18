using Bibly.Application.Books;
using Bibly.Application.Common.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Bibly.UI.Controllers
{
    [Route("api/[controller]")]
    public class BookController : ControllerBase
    {
        private readonly ISender _sender;
        public BookController(ISender sender)
        {
            _sender = sender;
        }

        [HttpPost]
        public async Task<IActionResult> AddBook(AddBookCommand command)
        {
            try
            {
                return Ok(await _sender.Send(command));
            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.Errors);
            }
        }   
    }
}
