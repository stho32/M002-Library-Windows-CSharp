using SqlFormat.BL.Sql;
using SqlFormat.BL.TextPrimitives;
using Xunit;

namespace SqlFormat.BL.Tests.Sql;

public class DeclareSqlStatementTests
{
    [Fact]
    public void DECLARE_x_AS_type()
    {
        var declare = new DeclareSqlStatement("@variable", "VARCHAR(200)");
        var textBlocks = declare.Render();
        
        Assert.Equal("DECLARE", textBlocks[0].Content[0]);
        Assert.Equal(" ", textBlocks[1].Content[0]);
        Assert.Equal("@variable", textBlocks[2].Content[0]);
        Assert.Equal(" ", textBlocks[3].Content[0]);
        Assert.Equal("AS", textBlocks[4].Content[0]);
        Assert.Equal(" ", textBlocks[5].Content[0]);
        Assert.Equal("VARCHAR(200)", textBlocks[6].Content[0]);

        var result = new TextCanvas().Render(textBlocks)[0];
        Assert.Equal("DECLARE @variable AS VARCHAR(200)", result);
    }
}