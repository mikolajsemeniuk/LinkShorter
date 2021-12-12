using server.Abstracts;
using server.Payloads;

namespace server.Interfaces;

public interface IUrlService
{
    SlicerAlgorithm ChooseAlgorithm(string url);
    string AddUrl(string urlName);
    UrlPayload? GetUrl(string urlSlice);
    Task<bool> Save();
}