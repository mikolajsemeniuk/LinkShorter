using System.ComponentModel.DataAnnotations;

namespace server.Inputs;

public record struct UrlInput
{
    [Required]
    public string Name { get; set; }
}