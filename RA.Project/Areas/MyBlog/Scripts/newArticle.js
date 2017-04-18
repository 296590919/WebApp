var ue = UE.getEditor('editor');

function postArticle() {
    var articleContain = ue.getContent();
    var articleCopyright = $("#copyright").val();
    var articleAbstract = ue.getContentTxt();
    var articleTitle = $("#title").val();
    var userID = userObj.userID;
    $.post("/MyBlog/Article/NewArticlePost", {
        "articleContain": articleContain,
        "articleCopyright": articleCopyright,
        "articleTitle": articleTitle,
        "articleAbstract": articleAbstract.substring(0, 200),
        "categoryID": categoryID,
        "userID": userID
    },
        function (data) {
            $("#modal-body-text").html(data.ReturnMessage);
            $('#modal-container-701036').modal('show');
        }
    );
}