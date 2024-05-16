using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Geair.Application.Mediator.Commands.AskedQuestionCommands;
using Geair.Application.Mediator.Queries.AskedQuestionQueries;
using Geair.Application.Mediator.Results.AskedQuestionResults;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Geair.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AskedQuestionsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AskedQuestionsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetAskedQuestionList()
        {
            var values = await _mediator.Send(new GetAskedQuestionListQueryResult());
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAskedQuestionById(int id)
        {
            var values = await _mediator.Send(new GetAskedQuestionByIdQuery(id));
            if(values != null)
            {
                return Ok(values);
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpPost]
        public async Task<IActionResult> CreateAskedQuestion(CreateAskedQuestionCommand createAskedQuestionCommand)
        {
            await _mediator.Send(createAskedQuestionCommand);
            return Ok("Kayıt başarıyla eklendi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateAskedQuestion(UpdateAskedQuestionCommand updateAskedQuestionCommand)
        {
            await _mediator.Send(updateAskedQuestionCommand);
            return Ok("Kayıt başarıyla güncellendi");
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteAskedQuestion(int id)
        {
            await _mediator.Send(new RemoveAskedQuestionCommand(id));
            return Ok("Kayıt başarıyla silindi");
        }
    }
}