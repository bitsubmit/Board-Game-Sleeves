$(function () {
    $("#sliderWidth").slider({
        max: 800,
        min: 0,
        change: function () {
            var widthVal = $('#sliderWidth').slider('value');
            $('#area').css('width', widthVal);
            $('#area').css('height', widthVal*1.59);
        }
    });
    $('#scale').click(function () {
        initScale();
        makeSleeves();
        toggleStep();
    });
    $('#reset').click(function () {
        pixPerMm = null;
        destorySleeves();
        toggleStep();
    });
    $('#findSleeves').click(function () {
        var width = $('#area').css('width').slice(0, -2);
    });
}); //JQueryDocReady end

//Calibartion functions
const creditWidth = 53.98;
var pixPerMm = null;

function initScale() {
    var scaleWidthPix = $('#area').css('width').slice(0, -2);
    pixPerMm = scaleWidthPix / creditWidth;
}
function mmToPix(mm) {
    return (pixPerMm * mm).toPrecision(4);
}
function pixToMm(pix) {
    return (pix / pixPerMm).toPrecision(4);
}

//Change step function
function toggleStep() {
    $('#reset').toggle();
    $('#firstStep').toggle();
    $('#secondStep').toggle();
    $('#area').toggle();
    $('#sliderWidth').toggle();
    $('#sleeves').toggle();
}

var cardTypes;
$.ajax({
    type: "get",
    url: "../admin/cardtypes/getCardTypes",
    data: "data",
    dataType: "json",
    success: function (response) {
        cardTypes = response;
    }
});

function makeSleeves() {
    var parent = document.getElementById('sleeves');
    for (var cardType in cardTypes) {
        var sleeve = document.createElement('div');
        sleeve.id = cardType;
        sleeve.setAttribute('style', 'height:' + mmToPix(cardTypes[cardType].y) + 'px;' + 'width:' + mmToPix(cardTypes[cardType].x) + 'px;');
        sleeve.className = 'sleeve';
        $(parent).append(sleeve);
    }
}
function destorySleeves() {
    var sleeves = document.getElementById("sleeves");
    while (sleeves.firstChild) {
        sleeves.removeChild(sleeves.firstChild);
    }
}