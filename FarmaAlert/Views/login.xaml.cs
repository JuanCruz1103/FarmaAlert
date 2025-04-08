using FarmaAlert.ViewModels;

namespace FarmaAlert.Pages;

public partial class login : ContentPage
{
    public login(LoginViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}