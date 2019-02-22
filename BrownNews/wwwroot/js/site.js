document.onload = function () {
    document.querySelectorAll('li.disabled a').forEach(a => a.removeAttribute('href'));
}();