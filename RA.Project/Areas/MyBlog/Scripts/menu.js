$(document).ready(function () {
    $("#optionProject").click(function () {
        $.post("/MyBlog/Home/ProjectOption", '', function (data) {
            getData(data);
            $("#modal-container-704233").modal("show");

            $(".btn-done").click(function () {
                $(".btn-addCategory").unbind();
                $(".btn-deleteCategory").unbind();
                $(".categoryItem").unbind();
                $(".btn-addCategory-ok").unbind();
                $(".btn-deleteCategory-ok").unbind();

                $(".projectDelete").unbind();
                $(".btn-addProject").unbind();
                $(".btn-deleteProject-ok").unbind();
                $(".btn-addProject-ok").unbind();

                $.post("/MyBlog/Home/ProjectOption", '', function (data) {
                    getData(data);
                });
            })
        })
    })

    $(".btn-option-exit").click(function () {
        location.reload();
    });

    function getData(data) {

        $(".content").html(data);

        //添加栏目
        $(".btn-addCategory").click(function () {
            var now = $(this);
            var projectID = now.attr("tag");
            $("#modal-container-702348").modal("show");
            $(".btn-addCategory-ok").click(function () {
                $.post("/MyBlog/Category/AddCategory", {
                    projectID: projectID,
                    userID: userObj.userID,
                    categoryName: $("#inputCategory").val()
                }, function (data) {
                    $("#modal-body-alert-text").html(data.ReturnMessage);
                    $('#modal-container-702342').modal('show');
                })

            })
        });

        //删除栏目
        $(".btn-deleteCategory").click(function () {
            var now = $(this);
            var categoryID = now.attr("tag");
            $("#modal-container-700001").modal("show");
            $(".btn-deleteCategory-ok").click(function () {
                $.post("/MyBlog/Category/DeleteCategory", {
                    categoryID: categoryID
                }, function (data) {
                    $("#modal-body-alert-text").html(data.ReturnMessage);
                    $('#modal-container-702342').modal('show');
                });
            });
        });

        $(".categoryItem").mouseenter(function () {
            var now = $(this).children().children(".btn-deleteCategory");
            now.css("visibility", "visible");
        })

        $(".categoryItem").mouseleave(function () {
            var now = $(this).children().children(".btn-deleteCategory");
            now.css("visibility", "collapse");
        })

        //删除项目
        $(".projectDelete").click(function () {
            var now = $(this);
            var projectID = now.attr("tag");
            $("#modal-container-743534").modal("show");
            $(".btn-deleteProject-ok").click(function () {
                $.post("/MyBlog/Project/DeleteProject", {
                    projectID: projectID
                }, function (data) {
                    $("#modal-body-alert-text").html(data.ReturnMessage);
                    $('#modal-container-702342').modal('show');
                });
            });
        });
        
        //添加项目
        $(".btn-addProject").click(function () {
            $("#modal-container-702754").modal("show");
            $(".btn-addProject-ok").click(function () {
                $.post("/MyBlog/Project/AddProject", {
                    projectName: $("#inputProject").val(),
                    userID: userObj.userID
                }, function (data) {
                    $("#modal-body-alert-text").html(data.ReturnMessage);
                    $('#modal-container-702342').modal('show');
                });
            });
        });
    }
});
function changeStatus(id) {
    $.ajax({
        url: "/MyBlog/Category/Index",
        data: "categoryID=" + id,
        type: "GET",
        success: function (data) {
            $("#body2").html = data;
            $("#b")
            $(".categoryItem").css("background-color", "#eeeeee");
            $(this).css("background-color", "#ffffff");
        }
    });

}