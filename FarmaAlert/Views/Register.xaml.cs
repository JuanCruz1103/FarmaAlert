using FarmaAlert.ViewModels;

namespace FarmaAlert.Pages;

public partial class Register : ContentPage
{
    public Register(RegisterViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}