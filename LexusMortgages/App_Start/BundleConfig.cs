﻿using System.Web;
using System.Web.Optimization;

namespace LexusMortgages
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery.min.js",
                        "~/Scripts/typed.js",
                        "~/Scripts/jquery.fittext.js",
                        "~/Scripts/jquery.lettering.js",
                        "~/Scripts/jquery.textillate.js",
                        /*needed for AJAX*/"~/Scripts/jquery.unobtrusive-ajax.min.js",
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/bootstrap.min.js",
                      "~/Scripts/owl.carousel.js",
                      "~/Scripts/owl.carousel.min.js",
                      "~/Scripts/bootstrap-datepicker.js",
                      "~/Scripts/DatePickerReady.js",
                      "~/Scripts/demo.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/bootstrap.min.css",
                      "~/Content/bootstrap-datepicker.css",
                      "~/Content/OwlCarousel/owl.carousel.css",
                      "~/Content/OwlCarousel/owl.theme.css",
                      "~/Content/OwlCarousel/owl.transitions.css",
                      "~/Content/bootstrap-social.css",
                      "~/Content/flag-icon.css",
                      "~/Content/flag-icon.min.css",
                      "~/Content/zocial.css",
                      "~/Content/Style.css",
                      "~/Content/font-awesome.css",
                      "~/Content/ipad.css",
                      "~/Content/animate.min.css",
                      "~/Content/demo.css",
                      "~/Content/button-styles.css",
                      "~/Content/site.css"));
        }
    }
}
