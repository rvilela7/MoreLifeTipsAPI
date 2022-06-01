using Microsoft.AspNetCore.Mvc;

namespace MoreLifeTips.Controllers;

[ApiController]
[Route("[controller]")]
public class LifeTipsController : ControllerBase
{
    private readonly ILogger<LifeTipsController> _logger;
    public LifeTipsController(ILogger<LifeTipsController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public async Task<IActionResult> GetRandomQuote()
    {
        return Ok();
    }

    [HttpGet("{line}")]
    public async Task<IActionResult> GetRandomQuote(int line)
    {
        return Ok();
    }

    [HttpGet("/all")]
    public async task<IActionResult> GetAllQuotes()
    {
        return Ok();
    }

    private string fileRead()
    {
        return "";
    }
}
