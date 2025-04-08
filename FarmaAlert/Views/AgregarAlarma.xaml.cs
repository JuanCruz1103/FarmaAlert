using FarmaAlert.ViewModels;

namespace FarmaAlert.Pages
{
    public partial class AgregarAlarma : ContentPage
    {
        private AgregarAlarmaViewModel _viewModel;

        public AgregarAlarma(AgregarAlarmaViewModel viewModel)
        {
            InitializeComponent();
            _viewModel = viewModel;
            BindingContext = viewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.InicializarDatos();
        }
    }
}