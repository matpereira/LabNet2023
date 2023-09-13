$(document).ready(function () {
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
        var trimmedValue = companyName.trim();
        var phone = $("#editPhone_" + index).val();
        var customerId = $("#customerId_" + index).val();

        if (trimmedValue.length === 0) {
            Swal.fire('Error', 'El campo no puede estar vacío o contener solo espacios en blanco.', 'error');
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
            url: "/Customers/Update",
            data: { CustomerID: customerId, CompanyName: companyName, Phone: phone },
            success: function () {
                window.location.href = '/Customers/Index';
            },
            error: function () {
                Swal.fire('Error', 'Error al guardar los cambios.', 'error');
            }
        });
    });


    // Manejar el clic en el botón "Eliminar" en la vista Index
    $(".delete-button").click(function () {
        var index = $(this).data("id");
        var customerId = $(this).data("customerid");
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
                    url: "/Customers/Delete",
                    data: { id: customerId },
                    success: function (response) {
                        if (response.success) {
                            window.location.href = '/Customers/Index';
                        } else {
                            Swal.fire('Error', response.message, 'error');
                        }
                    },
                    error: function () {
                        Swal.fire('Error', 'Ocurrió un error al eliminar el registro.', 'error');
                    }
                });
            }
        });
    });

    $("#insertCustomerModal .btn-secondary").click(function () {
        $("#insertCustomerModal").modal("hide");
    });
    $("#openInsertModalButton").click(function () {
        $("#InsertCustomerID").val("");
        $("#InsertCompanyName").val("");
        $("#InsertAddress").val("");
        $("#InsertPhone").val("");
        $("#insertCustomerModal").modal("show");
    });
    $("#saveCustomer").click(function () {
        var customerId = $("#InsertCustomerID").val();
        var companyName = $("#InsertCompanyName").val();
        var trimmedValue = companyName.trim();
        var address = $("#InsertAddress").val();
        var phone = $("#InsertPhone").val();

        if (customerId.length === 0) {
            Swal.fire('Error', 'El campo de ID no puede estar vacío.', 'error');
            return;
        }

        if (customerId.length !== 5) {
            Swal.fire('Error', 'El campo de ID debe tener 5 caracteres.', 'error');
            return;
        }

        if (trimmedValue.length === 0) {
            Swal.fire('Error', 'El campo de nombre de la compañía no puede estar vacío o contener solo espacios en blanco.', 'error');
            return;
        }

        if (companyName.length > 40) {
            Swal.fire('Error', 'El nombre de la compañía no puede exceder los 40 caracteres.', 'error');
            return;
        }

        if (address.length > 60) {
            Swal.fire('Error', 'La dirección no puede exceder los 60 caracteres.', 'error');
            return;
        }

        if (!ValidacionServicio.EsNumeroTelefonoValido(phone)) {
            Swal.fire('Error', 'Número de teléfono no válido.', 'error');
            return;
        }

        $.ajax({
            type: "POST",
            url: "/Customers/Insert",
            data: { CustomerID: customerId, CompanyName: companyName, Address: address, Phone: phone },
            success: function () {
                window.location.href = '/Customers/Index';
            },
            error: function () {
                Swal.fire('Error', 'Error al guardar el nuevo Customer.', 'error');
            }
        });
    });
});