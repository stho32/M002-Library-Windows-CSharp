using SqlFormat.BL.ColumnBlocks;
using SqlFormat.Interfaces;
using Xunit;

namespace SqlFormat.BL.Tests.ColumnBlocks;

public class VerticalColumnBlockTests
{
    private ITextRenderer GetColumnBlock(string[] columns)
    {
        return new VerticalColumnBlock(columns);
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
    public void Multiple_columns_are_listed_vertically()
    {
        var block = GetColumnBlock(new[] {"First", "Second", "Third", "Fourth"});
        Assert.Equal(@"First,
Second,
Third,
Fourth", block.Render());
    }
}