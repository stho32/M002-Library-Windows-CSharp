using SqlFormat.Interfaces;
using Xunit;

namespace SqlFormat.BL.Tests;

public class SelectSqlPartTests
{
    private ISqlPart GetSqlPart(string[] columns)
    {
        return new SelectSqlPart(columns);
    }
    
    [Fact]
    public void Formatting_a_basic_Select_command_works()
    {
        var command = GetSqlPart(new string[] {"*"});
        var result = command.Render();

        Assert.Equal(@"SELECT *".Trim(), result.Trim());
    }
    
    [Fact]
    public void When_formatting_multiple_columns_each_column_becomes_a_row()
    {
        var command = new SelectSqlPart(new[]
        {
            "Id",
            "FirstName",
            "SurName",
            "Birthdate"
        });
        
        var result = command.Render();

        Assert.Equal(@"SELECT *".Trim(), result.Trim());
    }
}