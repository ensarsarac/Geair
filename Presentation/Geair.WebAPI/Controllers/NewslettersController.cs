using Geair.Application.Mediator.Commands.NewsletterCommands;
using Geair.Application.Mediator.Queries.NewsletterQueries;
using Geair.Application.Mediator.Results.NewsletterResults;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Geair.WebAPI.Controllers;
[Route("api/[controller]")]
[ApiController]
[Authorize(Policy = "RequiredModeratorRole")]
public class NewslettersController : ControllerBase
{
    private readonly IMediator _mediator;

    public NewslettersController(IMediator mediator)
    {
        _mediator = mediator;
    }
    [HttpGet]
    [AllowAnonymous]
    public async Task<IActionResult> GetNewsletterList()
    {
        var values = await _mediator.Send(new GetNewsletterQueryResult());
        return Ok(values);
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetNewsletterById(int id)
    {
        var values = await _mediator.Send(new GetNewsletterByIdQuery(id));
        if (values != null) return Ok(values);
        else return BadRequest();
    }
    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> CreateNewsletter(CreateNewsletterCommand createNewsletterCommand)
    {
        await _mediator.Send(createNewsletterCommand);
        return Ok("Kayıt başarıyla eklendi");
    }
    [HttpPut]
    public async Task<IActionResult> UpdateNewsletter(UpdateNewsletterCommand updateNewsletterCommand)
    {
        await _mediator.Send(updateNewsletterCommand);
        return Ok("Kayıt başarıyla güncellendi");
    }
    [HttpDelete]
    public async Task<IActionResult> DeleteNewsletter(int id)
    {
        await _mediator.Send(new RemoveNewsletterCommand(id));
        return Ok("Kayıt başarıyla silindi");
    }
}
