module Sudoku

open Giraffe
open GiraffeViewEngine

let svg = tag "svg"
let text = tag "text"
let rect = tag "rect"

let square (r:int) (c:int) (size:int) (width:float) =
    rect [
        attr "x" $"{c*size}"
        attr "y" $"{r*size}"
        attr "width" $"{size}"
        attr "height" $"{size}"
        attr "fill" "none"
        attr "stroke" "currentColor"
        attr "stroke-width" $"{width}"
    ] []

let number (r:int) (c:int) (size:int) (v:string) =
    text [
        attr "x" $"{c*size+size/2}"
        attr "y" $"{r*size+size/2}"
        if ["0";"."] |> List.contains v then attr "fill" "none"
    ] [ str v ]

let numbers (problem:string) = seq {
    for r in 0..8 do
        for c in 0..8 do
            let i = c+(r*8)
            if (problem = null || i >= problem.Length)
            then number r c 10 " "
            else number r c 10 problem.[i..i]
}

let squares = seq {
    for r in 0..8 do
        for c in 0..8 do
            square r c 10 0.5
}

let bigSquares = seq {
    for r in 0..2 do
        for c in 0..2 do
            square r c 30 1.0
}

let generateSvg problem =
    svg [
        attr "viewBox" "-0.5 -0.5 91 91"
        attr "xmlns" "http://www.w3.org/2000/svg"
        attr "xmlns:xlink" "http://www.w3.org/1999/xlink"
    ] (seq {
        style [] [
            rawText "text { font: 7px Verdana, sans-serif; text-anchor: middle; alignment-baseline: central; }"
        ]
        yield! squares
        yield! numbers problem
        yield! bigSquares
    } |> Seq.toList)

let svgView problem = 
    htmlView (generateSvg problem)
