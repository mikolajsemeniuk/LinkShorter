using Data.Entities;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using server.Inputs;
using Service.Interfaces;

namespace server.Controllers;

[ApiController]
[Route("[controller]")]
public class UrlController : ControllerBase
{
    private readonly IUnitOfWork _unit;
    public UrlController(IUnitOfWork unit)
    {
        _unit = unit;
    }

    [HttpGet]
    public ActionResult Get()
    {
        return Ok(new { done = "works" });
    }

    [HttpGet("{id}")]
    public ActionResult RedirectTo([FromRoute] Guid id)
    {
        var url = _unit.Url.Get(url => url.Id == id);
        if (url == null)
            return BadRequest("your url was not found");
        return Redirect(url.Name);
    }

    [HttpPost]
    public async Task<ActionResult<string>> Add([FromBody] UrlInput input)
    {
        var exists = _unit.Url.Get(url => url.Name == input.Name);
        if (exists == null)
        {
            var url = new Url(input.Name);
            _unit.Url.Add(url);
            if (await _unit.SaveAsync() > 0)
                return Ok(new { link = $"http://localhost:5163/url/{url.Id}" });
            return BadRequest("something gone wrong try again later");
        }
        return Ok(new { link = $"http://localhost:5163/url/{exists.Id}" });
    }
}