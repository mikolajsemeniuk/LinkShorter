using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using server.Inputs;
using server.Interfaces;

namespace server.Controllers;

[ApiController]
[Route("[controller]")]
public class UrlController : ControllerBase
{
    private readonly IUrlService _urlService;

    public UrlController(IUrlService urlService)
    {
        _urlService = urlService;
    }

    [HttpGet]
    public ActionResult Get()
    {
        return Ok(new { done = "works" });
    }

    [HttpGet("{id}")]
    public ActionResult RedirectTo([FromRoute] string id)
    {
        var url = _urlService.GetUrl(id);
        if (url == null)
            return BadRequest("your url was not found");
        return Redirect(url.urlName);
    }

    [HttpPost]
    public async Task<ActionResult<string>> Add([FromBody] UrlInput input)
    {
        var slice = _urlService.AddUrl(input.UrlName);
        if (await _urlService.Save()) 
            return Ok(new { link = $"http://localhost:5163/url/{slice}" });
        return BadRequest("something gone wrong try again later");
    }
}
