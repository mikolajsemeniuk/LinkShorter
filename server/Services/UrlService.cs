using server.Abstracts;
using server.Data;
using server.Entities;
using server.Interfaces;
using server.Payloads;
using server.Repositories;

namespace server.Services;

public class UrlService : IUrlService
{
    Random random = new();
    private readonly DataContext _context;
    private readonly UrlRepository urlRepository;

    public UrlService(DataContext context)
    {
        _context = context;
        urlRepository = new UrlRepository(context);
    }

    public string AddUrl(string urlName)
    {
        var urlSlice = ChooseAlgorithm(urlName).SliceUrl().AddSignature().UrlSlice.ToString();
        var url = new Url(urlName, urlSlice);
        urlRepository.Add(url);
        return urlSlice;
    }

    public UrlPayload? GetUrl(string urlSlice)
    {
        return urlRepository.GetUrlPayload(urlSlice);
    } 

    public async Task<bool> Save()
    {
        return await _context.SaveChangesAsync() > 0;
    }

    public SlicerAlgorithm ChooseAlgorithm(string url)
    {
        var choice = random.Next(0, 3);
        switch (choice)
        {
            case 0:
                return new AlgorithmOne();
            case 1:
                return new AlgorithmTwo();
            default:
                return new AlgorithmThree();
        }
    }
}