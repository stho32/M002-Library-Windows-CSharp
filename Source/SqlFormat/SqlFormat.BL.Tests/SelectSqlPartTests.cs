using System.Text;
using SqlFormat.Interfaces;
using Xunit;

namespace SqlFormat.BL.Tests;

public class SelectSqlPartTests
{
    private ISqlPart GetSqlPart(string[] columns)
    {
        return new SelectSqlPart(columns);
    }
    
    [Fact]
    public void Formatting_a_basic_Select_command_works()
    {
        var command = GetSqlPart(new string[] {"*"});
        var result = command.Render();

        Assert.Equal(@"SELECT *".Trim(), result.Trim());
    }
    
    [Fact]
    public void When_formatting_multiple_columns_each_column_becomes_a_row()
    {
        var command = new SelectSqlPart(new string[]
        {
            "Id",
            "FirstName",
            "SurName",
            "Birthdate"
        });
        
        var result = command.Render();

        Assert.Equal(@"SELECT *".Trim(), result.Trim());
    }
}

public class RowBasedTextProcessorTests
{
    [Fact]
    public void A_list_of_things_can_be_inserted_as_rows()
    {
        Assert.True(false);
    }

    [Fact]
    public void The_content_of_the_editor_can_be_indented_by_a_single_word()
    {
        /*
         *  Word1,
         *  Word2
         * 
         *    =>
         * 
         *  SELECT Word1,
         *         Word2
         */
        Assert.True(false);
    }

    [Fact]
    public void A_selected_list_of_Rows_can_be_indented_by_spaces()
    {
        /*
         * indent lines 4-8 by 4 spaces... e.g.
         */
        Assert.True(false);
    }
}



