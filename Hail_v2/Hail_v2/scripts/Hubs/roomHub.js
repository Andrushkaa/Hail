$(function () {
    // Declare a proxy to reference the hub. 
    var chat = $.connection.Room;
    // Create a function that the hub can call to broadcast messages.
    chat.client.broadcastMessage = function (userName, message, date ) {
        // Html encode display name and message. 
        var encodedName = $('<div />').text(userName).html();
        var encodedMsg = $('<div />').text(message).html();
        // Add the message to the page. 
        $('#discussion').append('<li><strong>' + encodedName
            + '</strong>:&nbsp;&nbsp;' + encodedMsg + '</li>');
    };
    // Get the user name and store it to prepend to messages.
    $('#displayname').val(prompt('Enter your name:', ''));
    // Set initial focus to message input box.  
    $('#message').focus();
    // Start the connection.
    $.connection.hub.start().done(function () {
        $('#sendmessage').click(function () {
            // Call the Send method on the hub. 
            chat.server.send("@Model.UserName", $('#message').val(), "1");
            // Clear text box and reset focus for next comment. 
            $('#message').val('').focus();
        });
    });
});