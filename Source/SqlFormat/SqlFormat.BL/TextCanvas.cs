using SqlFormat.Interfaces;

namespace SqlFormat.BL;

public class TextCanvas : ITextCanvas
{
    public string[] Render(ITextBlock[] textBlocks)
    {
        var result = new List<string>();

        foreach (var textBlock in textBlocks)
        {
            PlaceContent(textBlock, result);
        }
        
        return result.ToArray();
    }

    private static void PlaceContent(ITextBlock textBlock, List<string> result)
    {
        var rowNumber = textBlock.Y;
        foreach (var row in textBlock.Content)
        {
            PlaceRow(rowNumber, textBlock.X, row, result);
            rowNumber += 1;
        }
    }

    private static void PlaceRow(int rowIndex, int columnIndex, string rowContent, List<string> result)
    {
        AddEmptyRowsUntilBufferHasEnoughToFitContent(rowIndex, result);
    }

    private static void AddEmptyRowsUntilBufferHasEnoughToFitContent(int rowIndex, List<string> result)
    {
        while (result.Count <= rowIndex)
        {
            result.Add("");
        }
    }
}