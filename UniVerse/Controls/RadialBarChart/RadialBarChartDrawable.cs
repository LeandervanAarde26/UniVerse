using System;
using Microsoft.Maui.Graphics;
using Microsoft.Maui.Graphics.Text;

using static System.Net.Mime.MediaTypeNames;
using Color = Microsoft.Maui.Graphics.Color;
using Font = Microsoft.Maui.Graphics.Font;

namespace UniVerse.Controls.RadialBarChart
{
    public class RadialBarChartDrawable : IDrawable
    {
        private readonly RadialBarChart _chart;

        public RadialBarChartDrawable(RadialBarChart chart) => _chart = chart;

        public void Draw(ICanvas canvas, RectF dirtyRect)
        {
            if (_chart.Entries == null)
            {
                return;
            }

            var maxValue = _chart.MaxValue >= 0 ?
                _chart.MaxValue :
                _chart.Entries.Max(x => x.Value);

            var center = dirtyRect.Center;

            var spacing = (float)_chart.BarSpacing;
            var radius = (float)_chart.InnerRadius;
            var fontSize = (float)_chart.FontSize;
            var barThickness = (float)_chart.BarThickness;
            var legend = _chart.LegendText;
            var legend2 = _chart.LegendText2;
            var firstEntry = _chart.Entries.FirstOrDefault().Color;
      
            canvas.StrokeSize = barThickness;
            canvas.FontColor = _chart.TextColor;
            canvas.FontSize = fontSize;
            canvas.StrokeLineCap = _chart.RoundedCaps ? LineCap.Round : LineCap.Butt;


            var startingAngle = 90;
            var angleSpan =  360;
            var isFullCircle = angleSpan == 360;

            foreach (var entry in _chart.Entries.Reverse())
            {
                // Draw bar background
                canvas.StrokeColor =
                    _chart.BarBackgroundColor ??
                    ToBackgroundColor(entry.Color);

                if (isFullCircle)
                {
                    canvas.DrawCircle(center.X, center.Y, radius);
                }
                else
                {
                    DrawArc(canvas, center, radius, startingAngle, startingAngle - angleSpan);
                }
              
                // Draw bar
                canvas.StrokeColor = entry.Color;

                if (entry.Value == maxValue && isFullCircle)
                {
                    canvas.DrawCircle(center.X, center.Y, radius);
                }
                else
                {
                    DrawArc(canvas, center, radius, startingAngle, startingAngle - (float)(entry.Value * angleSpan / maxValue));
                }

                radius += spacing;

            }
            DrawCenterText(canvas, center, fontSize);
            DrawLegend(canvas, center, radius, fontSize, _chart.Entries.FirstOrDefault().Color, legend, legend2);
        
        }


        private static void DrawArc(ICanvas canvas, PointF center, float radius, float start, float end)
        {
            // Angle 0 is the right
            // Degrees go counter clockwise, meaning 90 is top
            canvas.DrawArc(
                center.X - radius,
                center.Y - radius,
                2 * radius,
                2 * radius,
                startAngle: start,
                endAngle: end,
                clockwise: true,
                closed: false);
        }

        private static void DrawCenterText(ICanvas canvas, PointF center , float fontSize)
        {
            string text = "100 \nCredits";
            var textSize = canvas.GetStringSize(
                text,
                Font.Default,
                fontSize,
                HorizontalAlignment.Center,
                VerticalAlignment.Center);

            var textRect = new Rect(
                center.X - textSize.Width / 2,
                center.Y - textSize.Height / 2,
                Math.Ceiling(textSize.Width) + fontSize / 3f,
                Math.Ceiling(textSize.Height));

           canvas.DrawString(
                   text,
                   textRect,
                   HorizontalAlignment.Center,
                   VerticalAlignment.Center);
        }

        private static void DrawLegendCircle(ICanvas canvas, PointF center, string text, float radius, Color dotColor, float fontSize, int height)
        {

         var textSize = canvas.GetStringSize(
         text,
         Font.Default,
         fontSize,
         HorizontalAlignment.Center,
         VerticalAlignment.Center);


            float dotSize = 10;
            var dotCenter = new PointF(center.X - textSize.Width / 1, center.Y + radius - textSize.Height + height);

            // Draw the ellipse (dot)
            canvas.StrokeColor = dotColor;
            canvas.DrawCircle(dotCenter.X - dotSize / 2, dotCenter.Y - dotSize / 2, dotSize);


            var dotCenter2 = new PointF(center.X - textSize.Width / 1, center.Y + radius - textSize.Height + height);

            canvas.DrawCircle(dotCenter2.X - dotSize / 2, dotCenter2.Y - dotSize / 2, dotSize);

            canvas.FontSize = fontSize;
            canvas.FontColor = Colors.Black;
        }
       private static void DrawLegend(ICanvas canvas, PointF center, float radius, float fontSize, Color barBackgroundColor, string legString, string legString2)
        {

       
            string legendText = legString;
            string legendText2 = legString2;
      
            var textSize = canvas.GetStringSize(
                     legendText,
                     Font.Default,
                     fontSize,
                     HorizontalAlignment.Center,
                     VerticalAlignment.Center);

            var textRect = new Rect(
                center.X - textSize.Width / 2,
                center.Y + radius / 2 + 40,
                Math.Ceiling(textSize.Width) + fontSize / 3f,
                Math.Ceiling(textSize.Height) + fontSize / 3f);

            var textRect2 = new Rect(
                center.X - textSize.Width / 2,
                center.Y + radius / 2 + 61,
                Math.Ceiling(textSize.Width) + fontSize / 3f,
                Math.Ceiling(textSize.Height) + fontSize / 3f);

            canvas.DrawString(
             legendText,
             textRect,
            HorizontalAlignment.Left,
            VerticalAlignment.Center);

            canvas.DrawString(
                legendText2,
                textRect2,
                HorizontalAlignment.Left,
                VerticalAlignment.Center);

            //DrawLegendCircle(canvas, center, legendText, radius, barBackgroundColor, fontSize, 31);
            DrawLegendCircle(canvas, center, legendText, radius, barBackgroundColor, fontSize, 31);
            DrawLegendCircle(canvas, center, legendText, radius, Color.FromArgb("#E9F0FF"), fontSize, 55);
        }

        private static Color ToBackgroundColor(Color color)
        {
            return new Color(color.Red, color.Green, color.Blue, color.Alpha * 0.1f);
        }
    }
}
