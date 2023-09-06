using UniVerse.ViewModels;
using UniVerse.Models;
using System.Globalization;

namespace UniVerse.Components
{
    public partial class SubjectCard : ContentView
    {
        private bool isEventSubscribed = false;
        private bool isActive = false;

        public SubjectCard()
        {
            InitializeComponent();
            BindingContext = this;
        }

        public async void ViewSubject(object sender, EventArgs e)
        {
            if (!isEventSubscribed)
            {
                isEventSubscribed = true;

                if (BindingContext is SubjectWithEnrollments subject)
                {
                    await SubjectCardViewModel.NavigateToOverviewScreenAsync(subject.subjectId);
                }
            }
        }

        private void ToggleButton(object sender, EventArgs e)
        {
            isActive = !isActive;
            UpdateButtonAppearance();
        }

        private void UpdateButtonAppearance()
        {
            toggleButton.Text = isActive ? "Active" : "Inactive";
            toggleButton.BackgroundColor = isActive ? Color.FromArgb("#29BA56") : Color.FromArgb("#FF4040");
        }
    }
}