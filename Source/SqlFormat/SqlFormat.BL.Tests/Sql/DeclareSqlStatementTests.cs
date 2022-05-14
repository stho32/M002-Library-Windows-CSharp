using SqlFormat.BL.Sql;
using SqlFormat.BL.TextPrimitives;
using SqlFormat.Interfaces.TextPrimitives;
using Xunit;

namespace SqlFormat.BL.Tests.Sql;

public class DeclareSqlStatementTests
{
    [Fact]
    public void DECLARE_x_type()
    {
        var declare = new DeclareSqlStatement("@variable", "VARCHAR(200)");
        var textBlocks = declare.Render();

        var result = new TextCanvas().Render(textBlocks)[0];
        Assert.Equal("DECLARE @variable VARCHAR(200)", result);
    }

    [Fact]
    public void DECLARE_x_type_with_default()
    {
        var declare = new DeclareSqlStatement("@variable", "VARCHAR(200)", "'Hello world'");
        var textBlocks = declare.Render();
        var result = new TextCanvas().Render(textBlocks)[0];
        Assert.Equal("DECLARE @variable VARCHAR(200) = 'Hello world'", result);
    }

    [Fact]
    public void When_several_DECLARE_Statements_follow_each_other_AS_TYPE_and_DEFAULTS_are_aligned()
    {
        var statement1 = new DeclareSqlStatement("@var1", "VARCHAR(100)", "'Hello'");
        var statement2 = new DeclareSqlStatement("@bunch", "VARCHAR(100)", "'Another Hello'");
        var statement3 = new DeclareSqlStatement("@birthday", "DATETIME", "{d '2022-01-01'}");

        var blocks = new List<ITextBlock>();
        blocks.AddRange(statement1.Render());
        blocks.AddRange(statement2.Render());
        blocks.AddRange(statement3.Render());

        var verticalGroup = new VerticalTextBlockGroup(0, 0, blocks.ToArray());
        var canvas = new TextCanvas();
        var result = canvas.Render(new[] {verticalGroup});

        Assert.Equal("DECLARE @var1     VARCHAR(100) = 'Hello'", result[0]);
        Assert.Equal("DECLARE @bunch    VARCHAR(100) = 'Another Hello'", result[1]);
        Assert.Equal("DECLARE @birthday DATETIME     = {d '2022-01-01'}", result[2]);
        
        Assert.Equal(3, result.Length);
    }
}