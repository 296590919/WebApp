using Framework;
using System.Collections.Generic;
using System.Web;
using System.Web.Optimization;

namespace MyBlog.Web
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            //文章页css
            bundles.Add(new StyleBundle("~/CSS/article.css").Include(
                "~/Areas/MyBlog/Plugin/ueditor/third-party/SyntaxHighlighter/shCoreDefault.css"
                ));
            //文章页js
            bundles.Add(new ScriptBundle("~/Scripts/Articles.js").Include(
                "~/Areas/MyBlog/Plugin/ueditor/third-party/SyntaxHighlighter/shCore.js",
                "~/Areas/MyBlog/Scripts/article.js"
                ));
            //列表js
            bundles.Add(new ScriptBundle("~/Scripts/menu.js").Include(
                "~/Areas/MyBlog/Scripts/menu.js"
                ));
            //栏目js
            bundles.Add(new ScriptBundle("~/Scripts/Category.js").Include(
                "~/Areas/MyBlog/Scripts/category.js"
                ));
            //添加文章页js
            bundles.Add(new ScriptBundle("~/Scripts/NewArticles.js").Include(
                "~/Areas/MyBlog/Plugin/ueditor/ueditor.config.js",
                "~/Areas/MyBlog/Plugin/ueditor/ueditor.all.js",
                "~/Areas/MyBlog/Plugin/ueditor/lang/zh-cn/zh-cn.js",
                "~/Areas/MyBlog/Scripts/newArticle.js"
                ));
            //修改文章页js
            bundles.Add(new ScriptBundle("~/Scripts/edits.js").Include(
                "~/Areas/MyBlog/Plugin/ueditor/ueditor.config.js",
                "~/Areas/MyBlog/Plugin/ueditor/ueditor.all.js",
                "~/Areas/MyBlog/Plugin/ueditor/lang/zh-cn/zh-cn.js",
                "~/Areas/MyBlog/Scripts/edit.js"
                ));
        }
    }
}
