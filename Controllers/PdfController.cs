using Microsoft.AspNetCore.Mvc;
using CVServices;// Assurez-vous d'importer le bon espace de noms pour votre classe PdfGenerator

[Route("pdf")]
[ApiController]
public class PdfController : ControllerBase
{
    private readonly PdfService _pdfService;

    public PdfController(PdfService pdfService)
    {
        _pdfService = pdfService;
    }

    [HttpGet("generate")]
    public IActionResult GeneratePdf()
    {
        var pdfBytes = _pdfService.GeneratePdf();

        if (pdfBytes == null || pdfBytes.Length == 0)
        {
            return NotFound();
        }

        return File(pdfBytes, "application/pdf", "cv.pdf");
    }
}
