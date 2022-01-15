namespace Data.Entities;

public class Url
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;

    public Url(string name)
    {
        Name = name;
    }
}