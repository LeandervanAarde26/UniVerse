using UniVerse.Screens;

namespace UniVerse;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new SubjectOverview();
	}
}

