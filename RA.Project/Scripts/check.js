$(document).ready(function(){
    $("#userName").html($.cookie("userName"));
    //会话验证
    var passport = $.cookie("passport");
    if(passport == undefined){
        location.href = "/Cooperation/Login";
    }else{
        $.post("/Cooperation/Login/CheckLogin", {
            passport : $.cookie("passport"),
            action : "check"
        }, function (data) {
            if (!data.IsSuccess) {
                $.cookie("passport",null,{expires:-1});
                location.href = "/Cooperation/Login";
            }
        });

        //登出
        $("#logout").click(function(){
            $.cookie("userObj", null, { expires: -1 });
            $.cookie("passport", null, { expires: -1 });
            location.href = "/";
        });
    }
});