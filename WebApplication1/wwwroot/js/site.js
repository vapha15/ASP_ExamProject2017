// Write your JavaScript code.

    $(document).ready(function () {
        $('#bootstrap-table').bdt();
    });


/* particlesJS.load(@dom-id, @path-json, @callback (optional)); */
particlesJS.load('particles-js', 'assets/particles.json', function () {
    console.log('callback - particles.js config loaded');
});