using Microsoft.Azure.Cosmos;
using Microsoft.AspNetCore.Mvc;
using meli_mutations.Core.Resolver;
using meli_mutations.Model;
using meli_mutations.Repository;
using Azure.Data.Tables;
using static meli_mutations.Entity.Entities;
using System.Net;

namespace meli_mutations.Controllers;

[ApiController]
[Route("dna")]
public class DnaController : ControllerBase
{
    private readonly ILogger<DnaController> _logger;
    private readonly IMutantRepository _mutantRepository;

    public DnaController(ILogger<DnaController> logger, IMutantRepository mutantRepository)
    {
        _logger = logger;
        _mutantRepository = mutantRepository;
    }

    [HttpGet("healthcheck")]
    public IActionResult HealhCheck()
        => Ok("alive");

    [HttpPost("mutation")]
    public async Task<IActionResult> Mutation(Models.DnaRequest dnaReq)
    {
        bool isMutant = default;
        string[] data = dnaReq.data;
        ObjectResult forbiddenResult = new ObjectResult("") { StatusCode = (int)HttpStatusCode.Forbidden };
        try {
            if (!MutantResolver.ValidDna(data)) 
                throw new ApplicationException("Dna should be NxN");

            string hash = HashResolver.Resolve(string.Join("", data));

            var mutantEntity = await _mutantRepository.Get(hash);
            if (mutantEntity != null) {
                isMutant = mutantEntity.Value;
                if(!isMutant)
                    return forbiddenResult;
                return Ok();
            }
            
            isMutant = MutantResolver.Resolve(data);
            var mutant = new Mutant() {
                RowKey = hash,
                PartitionKey = "mutations",
                Value = isMutant
            };
            
            using(var response = await _mutantRepository.Add(mutant)) {
                if(response.IsError) {
                    throw new Exception("Error inserting on CosmosDb");
                }
            }
        }
        catch(ApplicationException ex) {
            this._logger.LogError(ex.ToString());
            return BadRequest(ex);
        }
        catch(Exception ex) {
            string uuid = new Guid().ToString();
            this._logger.LogCritical($"UUID: {uuid} Message: {ex.ToString()}");
            return StatusCode(StatusCodes.Status500InternalServerError, $"See inner the log file: {uuid}");
        } 

        if(!isMutant)
            return forbiddenResult;
        return Ok();
    }

    [HttpGet("stats")]
    public async Task<IActionResult> Stats()
    {
        var rows = await _mutantRepository.All();

        int countHuman = rows.Where(x => !x.Value).Count()
        , countMutant = rows.Where(x => x.Value).Count();

        return Ok(new Models.StatsResponse {
            count_human_dna = countHuman,
            count_mutant_dna = countMutant,
            ratio = Math.Round((double)countMutant / countHuman, 2),
        });
    }
}

