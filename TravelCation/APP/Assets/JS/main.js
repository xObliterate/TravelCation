document.addEventListener('DOMContentLoaded', function () {
    var dd = document.querySelectorAll('.dropdown-trigger');
    var instances = M.Dropdown.init(dd, {
        inDuration: 300,
        outDuration: 225,
        coverTrigger: false,
        alignment: 'right',
    });
});

document.addEventListener('DOMContentLoaded', function () {
    var slider = document.querySelectorAll('.slider');
    var instances = M.Slider.init(slider, {
        indicators: false,
        height: 500,
        transition: 500,
        interval: 6000
    });
});

