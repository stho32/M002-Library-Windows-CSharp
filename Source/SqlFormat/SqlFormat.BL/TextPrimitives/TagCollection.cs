using SqlFormat.Interfaces.TextPrimitives;

namespace SqlFormat.BL.TextPrimitives;

public class TagCollection : ITagCollection
{
    private readonly string[] _tags;

    public TagCollection(string[] tags)
    {
        _tags = tags;
    }
    
    public string[] GetTags()
    {
        return _tags;
    }

    public bool HasTag(string tag)
    {
        return _tags.Contains(tag);
    }
}