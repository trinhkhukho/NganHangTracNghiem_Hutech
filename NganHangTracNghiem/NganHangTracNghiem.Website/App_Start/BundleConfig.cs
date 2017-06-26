using System.Web;
using System.Web.Optimization;

namespace NganHangTracNghiem.Website
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                "~/Scripts/Vendors/modernizr.js"));

            bundles.Add(new ScriptBundle("~/bundles/JS").Include(

                "~/Scripts/JS/angular.min.js",
                "~/Scripts/JS/angular-route.js",
                "~/Scripts/JS/jquery-3.2.1.min.js",
                "~/Scripts/JS/bootstrap.js",
                "~/Scripts/JS/material-dashboard.js",
                "~/Scripts/JS/material.min.js",

                "~/Scripts/JS/angular-animate.js",
                "~/Scripts/JS/angular-sanitize.js",
                "~/Scripts/JS/angular-block-ui.min.js",
                "~/Scripts/JS/ui-bootstrap-tpls-2.5.0.min.js",
                "~/Scripts/JS/angular-toastr.tpls.js"


            ));

            bundles.Add(new ScriptBundle("~/bundles/Angular").Include(


                "~/Scripts/Angular/app.js",
                "~/Scripts/Angular/Sevieces/serviceGetId.js",
                "~/Scripts/Angular/Sevieces/serviceShareData.js",
                "~/Scripts/Angular/Questions/addQuesrionCrt.js",
                "~/Scripts/Angular/Chapter/ChapterCrt.js",
                "~/Scripts/Angular/GroupQuestions/GroupQuestionCrt.js",
                "~/Scripts/Angular/GroupQuestions/QuestionCrt.js",
                "~/Scripts/Angular/Readfile/ReadFile.js",
                "~/Scripts/Angular/Readfile/Result.js",
                "~/Scripts/Angular/Questions/editQuestion.js"
                //"~/Scripts/Angular/Questions/popQuestion.js"


            ));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Content/css/bootstrap.min.css",
                "~/Content/css/material-dashboard.css",
                "~/Content/font-awesome-4.7.0/css/font-awesome.min.css",
                "~/Content/css/angular-block-ui.min.css",
                "~/Content/css/angular-toastr.css"

                ));

            BundleTable.EnableOptimizations = false;
        }
    }
}
