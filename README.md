# Game Board Service

A web service to return an **svg** file for a given board game given the url as the board state.

This is currently hosted on Azure at https://gameboardservice.azurewebsites.net/.

## Chess

The chess URL uses the [Forsyth–Edwards Notation](https://en.wikipedia.org/wiki/Forsyth%E2%80%93Edwards_Notation) where White pieces are designated using upper-case letters ("PNBRQK") while black pieces use lowercase ("pnbrqk"). Empty squares are noted using digits 1 through 8 (the number of empty squares), and "/" separates ranks. The ranks are ordered from 8 to 1 (top to bottom) in the URL:

```
/chess/<rank8>/<rank7>/<rank6>/<rank5>/<rank4>/<rank3>/<rank2>/<rank1>.svg
```

e.g.

```
/chess/rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR.svg
/chess/r1bq3k/pp2bp1r/2n1p2B/2pnP3/3P4/2PB1N1Q/PP4P1/RN3RK1.svg
```

display the following SVG images:

<img src="https://gameboardservice.azurewebsites.net/chess/rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR.svg" width="200" />
<img src="https://gameboardservice.azurewebsites.net/chess/r1bq3k/pp2bp1r/2n1p2B/2pnP3/3P4/2PB1N1Q/PP4P1/RN3RK1.svg" width="200" />

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

<img src="https://gameboardservice.azurewebsites.net/sudoku/7..25..98..6....1....61.3..9....1.......8.4.9..75.28.1.94..3.......4923.61.....4..svg" width="200" />
<img src="https://gameboardservice.azurewebsites.net/sudoku/004200030002104005160900000835000060000000000040000378000007019500602700090003200.svg" width="200" />

Here are some [more examples](http://forum.enjoysudoku.com/patterns-game-results-t6291.html).

Also see my [SudokuSolver](https://github.com/Arlorean/SudokuSolver) repository for more test cases that use this service in the [README.md](https://github.com/Arlorean/SudokuSolver/blob/master/README.md#performance) file.
