using Geair.Application.Mediator.Commands.CompanyAddressCommands;
using Geair.Application.Mediator.Queries.CompanyAddressQueries;
using Geair.Application.Mediator.Results.CompanyAddressResults;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Geair.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyAddressController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CompanyAddressController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetCompanyAddressList()
        {
            var values = await _mediator.Send(new GetCompanyAddressListQueryResult());
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCompanyAddressById(int id)
        {
            var values = await _mediator.Send(new GetCompanyAddressByIdQuery(id));
            if (values != null) return Ok(values);
            else return BadRequest();
        }
        [HttpPost]
        public async Task<IActionResult> CreateCompanyAddress(CreateCompanyAddressCommand createCompanyAddressCommand)
        {
            await _mediator.Send(createCompanyAddressCommand);
            return Ok("Kayıt başarıyla eklendi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateCompanyAddress(UpdateCompanyAddressCommand updateCompanyAddressCommand)
        {
            await _mediator.Send(updateCompanyAddressCommand);
            return Ok("Kayıt başarıyla güncellendi");
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteCompanyAddress(int id)
        {
            await _mediator.Send(new RemoveCompanyAddressCommand(id));
            return Ok("Kayıt başarıyla silindi");
        }
    }
}
