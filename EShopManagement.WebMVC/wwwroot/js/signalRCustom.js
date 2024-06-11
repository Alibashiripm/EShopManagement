﻿$(document).ready(function () {
    if (Notification.permission !== "granted") {
        Notification.requestPermission();
    }
});
var currentId = 0;
var userId = 0;

var connection = new signalR.HubConnectionBuilder()
    .withUrl("/chat/chat")
    .build();

connection.on("Welcome",
    function (id) {
        userId = id;
    });
connection.on("ReceiveMessage", receive);
connection.on("NewGroup", appendGroup);
connection.on("JoinGroup", joined);
connection.on("ReceiveNotification", sendNotification);

async function Start() {
    try {
        await connection.start();
        $(".disConnect").hide();

    } catch (e) {
        $(".disConnect").show();
        setTimeout(Start, 6000);
    }
}

connection.onclose(Start);
Start();
function appendGroup(groupName, token) {
    if (groupName === "Error") {
        alert("ERROR");
    } else {
        $(".rooms #user_groups ul").append(`
                                             <li onclick="joinInGroup('${token}')">
                                            ${groupName}
                                          
                                            <span></span>
                                        </li>
                                            `);
        $("#exampleModal").modal({ show: false });
    }
}

function insertGroup(event) {
    event.preventDefault();
    var groupName = event.target[0].value;
    var formData = new FormData();
    formData.append("GroupName", groupName);
    $.ajax({
        url: "/chat/CreateGroup",
        type: "post",
        data: formData,
        encytype: "multipart/form-data",
        processData: false,
        contentType: false
    });
}

function search() {
    var text = $("#search_input").val();
    if (text) {
        $("#search_result").show();
        $("#user_groups").hide();
        $.ajax({
            url: "/chat/search?title=" + text,
            type: "get"
        }).done(function (data) {
            $("#search_result ul").html("");
            for (var i in data) {
                if (data[i].isUser) {
                    $("#search_result ul").append(`
                                 <li onclick="joinInPrivateGroup(${data[i].token})">
                                            ${data[i].title}
                                            <span></span>
                                        </li>
                        `);
                } else {
                    $("#search_result ul").append(`
                                 <li onclick="joinInGroup('${data[i].token}')">
                                            ${data[i].title}
                                            <span></span>
                                        </li>

                        `);
                }
            }

        });
    } else {
        $("#search_result").hide();
        $("#user_groups").show();
    }
}
function sendNotification(chat) {
    if (Notification.permission === "granted") {
        console.log(chat.Id);
        console.log(currentId);
        if (currentId !== chat.Id) {
            var notification = new Notification(chat.groupName,
                {
                    body: chat.chatBody
                });

        }
    }
}
function receive(chat) {

    $("#messageText").val('');
    if (userId === chat.userId) {
        if (chat.fileAttach) {
            $(".chats").append(`
                 <div class="chat-me">
                     <div class="chat">
                          <span>${chat.userName}</span>
                              <p><a href='/files/${chat.fileAttach}'  target="_blank">${chat.chatBody}</a><p>
                                <span>${chat.createDate}</span>
                                 </div>
                           </div> `);
        } else {
            $(".chats").append(`
                 <div class="chat-me">
                     <div class="chat">
                          <span>${chat.userName}</span>
                              <p>${chat.chatBody}</p>
                                <span>${chat.createDate}</span>
                                 </div>
                           </div>
                                            `);
        }
    } else {
        if (chat.fileAttach) {
            $(".chats").append(`
                 <div class="chat-you">
                     <div class="chat">
                          <span>${chat.userName}</span>
                           <p><a href='/files/${chat.fileAttach}'  target="_blank">${chat.chatBody}</a><p>
                                <span>${chat.createDate}</span>
                                 </div>
                           </div> `);
        } else {
            $(".chats").append(`
                 <div class="chat-you">
                     <div class="chat">
                          <span>${chat.userName}</span>
                              <p>${chat.chatBody}</p>
                                <span>${chat.createDate}</span>
                                 </div>
                           </div>
                                            `);
        }
    }

}

function sendMessage(event) {
    event.preventDefault();
    var text = $("#messageText").val();
    var file = event.target[1].files[0];
    var formData = new FormData();
    formData.append("Id", currentId);
    formData.append("FileAttach", file);
    formData.append("ChatBody", text);
    $.ajax({
        url: "/chat/SendMessage",
        type: "post",
        data: formData,
        encytype: "multipart/form-data",
        processData: false,
        contentType: false
    }).done(function() {
        $(".footer form input[type=file]").val('');
    });
}

function joined(group, chats) {
    $(".header").css("display", "block");
    $(".footer").css("display", "block");
    $(".header h2").html(group.groupTitle);
    currentId = group.id;
    $(".chats").html("");
    for (var i in chats) {
        var chat = chats[i];
        console.log(chat);
        if (userId === chat.userId) {
            if (chat.fileAttach) {
                $(".chats").append(`
                 <div class="chat-me">
                     <div class="chat">
                          <span>${chat.userName}</span>
                            <p><a href='/files/${chat.fileAttach}'  target="_blank">${chat.chatBody}</a><p>
                                <span>${chat.createDate}</span>
                                 </div>
                           </div> `);
            } else {
                $(".chats").append(`
                 <div class="chat-me">
                     <div class="chat">
                          <span>${chat.userName}</span>
                              <p>${chat.chatBody}</p>
                                <span>${chat.createDate}</span>
                                 </div>
                           </div>
                                            `);
            }
        } else {
            if (chat.fileAttach) {
                $(".chats").append(`
                 <div class="chat-you">
                     <div class="chat">
                          <span>${chat.userName}</span>
                              <p><a href='/files/${chat.fileAttach}' target="_blank">${chat.chatBody}</a><p>
                                <span>${chat.createDate}</span>
                                 </div>
                           </div> `);
            } else {
                $(".chats").append(`
                 <div class="chat-you">
                     <div class="chat">
                          <span>${chat.userName}</span>
                              <p>${chat.chatBody}</p>
                                <span>${chat.createDate}</span>
                                 </div>
                           </div>
                                            `);
            }
        }
    }
}

function joinInGroup(token) {
    connection.invoke("JoinGroup", token, currentId);
}

function joinInPrivateGroup(receiverId) {
    connection.invoke("JoinPrivateGroup", receiverId, currentId);
}