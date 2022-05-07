# Requirements

- An sql formatter is a printing engine for text. 
  - [ ] There are template components. 
  - [ ] These components are created and then during the first stage of the rendering process they are translated into text primitives. 
  - [ ] In the second stage the primitives are talking to each other to arrange themselves against each other and the screen width.
  - [ ] In the third stage the primitives are simply combined to text.

- [ ] The input should be presented as text. The engine splits the text, parses it and then formats the results.


## Example DECLARE 

- [ ] First Stage
  - [ ] There is an object that represents a declare statement
  - [ ] The object renders down to an ITextBlock that represents the complete statement
  - [ ] The ITextBlock contains a sequencial list of ITextBlocks representing DECLARE, space, VariableName, space, DATATYPE

- [ ] Second Stage
  - [ ] The recursive order of the TextBlocks makes it necessary to ask every child block for its size and change the starting coordinates of the child and height and with of the parent TextBlock. 
  - [ ] If the DECLARE is a block with multiple vertically ordered declarations the statements can be aligned against each other. All the DataTypes should be aligned above each other. Tabular.

- [ ] Third Stage
  - [ ] The TextBlocks are simply rendered onto a text canvas. They are more or less just put down into a buffer and converted to the matching string list.

- [ ] Every part of a text is described as a ITextBlock.
  - [ ] an ITextBlock has a height, width and a content.
  - [ ] an ITextBlock has an x and a y coordinate.

- [ ] There is something that is described as an ITextCanvas.
  - [ ] an ITextCanvas is a canvas on which ITextBlocks are drawn.
  - [ ] TextBlocks are therein simply replacing existing content by their own content.



- [ ] Be able to format the following SQL elements
  - [ ] columns which are listed horizontally
  - [ ] columns which are listed vertically
  - [ ] SELECT clause
    - [ ] columns with name
    - [ ] columns with case statements
    - [ ] columns with subselects
    - [ ] columns with function calls
  - [ ] FROM Table/View
  - [ ] FROM with LEFT JOIN
  - [ ] FROM with RIGHT JOIN
  - [ ] FROM with CROSS JOIN
  - [ ] FROM with LEFT HASH JOIN 
  - [ ] FROM with JOIN
  - [ ] WHERE clauses
  - [ ] WHERE clauses with AND
  - [ ] WHERE clauses with OR
  - [ ] UNION ALL
  - [ ] ORDER BY
  - [ ] GROUP BY
  - [ ] combinded WHERE expressions with AND and OR
  - [ ] INSERT with VALUES
  - [ ] INSERT with SELECT
  - [ ] UPDATE
  - [ ] UPDATE WHERE
  - [ ] UPDATE FROM 
  - [ ] using aliases for columns and tables
  - [ ] CREATE VIEW
  - [ ] ALTER VIEW
  - [ ] GO
  - [ ] CREATE FUNCTION
  - [ ] ALTER FUNCTION
  - [ ] DROP FUNCTION
  - [ ] CREATE PROCEDURE
  - [ ] DROP PROCEDURE
  - [ ] ALTER PROCEDURE
  - ...


