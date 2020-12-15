open Saturn

let uiRouter = router {
    get "/" (Chess.svgView ("rnbqkbnr","pppppppp","8","8","8","8","PPPPPPPP","RNBQKBNR"))    
    getf "/sudoku/%s.svg" Sudoku.svgView     
    getf "/chess/%s/%s/%s/%s/%s/%s/%s/%s.svg" Chess.svgView     
}

let appRouter = router {
    forward "" uiRouter
}

let myApplication = application {
    use_router appRouter
}

run myApplication
