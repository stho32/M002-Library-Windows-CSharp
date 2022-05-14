using SqlFormat.Interfaces.TextPrimitives;

namespace SqlFormat.BL.TextPrimitives;

public class TextCanvas : ITextCanvas
{
    public string[] Render(ITextBlock[] textBlocks)
    {
        var result = new List<string>();

        foreach (var textBlock in textBlocks)
        {
            EnterEnoughWhitespaceIntoBuffer(textBlock, result);
            PlaceContent(textBlock, result);
        }
        
        return TrimAllRows(result.ToArray());
    }

    private string[] TrimAllRows(string[] arrayOfStrings)
    {
        return arrayOfStrings
            .Select(x => x.TrimEnd())
            .ToArray();
    }

    private static void PlaceContent(ITextBlock textBlock, List<string> result)
    {
        var height = textBlock.GetHeight();
        var content = textBlock.GetContent();
        
        for (int i = 0; i < height; i++)
        {
            var realPositionY = textBlock.Y + i;
            var charArray = result[realPositionY].ToCharArray();

            for (int j = 0; j < content[i].Length; j++)
            {
                var realPositionX = textBlock.X + j;
                charArray[realPositionX] = content[i][j];
            }

            result[realPositionY] = new string(charArray);
        }
    }

    private static void EnterEnoughWhitespaceIntoBuffer(ITextBlock textBlock, List<string> textBuffer)
    {
        var maximumY = textBlock.Y + textBlock.GetHeight();
        
        while (textBuffer.Count < maximumY)
        {
            textBuffer.Add("");
        }

        for (int i = textBlock.Y; i < maximumY; i++)
        {
            var maximumWidth = textBlock.X + textBlock.GetWidth();

            if (textBuffer[i].Length < maximumWidth)
            {
                var missingLength = maximumWidth - textBuffer[i].Length;
                var missingLengthInSpaces = new string(' ', missingLength);
                textBuffer[i] += missingLengthInSpaces;
            }
        }
    }

}