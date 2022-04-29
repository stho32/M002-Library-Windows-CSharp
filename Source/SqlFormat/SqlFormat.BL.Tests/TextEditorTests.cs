using Xunit;

namespace SqlFormat.BL.Tests;

public class TextEditorTests
{
    [Fact]
    public void A_list_of_things_can_be_inserted_as_rows()
    {
        var textEditor = new TextEditor();
        string[] someRows = {
            "Hello",
            "World"
        };
        
        textEditor.AddRows(someRows);
        var rows = textEditor.GetRows();

        Assert.Equal(@"Hello", rows[0]); 
        Assert.Equal("World", rows[1]);
    }

    [Fact]
    public void A_word_can_be_inserted_at_a_more_or_less_random_position()
    {
        var textEditor = new TextEditor();

        textEditor.AddRow("====");
        textEditor.AddRow("====");

        textEditor.InsertTextAt(1, 2, "SELECT ");
        var rows = textEditor.GetRows();

        Assert.Equal("====", rows[0]);
        Assert.Equal("==SELECT ==", rows[1]);
    }

    [Fact]
    public void A_selected_list_of_Rows_can_be_indented_by_spaces()
    {
        var textEditor = new TextEditor();
        
        textEditor.AddRow("====");
        textEditor.AddRow("====");
        textEditor.AddRow("====");
        textEditor.AddRow("====");

        textEditor.IndentRowsUsingSpaces(1, 2, 4);

        var rows = textEditor.GetRows();
        
        Assert.Equal("====", rows[0]);
        Assert.Equal("    ====", rows[1]);
        Assert.Equal("    ====", rows[2]);
        Assert.Equal("====", rows[3]);
    }
}