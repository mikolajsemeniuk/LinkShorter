using server.Abstracts;

namespace server.Services;

public class AlgorithmTwo : SlicerAlgorithm
{
    public override SlicerAlgorithm SliceUrl()
    {
        string logic = Guid.NewGuid().ToString();
        UrlSlice.Append(logic);
        return this;
    }

    public override SlicerAlgorithm AddSignature()
    {
        UrlSlice.Append("AES128");
        return this;
    }
}