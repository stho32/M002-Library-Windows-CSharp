namespace SqlFormat.BL.ColumnBlocks;

public class HorizontalColumnBlock : ColumnBlockBase
{
    public HorizontalColumnBlock(string[] columns) : base(columns)
    {
    }

    public override string Render()
    {
        var textEditor = new TextEditor();

        var columns = string.Join(", ", Columns);
        textEditor.AddRow(columns);
    
        return textEditor.ToString();
    }
}