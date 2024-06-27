document.addEventListener('DOMContentLoaded', function () {
    $('#select_date').on('change', function () {
        var apiURL = '/api/EventoControler/' + $('#select_date').val();
        $('#button_create').prop(
            "disabled",
            true
        );
        $.ajax({
            url: apiURL,
            method: 'GET',
            success: function (data) {
                if (data) {
                    alert("La fecha introducida ya esta reservada");
                }
                $('#button_create').prop(
                    "disabled",
                    data
                );
            },
            error: function (jqXHR, textStatus, errorThrown) {
                console.error('Error api evento:', textStatus, errorThrown);
            }
        });
    });
});