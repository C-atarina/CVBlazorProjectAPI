using CV.Models;
using Microsoft.AspNetCore.Mvc;
using CVServices;

namespace ApiCV.Controllers;

[ApiController]
[Route("experience")]
public class ExperienceController : ControllerBase
{
    private readonly ExperienceService _experienceService;

    private readonly ILogger<ExperienceService> _logger;

    public ExperienceController(ILogger<ExperienceService> logger,
                        ExperienceService experienceService)
    {
        _logger = logger;
        _experienceService = experienceService;
    }

    [HttpPost("add")]
    public IActionResult PostExperience([FromBody] ExperienceModel experience)
    {
        if (experience == null)
        {
            return BadRequest("Les données de l'expérience ne sont pas valides.");
        }

        return Created($"/api/experience/add", _experienceService.AddExperience(experience));
    }

    [HttpGet("get/{id_user}")]
    public IActionResult GetExperience(int id_user)
    {
        List<ExperienceModel> experiences = _experienceService.GetExperiencesById(id_user);

        return Ok(experiences);
    }

    [HttpPut("update")]
    public IActionResult UpdateExperience([FromBody] ExperienceModel experience)
    {
        _experienceService.UpdateExperience(experience);

        return Ok("Experience Updated");
    }

    [HttpDelete("delete/{id_experience}")]
    public IActionResult DeleteExperience(int id_experience)
    {
        _experienceService.DeleteExperience(id_experience);

        return Ok("Experience Deleted");
    }
}