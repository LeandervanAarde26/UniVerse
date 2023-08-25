using UniVerse.Screens;

namespace UniVerse;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();
		MainPage = new LoginScreen();


        //NavigationPage.SetHasNavigationBar(MainPage, false);
        //NavigationPage.SetHasBackButton(MainPage, false);
        //Shell.SetTabBarIsVisible(new AppShell(), false);
        //Shell.SetBackButtonBehavior(new AppShell(), new BackButtonBehavior
        //{
        //    IsVisible = false
        //});
        //Shell.SetBackgroundColor(new AppShell(), Color.FromArgb("#F6F7FB"));

    }
}

