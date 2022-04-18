using System.Text;
using SqlFormat.Interfaces;

namespace SqlFormat.BL;

public class RowBasedTextProcessor : IRowBasedTextProcessor
{
    private List<string> _rows = new List<string>();
    
    public RowBasedTextProcessor()
    {
    }

    public void AddAsRows(string[] values)
    {
        _rows.AddRange(values);
    }

    public void IndentUsingFirstLineText(string text)
    {
        
    }

    public override string ToString()
    {
        var result = new StringBuilder();

        foreach (var row in _rows)
        {
            result.AppendLine(row);
        }
        
        return result.ToString();
    }
}