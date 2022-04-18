namespace SqlFormat.Interfaces;

public interface ISqlScanner
{
    string[] Scan(string sqlInput);
}
