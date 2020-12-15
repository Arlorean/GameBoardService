# Game Board Service

A web service to return an **svg** file for a given board game given the url as the board state.

This is currently hosted on Azure at https://gameboardservice.azurewebsites.net/.

## Sudoku

```
/sudoku/<81 characters>.svg
```

Specify the <81 characters> in the URL corresponsing to the 9x9 grid of the sudoku puzzle. Blanks squares can be represented as space (' '), zero ('0') or period ('.').

e.g.
```
/sudoku/7..25..98..6....1....61.3..9....1.......8.4.9..75.28.1.94..3.......4923.61.....4..svg
/sudoku/004200030002104005160900000835000060000000000040000378000007019500602700090003200.svg
```

display the following SVG images:

<img src="https://gameboardservice.azurewebsites.net//sudoku/7..25..98..6....1....61.3..9....1.......8.4.9..75.28.1.94..3.......4923.61.....4..svg" width="200" />
<img src="https://gameboardservice.azurewebsites.net//sudoku/004200030002104005160900000835000060000000000040000378000007019500602700090003200.svg" width="200" />

Here are some [more examples](http://forum.enjoysudoku.com/patterns-game-results-t6291.html).

Also see my [SudokuSolver](https://github.com/Arlorean/SudokuSolver) repository for more test cases that use this service in the [README.md](https://github.com/Arlorean/SudokuSolver/blob/master/README.md#performance) file.
