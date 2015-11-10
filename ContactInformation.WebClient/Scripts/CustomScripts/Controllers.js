/// <reference path="../jquery-2.1.4.intellisense.js" />
$(document).ready(function () {    
    $.ajax({
        url: "http://localhost:24478/api/ContactInfo",
        //url: "http://testconact.apphb.com/api/ContactInfo",
        type: "Get",
        success: function (data) {
            var genders = ["Male", "Female", "Other"]
            var statusList = ["Active", "Inactive", "Deleted"]

            for (var i = 0; i < data.length; i++) {

                var row = $("<tr></tr>").attr("id", "t" + data[i].Id)

                var pic = $("<img/>").attr("src", data[i].PhotoUrl)
                var imgContainer = $("<td></td>")
                imgContainer.append(pic)

                var name = $("<td>" + data[i].FirstName + " " + data[i].LastName + "</td>")

                var phone = $("<td>" + data[i].Telephone + "</td>")

                var gender = $("<td>" + genders[data[i].Gender] + "</td>")

                var statusButton = $("<input/>").attr({
                    "value" : statusList[data[i].Status],
                    "type": "submit",
                    "class": "btn btn-sm btn-primary status-button",
                    "id" : "s" + data[i].Id
                })
                var statusButtonContainer = $("<td></td>")
                statusButtonContainer.append(statusButton)

                var deleteButton = $("<input/>").attr({
                    "value": "Delete Contact",
                    "type": "submit",
                    "class": "btn btn-sm btn-danger delete-button",
                    "id": "d" + data[i].Id
                                       
                })
                var deleteButtonContainer = $("<td></td>")
                deleteButtonContainer.append(deleteButton)
               
                row.append(imgContainer)
                row.append(name)
                row.append(phone)
                row.append(gender)
                row.append(statusButtonContainer)
                row.append(deleteButtonContainer)

                $("#contactList").append(row)
            }
        },
        error: function (msg) { alert(msg); }
    });

   
});