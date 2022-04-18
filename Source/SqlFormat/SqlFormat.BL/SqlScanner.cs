using SqlFormat.Interfaces;

namespace SqlFormat.BL;

public class SqlScanner : ISqlScanner
{
    public string[] Scan(string sqlInput)
    {
        return sqlInput.Split(" ", StringSplitOptions.RemoveEmptyEntries);
    }
}