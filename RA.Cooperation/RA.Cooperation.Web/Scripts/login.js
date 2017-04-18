$(document).ready(function(){
    $("#alert").hide();
    $(".register-error").hide();
    $(".registerbox").hide();

    $("#close").click(function(){
        $("#alert").fadeOut();
    });

    $("#doregister").click(function () {
        $(".loginbox").hide();
        $(".registerbox").fadeIn();
    });

    $("#dologin").click(function () {
        $(".registerbox").hide();
        $(".loginbox").fadeIn();
    });

    $("#login").click(function(){
        $.post("/Cooperation/Login/CheckLogin", {
            userName : $("#userName").val(),
            password : $("#password").val(),
            action : "login"
        },function(data){
            if (data.IsSuccess) {
                if($("#check-rem").is(':checked')){
                    $.cookie("passport", data.ReturnValue.cookiePassport, { expires: 7, path: '/' });
                    $.cookie("userObj", JSON.stringify(data.ReturnValue), { expires: 7, path: '/' });
                }else{
                    $.cookie("passport", data.ReturnValue.cookiePassport, { path: '/' });
                    $.cookie("userObj", JSON.stringify(data.ReturnValue), { path: '/' });
                }
                location.href = "/MyBlog/Home/Index";
            }else{
                $("#alert-text").html(data.ReturnMessage);
                $("#alert").fadeOut(50);
                $("#alert").fadeIn();
            }
        });
    });

    $("#register").click(function () {
        $.post("/Cooperation/Login/Register", {
            userName: $("#registerUserName").val(),
            password: $("#registerPassword").val(),
            nickName: $("#registerRealName").val()
        }, function (data) {
            $("#modal-body-text").html(data.ReturnMessage);
            $('#modal-container-000001').modal('show');
            $(".register-success").click(function () {
                if (data.IsSuccess) {
                    location.href = "/";
                }
            });
        })
    });
});

