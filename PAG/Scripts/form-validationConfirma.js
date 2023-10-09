$(function () {
    // Initialize form validation on the registration form.
    // It has the name attribute "registration"
    $("form[name='frmActivaUsuario']").validate({
        //ignore: ":disabled",
        // Specify validation rules
        rules: {
            NUEVOPASSWORD: {
                required: true,
                minlength: 8,
                pwcheckNumbers: true,
                pwcheckLowerCase: true,
                pwcheckUpperCase: true
            },
            RECONFIRMANUEVOPASSWORD: {
                required: true,
                equalTo: "#NUEVOPASSWORD",
            }
        },
        // Specify validation error messages
        messages: {
            NUEVOPASSWORD: {
                required: "El Campo Contraseña es Obligatorio.",
                minlength: "El tamaño minimo de la contraseña es de 8."
            },
            RECONFIRMANUEVOPASSWORD: {
                required: "El Campo Confirma Contraseña es Obligatorio.",
                equalTo: "La contraseña debe ser la misma."
            },
            highlight: function (element) {
                $(element).parents('.form-group').addClass('has-error has-feedback');
            },
            unhighlight: function (element) {
                $(element).parents('.form-group').removeClass('has-error');
            }
        }

    });

    $.validator.addMethod("pwcheckNumbers", function (value) {
        var numeros = "0123456789";
        for (i = 0; i < value.length; i++) {
            if (numeros.indexOf(value.charAt(i), 0) != -1) {
                    return true;
                }
            }
            return false;
    }, "Debe contener al menos un número.");


    $.validator.addMethod("pwcheckLowerCase", function (value) {
        var letras = "abcdefghyjklmnñopqrstuvwxyz";

        for (i = 0; i < value.length; i++) {
                if (letras.indexOf(value.charAt(i), 0) != -1) {
                    return true;
                }
            }
            return false;
    }, "Debe contener letras minúsculas.");

    $.validator.addMethod("pwcheckUpperCase", function (value) {
        var letras_mayusculas = "ABCDEFGHYJKLMNÑOPQRSTUVWXYZ";

        for (i = 0; i < value.length; i++) {
            if (letras_mayusculas.indexOf(value.charAt(i), 0) != -1) {
                return true;
            }
        }
        return false;
    }, "Debe contener al menos una letra mayúscula.");

});


