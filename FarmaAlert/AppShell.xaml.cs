namespace FarmaAlert
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute("Pastillas", typeof(Pages.Pastillas));
            Routing.RegisterRoute("Estadisticas", typeof(Pages.Estadisticas));
            Routing.RegisterRoute("Pacientes", typeof(Pages.Pacientes));
            Routing.RegisterRoute("register", typeof(Pages.Register));
            Routing.RegisterRoute("forgotpassword", typeof(Pages.recoberPassword));
            Routing.RegisterRoute("login", typeof(Pages.login));
            Routing.RegisterRoute("AgregarAlarma", typeof(Pages.AgregarAlarma));
            Routing.RegisterRoute("EditarAlarma", typeof(Pages.EditarAlarma));
            Routing.RegisterRoute("DispensarPastilla", typeof(Pages.DispensarPastilla));
        }
    }
}