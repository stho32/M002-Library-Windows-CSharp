namespace SqlFormat.Interfaces.TextPrimitives;

public interface ITagCollection
{
    string[] GetTags();
    bool HasTag(string tag);
}