module Chess

open Giraffe.ViewEngine
open Svg

let asciiToUnicode =
    dict [
        ('p', '♟'); ('r', '♜'); ('n', '♞'); ('b', '♝'); ('q', '♛'); ('k', '♚');
        ('P', '♙'); ('R', '♖'); ('N', '♘'); ('B', '♗'); ('Q', '♕'); ('K', '♔'); 
    ]

let styles = seq {
    defs [] [
        style [] [
            rawText "@import url('https://fonts.googleapis.com/css?family=Gothic+A1:400');"
        ]
    ]
    style [] [
        rawText "text {\
            font-size: 1px;\
            font-family: 'Gothic A1', sans-serif;\
            text-anchor: middle;\
        }"
        rawText ".b {\
            fill: silver;\
            stroke: none;\
        }"
        rawText ".w {\
            fill: white;\
            stroke: none;\
        }"
    ]
}

let whiteSquares =
    rect [
        attr "class" "w"
        attr "width" "8"
        attr "height" "8"
    ] []
    
let blackSquare (r:int) (c:int) =
    rect [
        attr "class" "b"
        attr "x" $"{c}"
        attr "y" $"{r}"
        attr "width" "1"
        attr "height" "1"
    ] []

let blackSquares = seq {
    for r in 0..7 do
        for c in 0..7 do
            if (r+c)%2 = 1 then 
                blackSquare r c
}

let piece (r:int) (c:int) (v:string) =
    text [
        attr "x" $"{float c+0.5}"
        attr "y" $"{float r+0.88}"
    ] [ str v ]

let pieces (ranks:string[]) = seq {
    for r in 0..ranks.Length-1 do
        let rank = ranks.[r]
        let mutable c = 0
        for i in 0..rank.Length-1 do
            match rank.[i] with
            | n when n>='0' && n<='9' ->
                let s = (int (string n))
                c <- c + s
            | p ->               
                yield piece r c (string asciiToUnicode.[p])
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

let generateSvg (ranks:string[]) =
    svg [
        attr "viewBox" "0 0 8 8"
        attr "xmlns" "http://www.w3.org/2000/svg"
        attr "xmlns:xlink" "http://www.w3.org/1999/xlink"
    ] (seq {
        yield! styles
        yield whiteSquares
        yield! blackSquares
        yield! pieces ranks
        yield outline
    } |> Seq.toList)

/// Generate an SVG chessboard using the Forsyth–Edwards Notation (FEN)
/// https://en.wikipedia.org/wiki/Forsyth%E2%80%93Edwards_Notation
let svgView (r1,r2,r3,r4,r5,r6,r7,r8) = 
    Views.svgView (generateSvg [| r1; r2; r3; r4; r5; r6; r7; r8 |])
