namespace SqlFormat.Interfaces;

/// <summary>
/// The Canvas is where the text is drawn to.
/// It will convert itself to a list of strings in the end.  
/// </summary>
public interface ITextCanvas
{
    string[] Render(ITextBlock[] textBlocks);
}
