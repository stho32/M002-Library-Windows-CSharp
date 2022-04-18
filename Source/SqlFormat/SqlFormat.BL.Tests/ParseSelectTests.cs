using SqlFormat.Interfaces;
using Xunit;

namespace SqlFormat.BL.Tests;

public class ParseSelectTests
{
    private ISqlScanner GetScanner()
    {
        return new SqlScanner();
    }
    
    [Fact]
    public void Can_read_a_simple_select_statement()
    {
        var sqlInput = @"SELECT * FROM Table1";
        var sqlScanner = GetScanner();
        var tokens = sqlScanner.Scan(sqlInput);

        Assert.Equal("SELECT", tokens[0]);
        Assert.Equal("*", tokens[1]);
        Assert.Equal("FROM", tokens[2]);
        Assert.Equal("Table1", tokens[3]);
    }
}


