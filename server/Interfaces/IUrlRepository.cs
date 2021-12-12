using server.Entities;
using server.Payloads;

namespace server.Interfaces;

public interface IUrlRepository
{
    Url Add(Url url);
    UrlPayload? GetUrlPayload(string slice);
}