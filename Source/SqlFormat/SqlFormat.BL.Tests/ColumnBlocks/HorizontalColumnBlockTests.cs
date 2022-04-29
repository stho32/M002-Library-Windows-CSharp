using SqlFormat.BL.ColumnBlocks;
using SqlFormat.Interfaces;
using Xunit;

namespace SqlFormat.BL.Tests.ColumnBlocks;

public class HorizontalColumnBlockTests
{
    private IRenderedText GetColumnBlock(string[] columns)
    {
        return new HorizontalColumnBlock(columns);
    } 
    
    [Fact]
    public void One_column_is_just_a_row_with_the_text()
    {
        var block = GetColumnBlock(new[]{"HelloWorld"});
        Assert.Equal("HelloWorld", block.Render());
    }
    
    [Fact]
    public void When_no_column_is_in_a_column_block_then_it_returns_an_empty_string()
    {
        var block = GetColumnBlock(Array.Empty<string>());
        Assert.Equal("", block.Render());
    }

    [Fact]
    public void When_you_have_multiple_columns_they_can_be_listed_horizontally_and_comma_separated()
    {
        var block = GetColumnBlock(new[] {"First", "Second", "Third", "Fourth"});
        Assert.Equal("First, Second, Third, Fourth", block.Render());
    }
}