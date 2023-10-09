// Wait for the DOM to be ready
$(function () {
    // Initialize form validation on the registration form.
    // It has the name attribute "registration"
    $("form[name='frmUsuarioAnonimo']").validate({
        ignore: ":disabled",
        // Specify validation rules
        rules: {
            "SOLICITANTE.CORREO": {
                required: true,
                email: true
            },
            "SOLICITANTE.PRIMER_NOMBRE": {
                required: true
            },
            "SOLICITANTE.PRIMER_APELLIDO": {
                required: true
            },
            "SOLICITANTE.NRO_ID": {
                required: true
            },
            drpSistema: {
                required: true
            }
        },
        // Specify validation error messages
        messages: {
            "SOLICITANTE.PRIMER_NOMBRE": {
                required: "El Campo Primer Nombre es Obligatorio."
            },
            "SOLICITANTE.PRIMER_APELLIDO": {
                required: "El Campo Primer Apellido es Obligatorio."
            },
            "SOLICITANTE.CORREO": {
                required: "El Campo Correo es Obligatorio.",
                email: "El campo Correo no es una dirección de correo electrónico válida."
            },
            "SOLICITANTE.NRO_ID": {
                required: "El campo Nro Id es obligatorio."
            },
            drpSistema: {
                required: "Selecciona al menos un Sistema."
            }
        },
        highlight: function (element) {
            $(element).parents('.form-group').addClass('has-error has-feedback');
        },
        unhighlight: function (element) {
            $(element).parents('.form-group').removeClass('has-error');
        }
    });
});