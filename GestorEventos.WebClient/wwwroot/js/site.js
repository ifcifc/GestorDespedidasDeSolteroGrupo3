// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(document).ready(() => {
    $(function () {
        $('[data-toggle="tooltip"]').tooltip();
    });
    $('#tooltipSesion').tooltip('show');
    $('#tooltipSesion').on('hidden.bs.tooltip', () => {
        $('#tooltipSesion').tooltip('disable');
    });
    setTimeout(() => {
        $('#tooltipSesion').tooltip('hide');
    }, 1300);
});