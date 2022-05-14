using SqlFormat.BL.TextPrimitives;
using SqlFormat.Interfaces.TextPrimitives;
using Xunit;

namespace SqlFormat.BL.Tests.TextPrimitives;

public class TextCanvasTests 
{
    [Fact]
    public void An_empty_text_canvas_renders_down_to_nothing()
    {
        var canvas = new TextCanvas();
        var result = canvas.Render(Array.Empty<ITextBlock>());
        Assert.Empty(result);
    }

    [Fact]
    public void When_a_single_line_text_is_rendered_at_the_start_the_result_contains_the_text()
    {
        var canvas = new TextCanvas();

        var helloWorld = new TextBlock(0, 0, new[] {"Hello world"});
        
        var result = canvas.Render(new ITextBlock[] {helloWorld});
        
        Assert.Single(result);
        Assert.Equal("Hello world", result[0]);
    }

    [Fact]
    public void Spaces_are_padded_if_single_line_content_starts_on_column_x_and_there_is_no_content_yet()
    {
        var canvas = new TextCanvas();

        var helloWorld = new TextBlock(4, 0, new[] {"Hello world"});
        
        var result = canvas.Render(new ITextBlock[] {helloWorld});
        
        Assert.Single(result);
        Assert.Equal("    Hello world", result[0]);
    }
    
    [Fact]
    public void A_following_textblock_will_replace_characters_drawn_by_previous_blocks_if_they_overlapp()
    {
        var canvas = new TextCanvas();

        var testing = new TextBlock(6, 0, new[] {"Stefan"});
        var helloWorld = new TextBlock(0, 0, new[] {"Hello world"});
        
        var result = canvas.Render(new ITextBlock[]
        {
            helloWorld,
            testing
        });
        
        Assert.Single(result);
        Assert.Equal("Hello Stefan", result[0]);        
    }
}