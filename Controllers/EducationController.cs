using CV.Models;
using Microsoft.AspNetCore.Mvc;
using CVServices;

namespace ApiCV.Controllers;

[ApiController]
[Route("education")]
public class EducationController : ControllerBase
{
    private readonly EducationService _educationService;

    private readonly ILogger<EducationController> _logger;

    public EducationController(ILogger<EducationController> logger,
                        EducationService educationService)
    {
        _logger = logger;
        _educationService = educationService;
    }

    [HttpPost("add")]
    public IActionResult PostEducation([FromBody] EducationModel education)
    {
        if (education == null)
        {
            return BadRequest("Les données de l'expérience ne sont pas valides.");
        }

        return Created($"/api/education/add", _educationService.AddEducation(education));
    }

    [HttpGet("get/{id_user}")]
    public IActionResult GetEducation(int id_user)
    {
        List<EducationModel> educations = _educationService.GetEducationsById(id_user);

        return Ok(educations);
    }

    [HttpPut("update")]
    public IActionResult UpdateEducation([FromBody] EducationModel education)
    {
        _educationService.UpdateEducation(education);

        return Ok("Education Updated");
    }

    [HttpDelete("delete/{id_education}")]
    public IActionResult DeleteEducation(int id_education)
    {
        _educationService.DeleteEducation(id_education);

        return Ok("Education Deleted");
    }
}