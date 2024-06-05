using Geair.Application.Mediator.Commands.NotificationCommands;
using Geair.Application.Mediator.Queries.NotificationQueries;
using Geair.Application.Mediator.Results.NotificationResults;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Geair.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public NotificationsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetNotificationList()
        {
            var values = await _mediator.Send(new GetNotificationQueryResult());
            return Ok(values);
        }
        [HttpGet("GetLast5NotificationList")]
        [AllowAnonymous]
        public async Task<IActionResult> GetLast5NotificationList()
        {
            var values = await _mediator.Send(new GetLast5NotificationQueryResult());
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetNotificationById(int id)
        {
            var values = await _mediator.Send(new GetNotificationByIdQuery(id));
            if (values != null) return Ok(values);
            else return BadRequest("Bu Id'ye ait bir veri bulunamadı");
        }
        [HttpPost]
        public async Task<IActionResult> CreateNotification(CreateNotificationCommand createNotificationCommand)
        {
            await _mediator.Send(createNotificationCommand);
            return Ok("Kayıt başarıyla eklendi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateNotification(UpdateNotificationCommand updateNotificationCommand)
        {
            await _mediator.Send(updateNotificationCommand);
            return Ok("Kayıt başarıyla güncellendi");
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteNotification(int id)
        {
            await _mediator.Send(new RemoveNotificationCommand(id));
            return Ok("Kayıt başarıyla silindi");
        }
    }
}
