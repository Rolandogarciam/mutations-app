using Microsoft.Azure.Cosmos;
using Microsoft.AspNetCore.Mvc;
using meli_mutations.Core.Resolver;
using meli_mutations.Model;
using meli_mutations.Repository;
using Azure.Data.Tables;
using static meli_mutations.Entity.Entities;
using System.Net;
using System.Text.RegularExpressions;

namespace meli_mutations.Controllers;

[ApiController]
[Route("dna")]
public class DnaController : ControllerBase
{
    private static readonly Regex ValidCharRegex = new(@"[^ACGT]", RegexOptions.Compiled);
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

    [HttpPost("mutant")]
    public async Task<IActionResult> Mutant(Models.DnaRequest dnaReq)
    {
        bool isMutant = default;
        string[] dna = dnaReq.Dna;
        ObjectResult forbiddenResult = new ObjectResult("") { StatusCode = (int)HttpStatusCode.Forbidden };
        try {

            if(!ContainsValidCharacters(dna))
                throw new ApplicationException("Dna contains invalid characters");
                
            if (!MutantResolver.ValidDna(dna)) 
                throw new ApplicationException("Dna should be NxN");

            string hash = HashResolver.Resolve(string.Join("", dna));

            var mutantEntity = await _mutantRepository.Get(hash);
            if (mutantEntity != null) {
                isMutant = mutantEntity.Value;
                if(!isMutant)
                    return forbiddenResult;
                return Ok();
            }
            
            isMutant = MutantResolver.Resolve(dna);
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
            this._logger.LogWarning(ex.ToString());
            return BadRequest(ex.Message);
        }
        catch(Exception ex) {
            string uuid = new Guid().ToString();
            this._logger.LogError($"UUID: {uuid} Message: {ex.ToString()}");
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

        var stats = new Models.StatsResponse();
        stats.CountMutantDna = countMutant;
        stats.CountHumanDna = countHuman;
        if(countHuman > 0) 
            stats.Ratio = Math.Round((double)countMutant / countHuman, 2);

        return Ok(stats);
    }

    // Complexity 
    // Time: O(N)
    private bool ContainsValidCharacters(string[] dna) 
    {
        int N = dna.Length;
        for (int i = 0; i < N; i++) {
            if(DnaController.ValidCharRegex.IsMatch(dna[i]))
                return false;
        }
        return true;
    }
}

