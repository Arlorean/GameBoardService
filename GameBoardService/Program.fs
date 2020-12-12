open Saturn

let uiRouter = router {
    get "/" (Sudoku.svgView "")    
    getf "/sudoku/%s.svg" Sudoku.svgView     
}

let appRouter = router {
    forward "" uiRouter
}

let myApplication = application {
    use_router appRouter
}

run myApplication
