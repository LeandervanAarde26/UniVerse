using UniVerse.ViewModels;
using UniVerse.Models;

namespace UniVerse.Components
{
    public partial class SubjectCard : ContentView
    {
        public SubjectCard()
        {
            InitializeComponent();
            BindingContext = this;
        }

        public async void ViewSubject(object sender, EventArgs e)
        {
            if (BindingContext is SubjectWithEnrollments subject)
            {
                var subjectCardViewModel = new SubjectCardViewModel();
                await subjectCardViewModel.NavigateToOverviewScreenAsync(subject.subjectId);
            }
        }
    }
}