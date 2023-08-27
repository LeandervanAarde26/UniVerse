using System;
using System.Diagnostics;
using UniVerse.Screens;

namespace UniVerse.ViewModels
{
	public class SubjectCardViewModel
	{
        public async Task NavigateToOverviewScreenAsync(int id)
        {
            var viewModel = new StudentMemberOverviewViewModel { NavigationParameter = id };
            await Shell.Current.Navigation.PushAsync(new SubjectOverview { BindingContext = viewModel });
            Debug.WriteLine(id);
        }
    }
}

