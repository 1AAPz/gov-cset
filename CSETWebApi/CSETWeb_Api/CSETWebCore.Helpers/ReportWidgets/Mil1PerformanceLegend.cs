﻿using System.Xml.Linq;

namespace CSETWebCore.Helpers.ReportWidgets
{
    public class MIL1PerformanceLegend
    {
        private XDocument _xSvgDoc;
        private XElement _xSvg;


        /// <summary>
        /// Used to create tspan elements, children of text elements
        /// </summary>
        /// <param name="text"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="dy"></param>
        private XElement CreateElement(string text, int x, int? y, string? dy)
        {
            var tspan = new XElement("tspan", text, new XAttribute("style", "font-size: 11px;"));
            tspan.SetAttributeValue("x", x);
            tspan.SetAttributeValue("y", y);
            tspan.SetAttributeValue("dy", dy);
            return tspan;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="height"></param>
        /// <param name="width"></param>
        public MIL1PerformanceLegend()
        {
            _xSvgDoc = new XDocument(new XElement("svg"));
            _xSvg = _xSvgDoc.Root;

            _xSvg.SetAttributeValue("height", "100%");
            _xSvg.SetAttributeValue("width", "100%");


            var g = new XElement("g");

            int rectangle_x = 0;
            int rectangle_y = 20;
            var green = new XElement("rect");
            green.SetAttributeValue("x", rectangle_x);
            green.SetAttributeValue("y", rectangle_y);
            green.SetAttributeValue("fill", WidgetResources.ColorMap["green"]);
            green.SetAttributeValue("height", 15);
            green.SetAttributeValue("width", 15);

            var yellow = new XElement("rect");
            yellow.SetAttributeValue("x", rectangle_x);
            yellow.SetAttributeValue("y", rectangle_y + 17);
            yellow.SetAttributeValue("fill", WidgetResources.ColorMap["yellow"]);
            yellow.SetAttributeValue("height", 15);
            yellow.SetAttributeValue("width", 15);


            var red = new XElement("rect");
            red.SetAttributeValue("x", rectangle_x);
            red.SetAttributeValue("y", rectangle_y + 2 * 17);
            red.SetAttributeValue("fill", WidgetResources.ColorMap["red"]);
            red.SetAttributeValue("height", 15);
            red.SetAttributeValue("width", 15);


            var title = new XElement("text", CreateElement("Legend", 0, 10, null));

            int colorLegend_x = 20;
            int colorLegend_y = 30;
            var colorLegend = new XElement("text",
            CreateElement("= Performed", colorLegend_x, colorLegend_y, null),
            CreateElement("= Incompletely Performed", colorLegend_x, colorLegend_y + 17, null),
            CreateElement("= Not Performed", colorLegend_x, colorLegend_y + 2 * 17, null)
            );


            int questionLegend_x = 160;
            int questionLegend_y = 15;
            var questionLegend = new XElement("text",
            CreateElement("Q1 = Question Number", questionLegend_x, questionLegend_y, null),
            CreateElement("1P = Question Number, People Asset", questionLegend_x, null, "1.2em"),
            CreateElement("1I = Question Number, Information Asset", questionLegend_x, null, "1.2em"),
            CreateElement("1T = Question Number, Technology Asset", questionLegend_x, null, "1.2em"),
            CreateElement("1F = Question Number, Facilities Asset", questionLegend_x, null, "1.2em")
            );

            g.Add(title);
            g.Add(green);
            g.Add(yellow);
            g.Add(red);
            g.Add(colorLegend);
            g.Add(questionLegend);

            _xSvg.Add(g);

        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return _xSvgDoc.ToString();
        }
    }
}
