using UniVerse.ViewModels;
using UniVerse.Models;
using Microsoft.Maui;

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
            if (BindingContext is SubjectModel subject)
            {
                var subjectCardViewModel = new SubjectCardViewModel();
                await subjectCardViewModel.NavigateToOverviewScreenAsync(subject.subject_id);
            }
        }
    }
}