open Saturn

let uiRouter = router {
    get "/" (Chess.svgView ("r1bq3k","pp2bp1r","2n1p2B","2pnP3","3P4","2PB1N1Q","PP4P1","RN3RK1"))    
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
