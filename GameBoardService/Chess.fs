module Chess

open Giraffe.ViewEngine
open Svg

let asciiToUnicode =
    dict [
        ('p', '♟'); ('r', '♜'); ('n', '♞'); ('b', '♝'); ('q', '♛'); ('k', '♚');
        ('P', '♙'); ('R', '♖'); ('N', '♘'); ('B', '♗'); ('Q', '♕'); ('K', '♔'); 
    ]

let square (r:int) (c:int) =
    let className = if (r%2+c)%2 = 0 then "white" else "black"
    rect [
        attr "x" $"{c}"
        attr "y" $"{r}"
        attr "width" "1"
        attr "height" "1"
        attr "class" $"{className}"
    ] []

let piece (r:int) (c:int) (v:string) =
    text [
        attr "x" $"{float c+0.5}"
        attr "y" $"{float r+0.5}"
    ] [ str v ]

let squares = seq {
    for r in 0..7 do
        for c in 0..7 do
            square r c
}

let pieces (ranks:string[]) = seq {
    for r in 0..ranks.Length-1 do
        let rank = ranks.[r]
        let mutable c = 0
        while c < 8 do
            match rank.[c] with
            | n when n>='0' && n<='9' ->
                c <- c + (int n)
            | p ->               
                piece r c (string asciiToUnicode.[p])
                c <- c + 1
}

let outline =
    let d = 0.02
    rect [
        attr "x" $"{d*0.5}"
        attr "y" $"{d*0.5}"
        attr "width" $"{8.0-d}"
        attr "height" $"{8.0-d}"
        attr "fill" "none"
        attr "stroke" "currentColor"
        attr "stroke-width" $"{d}"
    ] []


let styles =
    style [] [
        rawText "text { font-size: 0.9px; font-family: -apple-system,system-ui,Segoe UI,Roboto,Ubuntu,Cantarell,Noto Sans,sans-serif,BlinkMacSystemFont,Helvetica Neue,sans-serif; text-anchor: middle; alignment-baseline: central; }"
        rawText ".white { fill: white; stroke: none; }"
        rawText ".black { fill: silver; stroke: none; }"
    ]

let generateSvg (ranks:string[]) =
    svg [
        attr "viewBox" "0 0 8 8"
        attr "xmlns" "http://www.w3.org/2000/svg"
        attr "xmlns:xlink" "http://www.w3.org/1999/xlink"
    ] (seq {
        yield styles
        yield! squares
        yield! pieces ranks
        yield outline
    } |> Seq.toList)

/// Generate an SVG chessboard using the Forsyth–Edwards Notation (FEN)
/// https://en.wikipedia.org/wiki/Forsyth%E2%80%93Edwards_Notation
let svgView (r1,r2,r3,r4,r5,r6,r7,r8) = 
    Views.svgView (generateSvg [| r1; r2; r3; r4; r5; r6; r7; r8 |])
