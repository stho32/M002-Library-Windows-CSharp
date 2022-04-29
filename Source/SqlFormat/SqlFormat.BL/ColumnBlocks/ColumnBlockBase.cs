using SqlFormat.Interfaces;

namespace SqlFormat.BL.ColumnBlocks;

public abstract class ColumnBlockBase : IRenderedText
{
    protected readonly string[] Columns;

    protected ColumnBlockBase(string[] columns)
    {
        Columns = columns;
    }

    public abstract string Render();
}