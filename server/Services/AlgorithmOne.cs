using server.Abstracts;

namespace server.Services;

public class AlgorithmOne : SlicerAlgorithm
{
    public override SlicerAlgorithm SliceUrl()
    {
        string logic = Guid.NewGuid().ToString();
        UrlSlice.Append(logic);
        return this;
    }
}