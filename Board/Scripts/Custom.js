function startTime() {
    var today = new Date();
    var h = today.getHours();
    var m = today.getMinutes();
    var s = today.getSeconds();
    m = checkTime(m);
    s = checkTime(s);
    document.getElementById('clock').innerHTML =
        h + ":" + m;
    var t = setTimeout(startTime, 500);
}
function checkTime(i) {
    if (i < 10) { i = "0" + i };  // add zero in front of numbers < 10
    return i;
}

var apiURL = "http://localhost:12892/api/WeatherAPI"
var timer = setInterval(getFunction, 10000);
function getFunction() {
    $.get(apiURL, function (data, status) {
        console.log(data);
        var dayOne = data[0];
        var icon = dayOne.Icon;
        var iconHtml = document.getElementById('icon1');
        iconHtml.setAttribute('class', icon);
        var temp = dayOne.Temp;
        var tempHtml = document.getElementById('temp1');
        tempHtml.innerHTML = temp;
        for (i = 1; i <= data.length; i++) {
            var iconHtml = document.getElementById('icon' + i)
            var icon = data[i].Icon;
            console.log(icon);
            iconHtml.setAttribute('class', icon);
            var tempLow = data[i].TempLow;
            var tempHigh = data[i].TempHigh;
            console.log(tempLow)
            var tempsHtml = document.getElementById('temps' + i);
            tempsHtml.innerHTML = "test";
        }
    });
};
