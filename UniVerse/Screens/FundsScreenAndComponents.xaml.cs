using System.Diagnostics;
using UniVerse.ViewModels;

namespace UniVerse.Screens;

public partial class FundsScreenAndComponents : ContentPage
{

    private FeesViewModel viewModel;

    public FundsScreenAndComponents()
    {
        viewModel = new FeesViewModel(new Services.RestService());
        BindingContext = viewModel;


        InitializeComponent();
        Shell.SetBackgroundColor(this, Color.FromArgb("#F6F7FB"));
    }

    async void GetFeesAsync()
    {
        await viewModel.GetAllFees();

        foreach (var fee in viewModel.FeesList)
        {
            Debug.WriteLine($"Fees: {fee}");
        }
    }


    protected override void OnAppearing()
    {
        base.OnAppearing();
        GetFeesAsync();
    }

}


