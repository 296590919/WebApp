$(document).ready(function(){
    $(".btn-delete").click(function(){
        var now = $(this);
        var articleID = now.attr("tag");
        $('#modal-container-700000').modal('show');

        $(".btn-ok").click(function(){
            $.post("/MyBlog/Category/DeleteArticle", { articleID: articleID }, function (data) {
                $("#modal-body-text").html(data.ReturnMessage);
                $('#modal-container-701036').modal('show');
            });
        });
    });
})