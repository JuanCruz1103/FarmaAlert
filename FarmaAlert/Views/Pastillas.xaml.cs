using FarmaAlert.Views;
using FarmaAlert.Models;
using FarmaAlert.Services;
using FarmaAlert.ViewModels;
namespace FarmaAlert.Pages;
public partial class Pastillas : ContentPage
{
    private readonly AlarmaViewModel _viewModel;

    public Pastillas(AlarmaViewModel viewModel)
    {
        InitializeComponent(); // Aseg�rate de que el archivo XAML correspondiente est� presente y correctamente nombrado
        _viewModel = viewModel;
        BindingContext = viewModel;
    }
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await _viewModel.LoadAlarmas();
    }
}
