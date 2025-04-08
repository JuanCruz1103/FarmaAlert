using FarmaAlert.ViewModels;

namespace FarmaAlert.Pages;

public partial class recoberPassword : ContentPage
{
    public recoberPassword(ForgotPasswordViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}