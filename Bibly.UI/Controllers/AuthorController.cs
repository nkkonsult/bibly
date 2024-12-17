using Bibly.Application.Author;
using Bibly.Application.Common.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Bibly.UI.Controllers;

[Route("api/[controller]")]
public class AuthorController : ControllerBase
{
    private readonly ISender _sender;

    public AuthorController(ISender sender)
    {
        _sender = sender;
    }

    [HttpPost]
    public async Task<IActionResult> AddAuthor(AddAuthorCommand command)
    {
        try
        {
            return Ok(await _sender.Send(command));
        }
        catch (ValidationException ex )
        {

            return BadRequest(ex.Errors);
        }
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAuthors([FromQuery] GetAllAuthorsQuery query)
        => Ok(await _sender.Send(query));

}
