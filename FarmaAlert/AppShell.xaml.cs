namespace FarmaAlert
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute("Pastillas", typeof(Pages.Pastillas));
            Routing.RegisterRoute("Estadisticas", typeof(Pages.Estadisticas));
            Routing.RegisterRoute("Pacientes", typeof(Pages.PacientesPage));
        }
    }
}
