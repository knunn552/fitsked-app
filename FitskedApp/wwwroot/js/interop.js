window.blinkOnNullInput = function (elementId) {
    const element = document.getElementById(elementId);
    if (element) {
        element.classList.add('blinking-border');
        setTimeout(() => {
            element.classList.remove('blinking-border');
        }, 3000);
    }
};
