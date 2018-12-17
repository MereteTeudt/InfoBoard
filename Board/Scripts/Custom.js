function startTime() {
    var today = new Date();
    var day = today.getDay();
    var date = today.getDate();
    var month = today.getMonth();
    var year = today.getFullYear();
    var h = today.getHours();
    var m = today.getMinutes();
    var s = today.getSeconds();
    m = checkTime(m);
    s = checkTime(s);
    if (date < 10) {
        date = "0" + date;
    }
    if (month < 10) {
        month = "0" + month;
    }
    if (h < 10) {
        h = "0" + h;
    }
    if (m < 10) {
        m = "0" + m;
    }

    var weekday = new Array(7);
    weekday[0] = "Søndag";
    weekday[1] = "Mandag";
    weekday[2] = "Tirsdag";
    weekday[3] = "Onsdag";
    weekday[4] = "Torsdag";
    weekday[5] = "Fredag";
    weekday[6] = "Lørdag";

    document.getElementById('clock').innerHTML =
        h + ":" + m + "<br>" + weekday[day] + "<br>" + date + "/" + month + "-" + year;
    var t = setTimeout(startTime, 500);
}


var dateTimeString = document.getElementById("vacationDate").innerHTML;
if (dateTimeString) {
    var date = dateTimeString.substring(0, 2);
    var month = dateTimeString.substring(3, 5);
    var year = dateTimeString.substring(6, 10);
    var time = dateTimeString.substring(11, 19);
    var formatDate = year + "-" + month + "-" + date + " " + time;
    var countdownDate = new Date(formatDate).getTime();
    var x = setInterval(function () {
        var now = new Date().getTime();
        var interval = countdownDate - now;

        var days = Math.floor(interval / (1000 * 60 * 60 * 24));
        var hours = Math.floor((interval % (1000 * 60 * 60 * 24)) / (1000 * 60 * 60));
        var minutes = Math.floor((interval % (1000 * 60 * 60)) / (1000 * 60));
        var seconds = Math.floor((interval % (1000 * 60)) / 1000);

        document.getElementById("vacationCountdown").innerHTML = days + "d " + hours + "t "
            + minutes + "m " + seconds + "s ";

        if (interval < 0) {
            clearInterval(x);
            document.getElementById("vacationCountdown").innerHTML = "FERIE!";
        }
    }, 1000);
}

function checkTime(i) {
    if (i < 10) { i = "0" + i }; 
    return i;
}
function resetAtMidnight() {
    console.log('run');
    var now = new Date();
    var night = new Date(
        now.getFullYear(),
        now.getMonth(),
        now.getDate() + 1, 
        0, 0, 0 
    );
    var msToMidnight = night.getTime() - now.getTime();
    console.log(msToMidnight);
    setTimeout(function () {
        console.log('test');
        reloadPage();
        resetAtMidnight();
    }, msToMidnight);
}
function reloadPage() {
    console.log('reload');
    location.reload(true);
};

var apiURL = "http://localhost:12892/api/WeatherAPI"
var timer = setInterval(getFunction, 600000);

function getFunction() {
    $.get(apiURL, function (data, status) {
        console.log(data);
        var dayOne = data[0];
        var icon = dayOne.Icon;
        var iconHtml = document.getElementById('iconNow');
        iconHtml.setAttribute('class', icon);
        var temp = dayOne.Temp;
        var tempHtml = document.getElementById('tempNow');
        tempHtml.innerHTML = temp;
        for (i = 1; i < 5; i++) {
            var iconHtml = document.getElementById('icon' + i);
            var icon = data[i].Icon;
            iconHtml.setAttribute('class', icon);
            var tempLow = data[i].TempLow;
            var tempHigh = data[i].TempHigh;
            var tempsId = 'temps' + i;
            var tempsHtml = document.getElementById('temps' + i);
            tempsHtml.innerHTML = tempLow + '<i class="wi-celsius"></i> / ' + tempHigh + '<i class="wi-celsius"></i>';
        }
    });
};
