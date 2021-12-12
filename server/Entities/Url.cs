namespace server.Entities;

public class Url
{
    public Guid UrlId { get; set; } = Guid.NewGuid();
    public string UrlName { get; set; }
    public string UrlSlice { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;

    public Url(string urlName, string urlSlice)
    {
        UrlName = urlName;
        UrlSlice = urlSlice;
    }
}