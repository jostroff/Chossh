

function getFigure(markedFigure, getableFigure) {
    let squareToMove = $(getableFigure).parent();
    getableFigure.remove();
    squareToMove.append(markedFigure);
    unmark();
}

function checkToGet(marketFigure, getableFigure) {
    let currentSquareData = $(markedFigure).parent().attr('id').split('-').map(Number);
    let squareToMoveData = $(getableFigure).parent().attr('id').split('-').map(Number);

    if (currentSquareData[0] + 1 === squareToMoveData[0]) {
        if (currentSquareData[1] + 1 === squareToMoveData[1] || currentSquareData[1] - 1 === squareToMoveData[1]) {
            return true;
        }
    }

    return false;
}


