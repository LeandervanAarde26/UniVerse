using Microsoft.Maui.Layouts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;


namespace UniVerse.Components
{
	public class StaffMemberRightBar : ContentView
	{
		public StaffMemberRightBar ()
		{

			Image image = new()
			{
				Source = ImageSource.FromFile("staff_member_right_bar.png"),
				MaximumHeightRequest = 350,
				Aspect = Aspect.Center,
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.Start,

			};

			Label frameHeading = new()
			{
				Text = "Assign Subject",
                TextColor = Color.FromHex("#2B2B2B"),
                FontAttributes = FontAttributes.Bold,
				FontSize = 24,
				Margin = new Thickness(0,10)
            };

			SearchBar search = new()
			{
				BackgroundColor = Color.FromHex("#F6F7FB"),
                Margin = new Thickness(0, 10),
				TextColor = Color.FromHex("#2B2B2B"),
                Placeholder = "Search Subject",
			};


            Button button = new()
            {
                Text = "Assign to Subject ",
                BackgroundColor = Color.FromHex("#2B2B2B"),
                Margin = new Thickness(0, 12)
            };

			Button delete = new()
			{


				Margin = new Thickness(8, 12),
				Text = "Delete Staff Member",
				BackgroundColor = Color.FromHex("#FF4040"),
				ImageSource = ImageSource.FromFile("trash.png")
			

			};

            StackLayout deleteStack = new()
            {
                VerticalOptions = LayoutOptions.End,
                Children =
					{
						delete
					}
            };

            StackLayout stack = new()
			{

				Children =
				{
                    frameHeading,
					search,
					button,
				}
			};


			Frame frame = new()
			{
				BackgroundColor = Colors.White,
				CornerRadius = 15,
				BorderColor = Colors.Transparent,
				Margin = new Thickness(5),
				Content = stack
			};
			FlexLayout layout = new()
			{
				Direction = Microsoft.Maui.Layouts.FlexDirection.Column,
			
				Children =
				{
					image,
					frame,
                    deleteStack
                }
			};

			FlexLayout.SetGrow(deleteStack, 1);
		
		
			Content = layout;
		}
	}
}