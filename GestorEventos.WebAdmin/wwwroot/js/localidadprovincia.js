﻿document.addEventListener('DOMContentLoaded', function () {
    $('#select_provincias').on('change', function () {
        var provinciaId = $(this).val();

        // Asegúrate de cambiar la URL a la de tu API
        var apiURL = '/api/localidad/GetAllByID/' + provinciaId;

        $.ajax({
            url: apiURL,
            method: 'GET',
            success: function (data) {
                var $selectLocalidades = $('#select_localidades');
                $selectLocalidades.empty(); // Limpia las opciones actuales

                data.forEach(function (localidad) {
                    $selectLocalidades.append(new Option(localidad.nombre, localidad.idLocalidad));
                });
            },
            error: function (jqXHR, textStatus, errorThrown) {
                console.error('Error al cargar localidades:', textStatus, errorThrown);
            }
        });
    });
});