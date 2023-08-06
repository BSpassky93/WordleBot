
export function setClueColorOnLetter(id, clue) {
    var element = document.getElementById(id);

    switch (clue) {
        case 0: //Green
            element.style.backgroundColor = "#2E8B57";
            break;
        case 1: //Yellow
            element.style.backgroundColor = "#FFFF00";
            break;
        case 2: //White
            element.style.backgroundColor = "#808080";
            break;
    }
}