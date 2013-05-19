using System.Web;
using System.Web.Optimization;

namespace KendoUIAttributes
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            const string jsKendoFolder = "~/Scripts/kendo/2013.1.319/";
            const string cssKendoFolder = "~/Content/kendo/2013.1.319/";


            bundles.Add(new ScriptBundle("~/bundles/kendo")
                .Include(jsKendoFolder + "kendo.core.min.js",
                jsKendoFolder + "kendo.data.odata.min.js",
                jsKendoFolder + "kendo.model.min.js",
                jsKendoFolder + "kendo.data.xml.min.js",
                jsKendoFolder + "kendo.data.min.js",
                jsKendoFolder + "kendo.fx.min.js",
                jsKendoFolder + "kendo.popup.min.js",
                jsKendoFolder + "kendo.list.min.js",
                jsKendoFolder + "kendo.combobox.min.js",
                jsKendoFolder + "kendo.calendar.min.js",
                jsKendoFolder + "kendo.datepicker.min.js",
                jsKendoFolder + "kendo.timepicker.min.js",
                jsKendoFolder + "kendo.datetimepicker.min.js",
                jsKendoFolder + "kendo.numerictextbox.min.js",
                jsKendoFolder + "kendo.validator.min.js",
                jsKendoFolder + "kendo.binder.min.js",
                jsKendoFolder + "kendo.dropdownlist.min.js",
                jsKendoFolder + "kendo.filtermenu.min.js",
                jsKendoFolder + "kendo.pager.min.js",
                jsKendoFolder + "kendo.sortable.min.js",
                jsKendoFolder + "kendo.userevents.min.js",
                jsKendoFolder + "kendo.draganddrop.min.js",
                jsKendoFolder + "kendo.groupable.min.js",
                jsKendoFolder + "kendo.editable.min.js",
                jsKendoFolder + "kendo.selectable.min.js",
                jsKendoFolder + "kendo.resizable.min.js",
                jsKendoFolder + "kendo.reorderable.min.js",
                jsKendoFolder + "kendo.grid.min.js",
                jsKendoFolder + "kendo.menu.min.js",
                jsKendoFolder + "kendo.slider.min.js",
                jsKendoFolder + "kendo.splitter.min.js",
                jsKendoFolder + "kendo.tabstrip.min.js",
                jsKendoFolder + "kendo.upload.min.js",
                jsKendoFolder + "kendo.window.min.js",
                jsKendoFolder + "kendo.treeview.min.js",
                jsKendoFolder + "kendo.editor.min.js",
                jsKendoFolder + "kendo.multiselect.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/core")
                .Include("~/Scripts/bindKendoControls.js","~/Scripts/kendoDataBind.js",
                "~/Scripts/onready.js"));
                

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
                        "~/Scripts/jquery-ui-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.unobtrusive*",
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new StyleBundle("~/Content/css").Include("~/Content/site.css"));
            bundles.Add(new StyleBundle("~/bundles/css/kendo").Include(
               cssKendoFolder + "kendo.common.*",
               cssKendoFolder + "kendo.default.*"));

            bundles.Add(new StyleBundle("~/Content/themes/base/css").Include(
                        "~/Content/themes/base/jquery.ui.core.css",
                        "~/Content/themes/base/jquery.ui.resizable.css",
                        "~/Content/themes/base/jquery.ui.selectable.css",
                        "~/Content/themes/base/jquery.ui.accordion.css",
                        "~/Content/themes/base/jquery.ui.autocomplete.css",
                        "~/Content/themes/base/jquery.ui.button.css",
                        "~/Content/themes/base/jquery.ui.dialog.css",
                        "~/Content/themes/base/jquery.ui.slider.css",
                        "~/Content/themes/base/jquery.ui.tabs.css",
                        "~/Content/themes/base/jquery.ui.datepicker.css",
                        "~/Content/themes/base/jquery.ui.progressbar.css",
                        "~/Content/themes/base/jquery.ui.theme.css"));

            bundles.IgnoreList.Clear();



        }
    }
}