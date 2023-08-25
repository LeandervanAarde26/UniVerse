using System;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;
using UniVerse.Screens;

namespace UniVerse.ViewModels
{
    public class CardViewModel
    {
        public async Task NavigateToOverviewScreenAsync(string buttonText)
        {
            if (buttonText == "Student")
            {
                await Shell.Current.GoToAsync(nameof(StudentOverviewScreen));
            }
            else if (buttonText == "Staff Member")
            {
                await Shell.Current.GoToAsync(nameof(StaffMemberOverviewScreen));
            }
        }
    }
}