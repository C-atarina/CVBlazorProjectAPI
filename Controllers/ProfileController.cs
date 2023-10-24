using CV.Models;
using Microsoft.AspNetCore.Mvc;
using CVServices;

namespace ApiCV.Controllers;

[ApiController]
[Route("profile")]
public class ProfileController : ControllerBase
{
    private readonly ProfilService _profilService;

    private readonly ILogger<ProfileController> _logger;

    public ProfileController(ILogger<ProfileController> logger,
                        ProfilService profilService)
    {
        _logger = logger;
        _profilService = profilService;
    }

    [HttpPost("add")]
    public IActionResult PostProfil([FromBody] ProfilModel profil)
    {
        if (profil == null)
        {
            return BadRequest("Les données du profil ne sont pas valides.");
        }

        return Created($"/api/profile/add", _profilService.AddProfile(profil));
    }

    [HttpGet("get/{id_user}")]
    public IActionResult GetProfile(int id_user)
    {
        ProfilModel profil = _profilService.GetProfilById(id_user);

        return Ok(profil);
    }

    [HttpGet("getAll")]
    public IActionResult GetAllProfiles()
    {
        List<ProfilModel> profiles = _profilService.GetAllProfiles();

        return Ok(profiles);
    }

    [HttpPut("update")]
    public IActionResult UpdateProfile([FromBody] ProfilModel profil)
    {
        _profilService.UpdateProfile(profil);

        return Ok("Profil Updated");
    }

    [HttpDelete("delete")]
    public IActionResult DeleteProfile(int id_user)
    {
        _profilService.DeleteProfile(id_user);

        return Ok("Profil Deleted");
    }
}