
    var notificationHub;
$(function () {
    notificationHub = $.connection.notificationHub;
    $.connection.hub.start();
    notificationHub.client.newMessage = onNewMessage;
    $.connection.hub.error(function (err) {
        //alert('Ha ocurrido un error ' + err);
    });
});
function onNewMessage(message) {

    var unique_id = $.gritter.add({
        // (string | mandatory) the heading of the notification
        title: 'Nuevo Mensaje',
        // (string | mandatory) the text inside the notification
        text: message,
        // (string | optional) the image to display on the left
        image: BlankonApp.handleBaseURL() + '/assets/global/img/icon/64/contact.png',
        // (bool | optional) if you want it to fade out on its own or just sit there
        sticky: true,
        // (int | optional) the time you want it to be alive for before fading out
        time: ''
    });

}
