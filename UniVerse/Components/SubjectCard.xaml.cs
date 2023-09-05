using UniVerse.ViewModels;
using UniVerse.Models;

namespace UniVerse.Components
{
    public partial class SubjectCard : ContentView
    {
        private bool isEventSubscribed = false;

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
    }
}