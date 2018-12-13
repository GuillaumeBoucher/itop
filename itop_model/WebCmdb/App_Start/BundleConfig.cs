using System.Web.Optimization;

namespace WebCmdb.App_Start
{
    public class BundleConfig
    {

        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {

            bundles.Add(new StyleBundle("~/Css").Include(
                        "~/Content/bower_components/bootstrap/dist/css/bootstrap.min.css",
                        "~/Content/bower_components/font-awesome/css/font-awesome.min.css",
                        "~/Content/bower_components/Ionicons/css/ionicons.min.css",
                        "~/Content/dist/css/AdminLTE.min.css",
                        "~/Content/dist/css/skins/_all-skins.min.css",
                        "~/Content/fonts/googleapis.css"
                        ));

            //bundles.UseCdn = true;
            

            bundles.Add(new ScriptBundle("~/Js").Include(
                        "~/Content/bower_components/jquery/dist/jquery.min.js",
                        "~/Content/bower_components/bootstrap/dist/js/bootstrap.min.js",
                        "~/Content/bower_components/jquery-slimscroll/jquery.slimscroll.min.js",
                        "~/Content/bower_components/fastclick/lib/fastclick.js",
                        "~/Content/dist/js/adminlte.min.js",
                        "~/Content/dist/js/demo.js"
                        //,                        "~/Content/js/time.js"
                        ));

            BundleTable.EnableOptimizations = true;
    
        }

    }
}