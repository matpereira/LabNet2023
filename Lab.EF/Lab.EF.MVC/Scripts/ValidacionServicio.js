var ValidacionServicio = (function () {
    function ValidacionServicio() {
    }

    ValidacionServicio.EsNumeroTelefonoValido = function (numero) {
        if (numero == null || numero == undefined || numero == "") {
            return true;
        }
        var patron = /^(?=\(?\+?\d{1,3}\)?)(?=.{1,24}$)\(?\+?\d{1,3}\)?[\s-]?\d{1,24}$/;
        return patron.test(numero);
    };

    return ValidacionServicio;
}());
