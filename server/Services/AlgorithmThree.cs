using server.Abstracts;

namespace server.Services;

public class AlgorithmThree : SlicerAlgorithm
{
    public override SlicerAlgorithm SliceUrl()
    {
        string logic = Guid.NewGuid().ToString();
        UrlSlice.Append(logic);
        return this;
    }

    public SlicerAlgorithm AddSignature(string signature = "SHA512")
    {
        UrlSlice.Append(signature);
        return this;
    }
}