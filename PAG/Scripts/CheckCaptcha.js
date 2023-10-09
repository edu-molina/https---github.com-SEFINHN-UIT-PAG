$(function () {
    $('#btnValidar').click(function checkForm(event) {

        $('#status').attr('class', 'inProgress');
        $('#btnValidar').html('Validando');
        $('#btnValidar').prop('disabled',true);
        $("#CaptchaCode").addClass('spinner');

        // obtiene la instacia del objeto Captcha del lado del cliente
        var captchaObj = $("#CaptchaCode").get(0).Captcha;

        // recopila los datos necesarios para la validacion del Captcha
        var params = {}
        params.CaptchaId = captchaObj.Id;
        params.InstanceId = captchaObj.InstanceId;
        params.UserInput = $("#CaptchaCode").val();


        // hacer la solicitud de validación asincrónica de Captcha

        $.getJSON('ValidateCaptcha/CheckCaptcha', params, function (result) {
            if (true === result) {
                
                $('#status').attr('class', 'correct');
                $('#status').html('Captcha Correcto!');
                $("#CaptchaCode").removeClass('spinner');
                $('#btnValidar').html('Aceptar');
                $('#btnValidar').removeProp('disabled');
                $('#layoutmyModal').modal('toggle');
            } else {
                
                $("#CaptchaCode").removeClass('spinner');
                $('#status').attr('class', 'incorrect');
                $('#status').html('Captcha Incorrecto!');
                $('#btnValidar').html('Aceptar');
                $('#btnValidar').removeProp('disabled');
                // siempre cambia el código Captcha si la validación falla
                captchaObj.ReloadImage();
            }
        });

        

        event.preventDefault();
    });
});