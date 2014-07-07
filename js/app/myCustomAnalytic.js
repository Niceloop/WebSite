//in navbar
$('#demo').on('click', function () {
    ga('send', 'event', 'button', 'click', 'demo');
});

$('#register-app').on('click', function () {
    ga('send', 'event', 'button', 'click', 'register');
});

$('#login-app').on('click', function () {
    ga('send', 'event', 'button', 'click', 'login');
});

// คลิกเลือก package
$('a.register-390').on('click', function () {
    ga('send', 'event', 'button', 'click', 'register-390');
});

$('a.register-590').on('click', function () {
    ga('send', 'event', 'button', 'click', 'register-590');
});

$('a.register-890').on('click', function () {
    ga('send', 'event', 'button', 'click', 'register-890');
});