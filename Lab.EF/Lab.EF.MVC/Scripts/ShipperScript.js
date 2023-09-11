﻿$(document).ready(function () {
    // Manejar el clic en el botón "Editar" en la vista Index
    $(".edit-button").click(function () {
        var index = $(this).data("id");
        $("#companyName_" + index).hide();
        $("#editCompanyName_" + index).show();
        $("#editCompanyName_" + index).val($("#companyName_" + index).text());

        $("#phone_" + index).hide();
        $("#editPhone_" + index).show();
        $("#editPhone_" + index).val($("#phone_" + index).text());

        $(this).hide();
        $(".save-button[data-id=" + index + "]").show();
        $(".cancel-button[data-id=" + index + "]").show();
        $(".delete-button[data-id=" + index + "]").prop('disabled', true);
    });

    // Manejar el clic en el botón "Cancelar" en la vista Index
    $(".cancel-button").click(function () {
        var index = $(this).data("id");
        $("#companyName_" + index).show();
        $("#editCompanyName_" + index).hide();

        $("#phone_" + index).show();
        $("#editPhone_" + index).hide();

        $(".edit-button[data-id=" + index + "]").show();
        $(".save-button[data-id=" + index + "]").hide();
        $(".cancel-button[data-id=" + index + "]").hide();
        $(".delete-button[data-id=" + index + "]").prop('disabled', false);
    });

    // Manejar el clic en el botón "Guardar" en la vista Index
    $(".save-button").click(function () {
        var index = $(this).data("id");
        var companyName = $("#editCompanyName_" + index).val();
        var phone = $("#editPhone_" + index).val();
        var shipperId = $("#shipperId_" + index).val();

        if (companyName.length == 0) {
            Swal.fire('Error', 'El nombre de la compañía no puede estar vacio.', 'error');
            return;
        }

        if (companyName.length > 40) {
            Swal.fire('Error', 'El nombre de la compañía no puede exceder los 40 caracteres.', 'error');
            return;
        }

        if (!ValidacionServicio.EsNumeroTelefonoValido(phone)) {
            Swal.fire('Error', 'Número de teléfono no válido.', 'error');
            return;
        }

        $.ajax({
            type: "POST",
            url: "/Shippers/Update",
            data: { ShipperID: shipperId, CompanyName: companyName, Phone: phone },
            success: function () {
                window.location.href = '/Shippers/Index';
            },
            error: function () {
                Swal.fire('Error', 'Error al guardar los cambios.', 'error');
            }
        });
    });

    // Manejar el clic en el botón "Eliminar" en la vista Index
    $(".delete-button").click(function () {
        var index = $(this).data("id");
        var shipperId = $(this).data("shipperid");
        Swal.fire({
            title: '¿Estás seguro?',
            text: 'Esta acción no se puede deshacer.',
            icon: 'warning',
            showCancelButton: true,
            confirmButtonColor: '#d33',
            cancelButtonColor: '#3085d6',
            confirmButtonText: 'Sí, eliminar',
            cancelButtonText: 'Cancelar'
        }).then((result) => {
            if (result.isConfirmed) {
                $.ajax({
                    type: "POST",
                    url: "/Shippers/Delete",
                    data: { id: shipperId },
                    success: function () {
                        window.location.href = '/Shippers/Index';
                    },
                    error: function () {
                        Swal.fire('Error', 'No se pudo eliminar el registro.', 'error');
                    }
                });
            }
        });
    });

    // Manejar el clic en el botón "Guardar" en la vista Insert
    $("#shipperForm").submit(function (e) {
        e.preventDefault(); // Previene el envío del formulario por defecto

        var companyName = $("#CompanyName").val();
        var phone = $("#Phone").val();

        if (companyName.length == 0) {
            Swal.fire('Error', 'El nombre de la compañía no puede estar vacio.', 'error');
            return;
        }


        if (companyName.length > 40) {
            Swal.fire('Error', 'El nombre de la compañía no puede exceder los 40 caracteres.', 'error');
            return;
        }

      
            if (!ValidacionServicio.EsNumeroTelefonoValido(phone)) {
                Swal.fire('Error', 'Número de teléfono no válido.', 'error');
                return;
            


        }

        $.ajax({
            type: "POST",
            url: "/Shippers/Insert",
            data: { CompanyName: companyName, Phone: phone },
            success: function (result) {
                if (result.success) {
                    Swal.fire({
                        icon: 'success',
                        title: 'Éxito',
                        text: 'El Shipper se ha agregado correctamente.'
                    }).then(function () {
                        window.location.href = '/Shippers/Index';
                    });
                } else {
                    Swal.fire({
                        icon: 'error',
                        title: 'Error',
                        text: result.message
                    });
                }
            },
            error: function () {
                Swal.fire({
                    icon: 'error',
                    title: 'Error',
                    text: 'Ocurrió un error al procesar la solicitud.'
                });
            }
        });
    });
});
