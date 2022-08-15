using Microsoft.AspNetCore.Mvc;
using meli_mutations.Core;

namespace meli_mutations.Controllers;

[ApiController]
[Route("dna")]
public class DnaController : ControllerBase
{
    private readonly ILogger<DnaController> _logger;

    public DnaController(ILogger<DnaController> logger)
    {
        _logger = logger;
    }

    [HttpGet("healthcheck")]
    public async Task<IActionResult> HealhCheck(Models.DnaRequest dnaReq)
    {
        return Ok("alive");
    }

    [HttpPost("mutation")]
    public async Task<IActionResult> Mutation(Models.DnaRequest dnaReq)
    {
        return Ok(new Models.DnaResponse {
            result = MutationResolver.Resolve(dnaReq.data)
        });
    }

    [HttpGet("status")]
    public async Task<IActionResult> Status(Models.DnaRequest dnaReq)
    {
        return Ok("ok");
    }
}

