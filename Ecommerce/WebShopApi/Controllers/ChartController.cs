using Charts.Core.DTOs;
using Charts.Mediator.GetActiveChartByPerson;
using Charts.Mediator.SaveChart;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebShopApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ChartController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ChartController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("{personId}")]
        public async Task<IActionResult> GetActiveChart(Guid personId)
        {
            return Ok( await _mediator.Send(new GetActiveChartByPersonQuery(personId)));
        }

        [HttpPost]
        public async Task<IActionResult> SaveChart(Guid personId, [FromBody] ChartDTO chart)
        {
            return Ok(await _mediator.Send(new SaveChartCommand(chart)));
        }
    }
}
