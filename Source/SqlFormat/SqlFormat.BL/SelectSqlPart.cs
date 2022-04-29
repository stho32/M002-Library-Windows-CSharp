using System.Text;
using SqlFormat.Interfaces;

namespace SqlFormat.BL;

public class SelectSqlPart : ISqlPart
{
    private readonly string[] _columns;

    public SelectSqlPart(string[] columns)
    {
        _columns = columns;
    }

    public string Render()
    {
        var result = new TextEditor();
        
        result.AddRow($"SELECT {_columns}");

        return result.ToString();
    }
}