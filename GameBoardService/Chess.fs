module Chess

open Giraffe.ViewEngine
open Svg
open System

/// Each SVG chess piece is 45x45
let sz d = float d*45.0

/// Original chess piece artwork by Cburnett
/// (https://commons.wikimedia.org/wiki/Category:SVG_chess_pieces)
let definitions =
    rawText (System.IO.File.ReadAllText "defs.xml")

let styles = 
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

let whiteSquares =
    rect [
        attr "class" "w"
        attr "width" $"{sz 8}"
        attr "height" $"{sz 8}"
    ] []
    
let blackSquare (r:int) (c:int) =
    rect [
        attr "class" "b"
        attr "x" $"{sz c}"
        attr "y" $"{sz r}"
        attr "width" $"{sz 1}"
        attr "height" $"{sz 1}"
    ] []

let blackSquares = seq {
    for r in 0..7 do
        for c in 0..7 do
            if (r+c)%2 = 1 then 
                blackSquare r c
}

let charToId c =
    if Char.IsLower c
    then "b"+(c |> string)
    else "w"+(Char.ToLower c |> string)

let piece (r:int) (c:int) (p:char) =
    _use [
        attr "xlink:href" $"#{(charToId p)}"
        attr "x" $"{sz c}"
        attr "y" $"{sz r}"
    ]

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
                yield piece r c p
                c <- c + 1
}

let outline =
    rect [
        attr "x" "0.5"
        attr "y" "0.5"
        attr "width" $"{(sz 8)-1.0}"
        attr "height" $"{(sz 8)-1.0}"
        attr "fill" "none"
        attr "stroke" "currentColor"
        attr "stroke-width" "1"
    ] []

let generateSvg (ranks:string[]) =
    svg [
        attr "viewBox" $"0 0 {sz 8} {sz 8}"
        attr "xmlns" "http://www.w3.org/2000/svg"
        attr "xmlns:xlink" "http://www.w3.org/1999/xlink"
    ] (seq {
        yield definitions
        yield styles
        yield whiteSquares
        yield! blackSquares
        yield! pieces ranks
        yield outline
    } |> Seq.toList)

/// Generate an SVG chessboard using the Forsyth–Edwards Notation (FEN)
/// https://en.wikipedia.org/wiki/Forsyth%E2%80%93Edwards_Notation
let svgView (r1,r2,r3,r4,r5,r6,r7,r8) = 
    Views.svgView (generateSvg [| r1; r2; r3; r4; r5; r6; r7; r8 |])
