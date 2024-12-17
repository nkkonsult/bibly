using Bibly.Application.Author;
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
        => Ok(await _sender.Send(command));
}
