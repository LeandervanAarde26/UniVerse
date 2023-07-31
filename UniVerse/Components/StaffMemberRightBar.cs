using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace UniVerse.Components
{
	public class StaffMemberRightBar : ContentView
	{
		public StaffMemberRightBar ()
		{
			Content = new StackLayout {
				Children = {
					new Label { Text = "Welcome to Xamarin.Forms!" }
				}
			};
		}
	}
}