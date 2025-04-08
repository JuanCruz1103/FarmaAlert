using FarmaAlert.ViewModel;
using FarmaAlert.ViewModels;

namespace FarmaAlert.Pages
{
    [QueryProperty(nameof(AlarmaId), "id")]
    public partial class EditarAlarma : ContentPage
    {
        private EditarAlarmaViewModel _viewModel;

        public string AlarmaId { get; set; }

        public EditarAlarma(EditarAlarmaViewModel viewModel)
        {
            InitializeComponent();
            _viewModel = viewModel;
            BindingContext = viewModel;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            if (!string.IsNullOrEmpty(AlarmaId))
            {
                await _viewModel.CargarAlarma(AlarmaId);
            }
        }
    }
}