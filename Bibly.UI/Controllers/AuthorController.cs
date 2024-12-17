using Bibly.Application.Author;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Bibly.UI.Controllers;

[Route("api/[controller]")]
public class AuthorController(ISender sender) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> AddAuthor(AddAuthorCommand command)
        => Ok(await sender.Send(command));

    [HttpGet]
    public async Task<IActionResult> GetAllAuthor(GetAllAuthorQuery query)
       => Ok(await sender.Send(query));

    [HttpGet("Search")]
    public async Task<IActionResult> SearchAuthorByLastName(GetSearchAuthorQuery query)
       => Ok(await sender.Send(query));

}
