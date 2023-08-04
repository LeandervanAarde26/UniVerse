namespace UniVerse.Components
{
    public class AssignedSubject : ContentView

    { 
        public AssignedSubject ()
		{
            
            Label subjectName = new()
            {
             
                Text = "Interactive Development",
                TextColor = Color.FromArgb("#2B2B2B"),
                FontAttributes = FontAttributes.Bold,
                FontSize = 20,
                HorizontalOptions = LayoutOptions.Start,
                VerticalOptions = LayoutOptions.Center
            };

            Label subjectCode = new()
            {
                Text = "IDV 300",
                TextColor = Color.FromArgb("#717171"),
                FontSize = 14,
                HorizontalOptions = LayoutOptions.Start,
                VerticalOptions = LayoutOptions.Center,
                
            };



            StackLayout stack = new()
            {
                HorizontalOptions = LayoutOptions.Start,
                VerticalOptions = LayoutOptions.Center,
 
                Children =
                {
                      subjectName,
                      subjectCode
                }
            };


            Image subjectImage = new()
            {

                Aspect = Aspect.AspectFit,
                MaximumHeightRequest = 150,
                VerticalOptions = LayoutOptions.Center,
                Source = "devreplace.png",
                Margin = new Thickness(-10, 0, 10, 0)


            };



            Grid grid = new()
            {
                RowDefinitions = new RowDefinitionCollection
                {
                    new RowDefinition{Height = GridLength.Star}
                },

                ColumnDefinitions = new ColumnDefinitionCollection
                {
                 new ColumnDefinition { Width = new GridLength(40, GridUnitType.Star) },
                 new ColumnDefinition { Width = new GridLength(60, GridUnitType.Star) }
                }
            };

            grid.Children.Add(subjectImage);
            Grid.SetRow(subjectImage, 0);
            Grid.SetRowSpan(subjectImage, 2);
            Grid.SetColumn(subjectImage, 0);

            grid.Children.Add(stack);
            Grid.SetRow(stack, 0);
            Grid.SetColumn(stack, 1);

            //grid.Children.Add(subjectCode);
            //Grid.SetRow(subjectCode, 0);
            //Grid.SetColumn(subjectCode, 1);

            Frame frame = new()
            {
                CornerRadius = 20,
                HeightRequest = 240,
                BackgroundColor = Color.FromArgb("#DFE9FF"),
                BorderColor = Color.FromArgb("#DFE9FF"),
                Margin = new Thickness(12, 10),
     
                Content = grid,
           
            };

            Content = frame;
        }
	}
}