using Microsoft.AspNetCore.Mvc;

namespace MoreLifeTips.Controllers;

[ApiController]
[Route("[controller]")]
public class LifeTipsController : ControllerBase
{
    private readonly ILogger<LifeTipsController> _logger;
    private readonly List<string> fileLines;
    public LifeTipsController(ILogger<LifeTipsController> logger)
    {
        _logger = logger;
        fileLines = fileRead();
    }

    [HttpGet("/quote")]
    public IActionResult GetRandomQuote()
    {
        Random rnd = new Random();
        int i = rnd.Next(fileLines.Count());
        return Ok($"({i}) {fileLines[i]}");
    }

    [HttpGet("/quote/{line}")]
    public IActionResult GetQuote(int line)
    {
        try
        {
            return Ok(fileLines[line]);
        }
        catch (ArgumentOutOfRangeException)
        {
            return BadRequest("Line number out of range");
        }
    }

    [HttpGet("/all")]
    public IActionResult GetAllQuotes()
    {
        string allQuotes = string.Empty;
        int i = 0;
        fileLines.ForEach(m => allQuotes += $"({++i}) {m}\n");
        return Ok(allQuotes);
    }

    [HttpGet("/author")]
    public ContentResult GetAuthor()
    {
        return base.Content("From <a href=\"https://kk.org/thetechnium/103-bits-of-advice-i-wish-i-had-known\">TheTechnium</a>", "text/html");
    }

    private List<string> fileRead()
    {
        try
        {
            List<string> linesList = new List<string>();
            foreach (string line in System.IO.File.ReadLines(@"lifetips.txt"))
            {
                if (string.IsNullOrWhiteSpace(line))
                    continue;
                linesList.Add(line.Trim().Substring(2));
            }
            return linesList;
        }
        catch (System.IO.FileNotFoundException)
        {
            _logger.LogError("File not found");
            return new List<string>();
        }
    }
}
