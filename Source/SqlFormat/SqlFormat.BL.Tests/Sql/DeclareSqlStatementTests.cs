using SqlFormat.BL.Sql;
using SqlFormat.BL.TextPrimitives;
using SqlFormat.Interfaces;
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

        var row1 = new TextBlockCollection(statement1.Render());
        var row2 = new TextBlockCollection(statement2.Render());

        var pos1 = row1.GetTagPosition("DECLARE_TYPE");
        var pos2 = row2.GetTagPosition("DECLARE_TYPE");

        var posMax = pos1;
        if (pos2 > posMax) posMax = pos2;

        row1.MoveTaggedBlockToColumn(posMax);
        row2.MoveTaggedBlockToColumn(posMax);

        Assert.Equal("DECLARE @var1  VARCHAR(100) = 'Hello'", row1.RenderToText());
        Assert.Equal("DECLARE @bunch VARCHAR(100) = 'Another Hello'", row2.RenderToText());
    }
}

