using Bibly.Application.Author.Command;
using Bibly.Application.Author.Query;
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

    [HttpGet]
    public async Task<IActionResult> GetAllAuthor()
        => Ok(await _sender.Send(new GetAllAuthorQuery()));

    [HttpGet("search")]
    public async Task<IActionResult> SearchAuthorQuery([FromQuery] SearchAuthorQuery query)
        => Ok(await _sender.Send(query));

}
