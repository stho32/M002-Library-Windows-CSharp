using System.Text;
using SqlFormat.Interfaces;
using Xunit;

namespace SqlFormat.BL.Tests;

public class SequenciallyRenderedTextTests
{
    [Fact]
    public void One_element_is_just_rendered_as_the_element()
    {
        var text = new SequenciallyTextRenderer();
        text.Add(new TextRenderer("Hello"));
        text.Add(new TextRenderer(" "));
        text.Add(new TextRenderer("World"));
        
        Assert.Equal("Hello World", text.Render());
    }
}

public class SequenciallyTextRenderer : IRenderedTextCollection, ITextRenderer
{
    private List<ITextRenderer> _texts = new();
    
    public ITextRenderer[] Render()
    {
        StringBuilder builder = new StringBuilder();
        
        foreach (var text in _texts)
        {
            builder.Append(text.Render());
        }

        return builder.ToString();
    }

    public void Add(ITextRenderer textRenderer)
    {
        _texts.Add(textRenderer);
    }
}

public class RenderedTextTests
{
    [Fact]
    public void A_simple_text_is_represented_by_its_content()
    {
        var text = new TextRenderer("HelloWorld");
        Assert.Equal("HelloWorld", text.Render());
    }
}

public class TextRenderer : ITextRenderer
{
    private readonly string _content;

    public TextRenderer(string content)
    {
        _content = content;
    }

    public string Render()
    {
        return _content;
    }
}

public class ColumnTests
{
    [Fact]
    public void A_simple_column_is_simply_itself()
    {
        var column = new Column("Id");
        Assert.Equal("Id", column.Render());
    }

    [Fact]
    public void A_column_with_an_alias_is_rendered_with_AS()
    {
        var column = new Column("Id", "PrimaryKey");
        Assert.Equal("Id AS PrimaryKey", column.Render());
    }

    [Fact]
    public void UnderTheSpell()
    {
        
    }

}


public class Column : ITextRenderer
{
    private readonly string _expression;
    private readonly string _alias;

    public Column(string expression, string alias = "")
    {
        _expression = expression;
        _alias = alias;
    }

    public string Render()
    {
        if (string.IsNullOrEmpty(_alias))
            return _expression;

        return $"{_expression} AS {_alias}";
    }
}