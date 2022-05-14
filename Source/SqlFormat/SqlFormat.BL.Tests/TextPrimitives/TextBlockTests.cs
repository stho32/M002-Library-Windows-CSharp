using SqlFormat.BL.TextPrimitives;
using Xunit;

namespace SqlFormat.BL.Tests.TextPrimitives;

public class TextBlockTests
{
    [Fact]
    public void construction_test()
    {
        var textblock = new TextBlock(1, 2, new[] {"Hello world"});
        
        Assert.Equal(1, textblock.X);
        Assert.Equal(2, textblock.Y);
    }

    [Fact]
    public void The_height_of_the_content_is_determined_by_the_count_of_rows()
    {
        var textblock1 = new TextBlock(1, 2, new[] {"Hello world"});
        Assert.Equal(1, textblock1.Height);
        var textblock2 = new TextBlock(1, 2, new[] {"Hello world", "Another line"});
        Assert.Equal(2, textblock2.Height);
    }
    
    [Fact]
    public void The_width_of_the_content_is_determined_by_the_longest_row()
    {
        var textblock1 = new TextBlock(1, 2, new[] {"Hello world"});
        Assert.Equal(11, textblock1.Width);
        
        var textblock2 = new TextBlock(1, 2, new[] {"Hello world", "Another line"});
        Assert.Equal(12, textblock2.Width);
    }

    [Fact]
    public void The_height_of_an_empty_textblock_is_0()
    {
        var textblock1 = new TextBlock(1, 2, Array.Empty<string>());
        Assert.Equal(0, textblock1.Height);
    }

    [Fact]
    public void The_width_of_an_empty_textblock_is_0()
    {
        var textblock1 = new TextBlock(1, 2, Array.Empty<string>());
        Assert.Equal(0, textblock1.Width);
    }
}