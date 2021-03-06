﻿using System.Web;
using System.Web.Optimization;

namespace AppStore.UI
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/slider-boxes.js",
                      "~/Scripts/slick.min.js",
                      "~/Scripts/datatables.js",
                    //  "~/Scripts/dataTables.bootstrap.js",
                     // "~/Scripts/jquery.dataTables.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                       "~/Content/bootstrap.css",
                      "~/Content/slider-boxes.scss",
                      "~/Content/slick.min.css",
                      "~/Content/bootstrap-4-utilities.css",
                      "~/Content/datatables.css",
                      "~/Content/font-awesome/font-awesome.min.css",
                      //"~/Content/dataTables.bootstrap.css",
                      "~/Content/site.css"));
        }
    }
}
