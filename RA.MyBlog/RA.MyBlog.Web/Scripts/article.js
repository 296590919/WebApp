$(document).ready(function(){
    SyntaxHighlighter.highlight();
    $("table.syntaxhighlighter").each(function () {
        if (!$(this).hasClass("nogutter")) {
            var gutter = $($(this).find(".gutter")[0]);
            var codeLines = $($(this).find(".code .line"));
            gutter.find(".line").each(function (i) {
                $(this).height($(codeLines[i]).height());
                $(codeLines[i]).height($(codeLines[i]).height());
            });
        }
    });
});

