using System.Text;
using SqlFormat.Interfaces;

namespace SqlFormat.BL;

public class TextEditor : ITextEditor
{
    private List<string> _rows = new List<string>();
    
    public TextEditor()
    {
    }

    public void AddRows(string[] values)
    {
        _rows.AddRange(values);
    }

    public override string ToString()
    {
        var result = new StringBuilder();

        foreach (var row in _rows)
        {
            result.AppendLine(row);
        }
        
        return result.ToString().Trim();
    }

    public void AddRow(string row)
    {
        _rows.Add(row);
    }

    public void IndentRowsUsingSpaces(int fromRow, int toRow, int spaceCount)
    {
        string spaces = new string(' ', spaceCount);
        
        for (int i = fromRow; i <= toRow; i++)
        {
            if (RowExists(i))
            {
                _rows[i] = spaces + _rows[i];
            }
        }
    }

    private bool RowExists(int rowIndex)
    {
        return rowIndex < _rows.Count;
    } 

    public string[] GetRows()
    {
        return _rows.ToArray();
    }

    public void InsertTextAt(int row, int column, string text)
    {
        if (RowExists(row) && column < _rows[row].Length)
        {
            var rowLength = _rows[row].Length;
            var beforeColumn = _rows[row].Substring(0, column);
            var afterColumn = _rows[row].Substring(column, rowLength - column);

            _rows[row] = beforeColumn + text + afterColumn;
        }
    }
}