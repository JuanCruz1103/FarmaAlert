using FarmaAlert.Pages;

namespace FarmaAlert;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();

        MainPage = new NavigationPage(new login());
    }
}   
