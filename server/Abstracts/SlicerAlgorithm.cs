using System.Text;

namespace server.Abstracts;

public abstract class SlicerAlgorithm
{
    public StringBuilder UrlSlice { get; set; } = new StringBuilder();
    public abstract SlicerAlgorithm SliceUrl();
    public virtual SlicerAlgorithm AddSignature()
    {
        UrlSlice.Append("RSA");
        return this;
    }
}