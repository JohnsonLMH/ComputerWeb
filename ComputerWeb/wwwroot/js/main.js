function serch() {
    var text = document.getElementById("serch1").value;
    showmsg(text);
}
//function RedirectTo(msg) {
//    window.location.href = location.host + "";
//}

function showmsg(showmsg) {
    
    $.ajax({
        type: "POST",
        url: "/Home/manage",
        data: "serch=" + showmsg,
        success: function (res) {
            appendhtml(res);
        }
    }
    )
}
function appendhtml(data) {
    var i= 0;
    $("#product_1").children().remove();
    while (data[i] != null) {
        var id = data[i];
        var name = data[++i];
        var time = data[++i];
        var state = data[++i];
        var html = $(
            "<tr class=\"gradeX\">" +
            "<td>1</td >" +
            "<td>" + id + "</td >" +
            "<td>" + name + "</td >" +
            "<td class=\"center\">" + time + "</td >" +
            "<td class=\"center\">" + state + "</td >" +
            "<td>" +
            "<button type=\"submit\" class=\"btn\">修改</button>" +
            "<button type=\"submit\" class=\"btn\">删除</button>" +
            "</td>" +
            "</tr>"
        );
        $("#product_1").append(html);
        i++;
    }
}