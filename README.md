# Game Board Service

A web service to return an **svg** file for a given board game given the url as the board state for the following game types:

- [Chess](#chess)
- [Sudoku](#sudoku)

The service is implemented in [F#](https://fsharp.org/) using [Saturn](https://saturnframework.org/) and [Giraffe](https://giraffe.wiki/), and is hosted live on Azure at `https://gameboardservice.azurewebsites.net/<game-type>/<board-state>.svg`.

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

<a href="https://gameboardservice.azurewebsites.net/chess/rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR.svg"><img src="https://gameboardservice.azurewebsites.net/chess/rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR.svg?" width="200" /></a>
<a href="https://gameboardservice.azurewebsites.net/chess/r1bq3k/pp2bp1r/2n1p2B/2pnP3/3P4/2PB1N1Q/PP4P1/RN3RK1.svg"><img src="https://gameboardservice.azurewebsites.net/chess/r1bq3k/pp2bp1r/2n1p2B/2pnP3/3P4/2PB1N1Q/PP4P1/RN3RK1.svg?" width="200" /></a>

Originally this used the Unicode symbols for chess pieces but they varied so much in quality and metrics across all the platforms that embedding SVG definitions of each of the chess pieces was the best way to get a consistent rendering between platforms. Also when an SVG is used as an IMG in HTML external [references to fonts are ignored](https://css-tricks.com/using-custom-fonts-with-svg-in-an-image-tag/#the-image-tag) for security reasons making it always use the system font.

The SVG Chess Pieces were created by [jurgenwesterhof](https://en.wikipedia.org/wiki/User:Jurgenwesterhof) (adapted from work of [Cburdett](https://en.wikipedia.org/wiki/User:Cburnett)) [CC BY-SA 3.0](https://creativecommons.org/licenses/by-sa/3.0) and taken from [wikimedia.org](https://commons.wikimedia.org/wiki/Category:SVG_chess_pieces). The SVG was then minified and hand optimized turning attributes into class names to reduce the size further.

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

<a href="https://gameboardservice.azurewebsites.net/sudoku/7..25..98..6....1....61.3..9....1.......8.4.9..75.28.1.94..3.......4923.61.....4..svg"><img src="https://gameboardservice.azurewebsites.net/sudoku/7..25..98..6....1....61.3..9....1.......8.4.9..75.28.1.94..3.......4923.61.....4..svg" width="200" /></a>
<a href="https://gameboardservice.azurewebsites.net/sudoku/004200030002104005160900000835000060000000000040000378000007019500602700090003200.svg"><img src="https://gameboardservice.azurewebsites.net/sudoku/004200030002104005160900000835000060000000000040000378000007019500602700090003200.svg" width="200" /></a>

Here are some [more examples](http://forum.enjoysudoku.com/patterns-game-results-t6291.html).

Also see my [SudokuSolver](https://github.com/Arlorean/SudokuSolver) repository for more test cases that use this service in the [README.md](https://github.com/Arlorean/SudokuSolver/blob/master/README.md#performance) file.
