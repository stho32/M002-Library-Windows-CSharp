using SqlFormat.Interfaces;

namespace SqlFormat.BL;

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
        
        return result.ToArray();
    }

    private static void PlaceContent(ITextBlock textBlock, List<string> result)
    {
        for (int i = 0; i < textBlock.Height; i++)
        {
            var realPositionY = textBlock.Y + i;
            var charArray = result[realPositionY].ToCharArray();

            for (int j = 0; j < textBlock.Content[i].Length; j++)
            {
                var realPositionX = textBlock.X + j;
                charArray[realPositionX] = textBlock.Content[i][j];
            }

            result[realPositionY] = new string(charArray);
        }
    }

    private static void EnterEnoughWhitespaceIntoBuffer(ITextBlock textBlock, List<string> textBuffer)
    {
        var maximumY = textBlock.Y + textBlock.Height;
        
        while (textBuffer.Count < maximumY)
        {
            textBuffer.Add("");
        }

        for (int i = textBlock.Y; i < maximumY; i++)
        {
            var maximumWidth = textBlock.X + textBlock.Width;

            if (textBuffer[i].Length < maximumWidth)
            {
                var missingLength = maximumWidth - textBuffer[i].Length;
                var missingLengthInSpaces = new string(' ', missingLength);
                textBuffer[i] += missingLengthInSpaces;
            }
        }
    }

}