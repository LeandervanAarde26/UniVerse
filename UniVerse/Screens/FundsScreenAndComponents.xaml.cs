using UniVerse.ViewModels;

namespace UniVerse.Screens;

public partial class FundsScreenAndComponents : ContentPage
{
    private LecturerFeesViewModel viewModel;

    private StudentFeesViewModel studentViewModel;
    private AdminFeesViewModel adminViewModel;

    public FundsScreenAndComponents()
    {
        InitializeComponent();

        Shell.SetBackgroundColor(this, Color.FromArgb("#F6F7FB"));
        viewModel = new LecturerFeesViewModel(new Services.RestService());
        studentViewModel = new StudentFeesViewModel(new Services.RestService());
       adminViewModel = new AdminFeesViewModel(new Services.RestService());
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        fundLayout.Children.Clear();

        var staff = viewModel.GetAllFees();
        var student = studentViewModel.GetStudentAllFees();

        //await Task.WhenAll(staff, student);

        await studentViewModel.GetStudentAllFees();

        await viewModel.GetAllFees();

        await adminViewModel.GetAdminAllFees();

        var totalAdmin = 0;

        foreach (var adminfee in adminViewModel.AdminList)
        {

            totalAdmin += adminfee.admin_payment;


            var adminFundsCard = new Components.AdminFundsCard
            {
                BindingContext = adminfee
            };
            fundLayout.Children.Add(adminFundsCard);
        }


         decimal totalLectureFees = 0;

        foreach (var fee in viewModel.FeesList)
        {

            totalLectureFees += fee.monthlyIncome;

            var lecturerFundsCard = new Components.LecturerFundsCard
            {
                BindingContext = fee
            };
            fundLayout.Children.Add(lecturerFundsCard);
        }


        var totalStudentFees = 0;

        foreach (var studentfee in studentViewModel.StudentList)
        {

            totalStudentFees += studentfee.studentMonthlyFee;

            var studentFundsCard = new Components.StudentFundsCard
            {
                BindingContext = studentfee
            };
            fundLayout.Children.Add(studentFundsCard);
        }


        var TotalIncome = totalAdmin + totalLectureFees + totalStudentFees;

        var TotalSalaries = totalLectureFees;

        totalIncomeLabel.Text = TotalIncome.ToString("C");

        totalSalaryLabel.Text = TotalSalaries.ToString("C");

    }
}






