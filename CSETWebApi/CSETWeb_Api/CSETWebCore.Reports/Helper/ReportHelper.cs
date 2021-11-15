﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IronPdf;
using IronPdf.Rendering;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace CSETWebCore.Reports.Helper
{
    public static class ReportHelper
    {

        public async static Task<string> RenderRazorViewToString(this Controller controller, string viewName, object model, string baseUrl, IViewEngine engine)
        {
            controller.ViewData.Model = model;
            controller.TempData["links"] = baseUrl;

            using var sw = new StringWriter();
            var viewResult = engine.FindView(controller.ControllerContext, viewName, false);
            controller.ViewData.Model = model;
            var viewContext = new ViewContext(controller.ControllerContext, viewResult.View,
                controller.ViewData, controller.TempData, sw, new HtmlHelperOptions());
            await viewResult.View.RenderAsync(viewContext);

            string report = sw.GetStringBuilder().ToString();
            return report;
        }

        public static async Task<PdfDocument> RenderPdf(string html, string security, int pageNumber, Dictionary<string, int> margins)
        {
            var renderer = new ChromePdfRenderer();
            renderer.RenderingOptions.HtmlFooter = new HtmlHeaderFooter()
            {
                MaxHeight = 15,
                HtmlFragment =
                    "<div style=\"padding: 0 3rem\"><span style=\"font-family:Arial; font-size: 1rem\">"
                    + (security.ToLower() == "none" ? string.Empty : security)
                    + "</span><span style=\"font-family:Arial;float: right\">{page} | CRR Self-Assessment</span></div>"
            };

            renderer.RenderingOptions.FirstPageNumber = pageNumber++;
            renderer.RenderingOptions.MarginTop = margins["top"];
            renderer.RenderingOptions.MarginBottom = margins["bottom"];
            renderer.RenderingOptions.MarginLeft = margins["left"];
            renderer.RenderingOptions.MarginRight = margins["right"];

            renderer.RenderingOptions.EnableJavaScript = true;
            renderer.RenderingOptions.CssMediaType = PdfCssMediaType.Print;
            var pdf = await renderer.RenderHtmlAsPdfAsync(html);

            return pdf;
        }

        public static PdfDocument MergePdf(List<PdfDocument> pdfs)
        {
            var merged = PdfDocument.Merge(pdfs);
            return merged;
        }

        public static List<string> GetReportList(string report)
        {
            var pages = ReadResource.ReadResourceByKey("reports.json", report);
            return pages.Split(',').ToList();
        }

        public static string GetCoverSheet()
        {
            var coverSheet = ReadResource.ReadResourceByKey("reports.json", "coverSheet");
            return coverSheet;
        }

        public static List<string> GetMarginPages()
        {
            var marginPages = ReadResource.ReadResourceByKey("reports.json", "marginPages");
            return marginPages.Split(',').ToList();
        }

        public static string GetReportName(string report)
        {
            string reportName = $"{report}_{DateTime.Now.ToString("yyyyMMddHHmmss")}.pdf";
            return reportName;
        }
    }
}