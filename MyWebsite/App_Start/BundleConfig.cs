﻿using System.Web;
using System.Web.Optimization;

namespace MyWebsite
{
	public class BundleConfig
	{
		// For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
		public static void RegisterBundles(BundleCollection bundles)
		{
			bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
						"~/Scripts/jquery-{version}.js"));

			bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
						"~/Scripts/jquery.validate*"));

			// Use the development version of Modernizr to develop with and learn from. Then, when you're
			// ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
			bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
						"~/Scripts/modernizr-*"));

			bundles.Add(new Bundle("~/bundles/bootstrap").Include(
					  "~/Scripts/bootstrap.js",
					  "~/Scripts/PreviewSelectedImage.js"));


			bundles.Add(new ScriptBundle("~/bundles/javascript").Include(
					  "~/Scripts/PreviewSelectedImagejs",
					 "~/Scripts/AdditionalJavascript/typed.js",
					 "~/Scripts/AdditionalJavascript/typed.min.js",
					 "~/Scripts/AdditionalJavascript/main.js",
					 "~/Scripts/AdditionalJavascript/WaitingUntilLoadingPage.js",
					 "~/Scripts/AdditionalJavascript/HideSideBar.js"
					 ));


			bundles.Add(new StyleBundle("~/Content/css").Include(
					  "~/Content/bootstrap.css",
					  "~/Content/bootstrap-icons.css",
					  "~/Content/font-awesome.css",
					  "~/Content/font-awesome.min.css",
					  "~/Content/swiper-bundle.min.css",
					  "~/Content/Site.css"));
		}
	}
}
