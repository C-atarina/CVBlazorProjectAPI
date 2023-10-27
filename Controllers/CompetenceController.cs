using CV.Models;
using Microsoft.AspNetCore.Mvc;
using CVServices;

namespace ApiCV.Controllers;

[ApiController]
[Route("competence")]
public class CompetenceController : ControllerBase
{
    private readonly CompetenceService _competenceService;
    private readonly TypeCompetenceService _typeCompetenceService;

    private readonly ILogger<CompetenceController> _logger;

    public CompetenceController(ILogger<CompetenceController> logger,
                        CompetenceService competenceService,
                        TypeCompetenceService typeCompetenceService)
    {
        _logger = logger;
        _competenceService = competenceService;
        _typeCompetenceService = typeCompetenceService;
    }

    [HttpPost("add")]
    public IActionResult PostCompetence([FromBody] CompetenceModel competence)
    {
        if (competence == null)
        {
            return BadRequest("Les données de la competence ne sont pas valides.");
        }

        return Created($"/api/competence/add", _competenceService.AddCompetence(competence));
    }

    [HttpGet("getType")]
    public IActionResult GetTypeCompetence()
    {
        List<TypeCompetenceModel> typeCompetences = _typeCompetenceService.GetAllTypeCompetences();

        return Ok(typeCompetences);
    }

    [HttpGet("get/{id_user}")]
    public IActionResult GetCompetences(int id_user)
    {
        List<CompetenceModel> competences = _competenceService.GetCompetencesById(id_user);

        return Ok(competences);
    }

    [HttpPut("update")]
    public IActionResult UpdateCompetence([FromBody] CompetenceModel competence)
    {
        _competenceService.UpdateCompetence(competence);

        return Ok("Competence Updated");
    }

    [HttpDelete("delete/{id_competetence}")]
    public IActionResult DeleteCompetence(int id_competetence)
    {
        _competenceService.DeleteCompetence(id_competetence);

        return Ok("Competence Deleted");
    }
}