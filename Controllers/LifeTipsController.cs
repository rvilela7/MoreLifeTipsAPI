using Microsoft.AspNetCore.Mvc;
using System.IO;

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
        return Ok(fileRead());
    }

    private string fileRead()
    {
        string myFile = string.Empty;

        foreach (string line in File.ReadLines(@"lifetips.txt"))
        {
            if (string.IsNullOrWhiteSpace(line))
                continue;
            myFile += line.Trim().Substring(2);
        }
        return myFile;
    }
}
