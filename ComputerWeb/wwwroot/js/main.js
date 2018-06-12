//后台商品查询
function serch1() {
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
        data: "serch1=" + showmsg,
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

//后台用户查询
function serch2() {
    var text = document.getElementById("serch2").value;
    showmsg2(text);
}
//function RedirectTo(msg) {
//    window.location.href = location.host + "";
//}
function showmsg2(showmsg) {

    $.ajax({
        type: "POST",
        url: "/Home/manage",
        data: "serch2=" + showmsg,
        success: function (res) {
            appendhtml2(res);
        }
    }
    )
}
function appendhtml2(data) {
    var i = 0;
    $("#user_1").children().remove();
    while (data[i] != null) {
        var id = data[i];
        var name = data[++i];
        var phone = data[++i];
        var html = $(
            "<tr class=\"gradeX\">" +
            "<td>" + id + "</td >" +
            "<td>" + name + "</td >" +
            "<td class=\"center\">" + phone + "</td >" +
            "<td>" +
            "<button type=\"submit\" class=\"btn\">修改</button>" +
            "<button type=\"submit\" class=\"btn\">删除</button>" +
            "</td>" +
            "</tr>"
        );
        $("#user_1").append(html);
        i++;
    }
}

//后台订单查询
function serch3() {
    var text = document.getElementById("serch3").value;
    showmsg3(text);
}
//function RedirectTo(msg) {
//    window.location.href = location.host + "";
//}
function showmsg3(showmsg) {

    $.ajax({
        type: "POST",
        url: "/Home/manage",
        data: "serch3=" + showmsg,
        success: function (res) {
            appendhtml3(res);
        }
    }
    )
}
function appendhtml3(data) {
    var i = 0;
    $("#order_1").children().remove();
    while (data[i] != null) {
        var orderid = data[i];
        var proid = data[++i];
        var ordertime = data[++i];
        var name = data[++i];
        var phone = data[++i];
        var state = data[++i];
        var html = $(
            "<tr class=\"gradeC\">" +
            "<td>" + orderid + "</td>"+
            "<td>" + proid + "</td >" +            
            "<td class=\"center\">" + ordertime + "</td >" +
            "<td>" + name + "</td >" +
            "<td>" + phone + "</td >" +
            "<td>"+
                "<button class=\"btn btn-default\">"+state+"</button>"+
                "<button data-toggle=\"dropdown\" class=\"btn btn-default dropdown-toggle\">"+"<span class=\"caret\">"+"</span>"+"</button>"+
                "<ul class=\"dropdown-menu\">"+
                    "<li>"+
                        "<a>待付款</a>"+
                    "</li>"+
                    "<li class=\"disabled\">"+
                        "<a>已付款</a>"+
                    "</li>"+
                    "<li class=\"disabled\">"+
                        "<a>配送中</a>"+
                    "</li>"+
                    "<li class=\"disabled\">"+
                        "<a>已配送</a>"+
                    "</li>"+
                "</ul>"+
            "</td>"
        );
        $("#order_1").append(html);
        i++;
    }
}

//后台员工查询
function serch4() {
    var text = document.getElementById("serch4").value;
    showmsg4(text);
}
//function RedirectTo(msg) {
//    window.location.href = location.host + "";
//}
function showmsg4(showmsg) {

    $.ajax({
        type: "POST",
        url: "/Home/manage",
        data: "serch4=" + showmsg,
        success: function (res) {
            appendhtml4(res);
        }
    }
    )
}
function appendhtml4(data) {
    var i = 0;
    $("#staff_1").children().remove();
    while (data[i] != null) {
        var id = data[i];
        var name = data[++i];
        var phone = data[++i];
        var state = data[++i];
        var html = $(
            "<tr class=\"gradeC\">" +
            "<td>" + id + "</td >" +
            "<td>" + name + "</td >" +
            "<td>" + phone + "</td >" +
            "<td>" + state + "</td >" +
            "</tr>"
        );
        $("#staff_1").append(html);
        i++;
    }
}