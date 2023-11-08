using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;
using UniVerse.Screens;

namespace UniVerse.ViewModels
{
    public class CardViewModel
    {
        public async Task NavigateToOverviewScreenAsync(string buttonText, int id)
        {
            if (buttonText == "Student")
            {
                var viewModel = new NavOverviewViewModel { NavigationParameter = id };
                await Shell.Current.Navigation.PushAsync(new StudentOverviewScreen(id){ BindingContext = viewModel });
            }
            else if (buttonText == "Staff Member")
            {
                var viewModel = new NavOverviewViewModel { NavigationParameter = id };
                await Shell.Current.Navigation.PushAsync(new StaffMemberOverviewScreen { BindingContext = viewModel });
            }
        }
    }
}