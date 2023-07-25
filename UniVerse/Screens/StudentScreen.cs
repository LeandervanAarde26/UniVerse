using Microsoft.Maui.Layouts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UniVerse.Components;

namespace UniVerse.Screens
{

    public class StudentScreen : ContentPage
    {
        public StudentScreen()
        {

            Grid grid = new()
            {

            };

            FlexLayout layout = new FlexLayout
            {
                Direction = FlexDirection.Row,
                Wrap = FlexWrap.Wrap,
                JustifyContent = FlexJustify.Start,
                AlignItems = FlexAlignItems.Start,
            };

            Content = layout;
            var numbers = new List<int> { 1, 2, 3, 4, 5 };

            foreach (var number in numbers)
            {
                var card = new Cardview();
                layout.Children.Add(card);
            }
        }
    }

}