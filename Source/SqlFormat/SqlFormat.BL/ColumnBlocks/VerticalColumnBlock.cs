namespace SqlFormat.BL.ColumnBlocks;

public class VerticalColumnBlock : ColumnBlockBase
{
    public VerticalColumnBlock(string[] columns) : base(columns)
    {
    }

    public override string Render()
    {
        return string.Join("," + Environment.NewLine, Columns);
    }
}