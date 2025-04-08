using FarmaAlert.Models;
using FarmaAlert.Services;
using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Microsoft.Maui.Controls;

namespace FarmaAlert.ViewModels
{
    public class AgregarAlarmaViewModel : BaseViewModel
    {
        private readonly AlarmaService _alarmaService;

        // Propiedades para binding
        private string _NombreMedicamento;
        private string _idPaciente;
        private double _dosisMg;
        private int _frecuenciaHoras;
        private DateTime _fechaInicioTratamiento;
        private TimeSpan _horaInicio;
        private DateTime _fechaFinTratamiento;
        private string _instrucciones;
        private bool _estadoAlarma = true;

        public string NombreMedicamento
        {
            get => _NombreMedicamento;
            set => SetProperty(ref _NombreMedicamento, value);
        }

        public string IdPaciente
        {
            get => _idPaciente;
            set => SetProperty(ref _idPaciente, value);
        }

        public double DosisMg
        {
            get => _dosisMg;
            set => SetProperty(ref _dosisMg, value);
        }

        public int FrecuenciaHoras
        {
            get => _frecuenciaHoras;
            set => SetProperty(ref _frecuenciaHoras, value);
        }

        public DateTime FechaInicioTratamiento
        {
            get => _fechaInicioTratamiento;
            set => SetProperty(ref _fechaInicioTratamiento, value);
        }

        public TimeSpan HoraInicio
        {
            get => _horaInicio;
            set => SetProperty(ref _horaInicio, value);
        }

        public DateTime FechaFinTratamiento
        {
            get => _fechaFinTratamiento;
            set => SetProperty(ref _fechaFinTratamiento, value);
        }

        public string Instrucciones
        {
            get => _instrucciones;
            set => SetProperty(ref _instrucciones, value);
        }

        public bool EstadoAlarma
        {
            get => _estadoAlarma;
            set => SetProperty(ref _estadoAlarma, value);
        }

        // Comandos
        public ICommand GuardarCommand { get; }
        public ICommand CancelarCommand { get; }

        public AgregarAlarmaViewModel(AlarmaService alarmaService)
        {
            _alarmaService = alarmaService;

            GuardarCommand = new Command(async () => await GuardarAlarma());
            CancelarCommand = new Command(async () => await Cancelar());

            InicializarDatos();
        }

        public void InicializarDatos()
        {
            // Valores por defecto
            FechaInicioTratamiento = DateTime.Today;
            HoraInicio = new TimeSpan(8, 0, 0); // 8:00 AM
            FechaFinTratamiento = DateTime.Today.AddDays(7);
            FrecuenciaHoras = 8; // Cada 8 horas por defecto
            DosisMg = 0;
            EstadoAlarma = true;
            Instrucciones = string.Empty;
            NombreMedicamento = string.Empty;
            IdPaciente = string.Empty;
        }

        private async Task GuardarAlarma()
        {
            if (string.IsNullOrWhiteSpace(NombreMedicamento))
            {
                await Shell.Current.DisplayAlert("Error", "Debe ingresar el ID del medicamento", "OK");
                return;
            }

            if (string.IsNullOrWhiteSpace(IdPaciente))
            {
                await Shell.Current.DisplayAlert("Error", "Debe ingresar el ID del paciente", "OK");
                return;
            }

            if (DosisMg <= 0)
            {
                await Shell.Current.DisplayAlert("Error", "La dosis debe ser mayor a 0", "OK");
                return;
            }

            if (FrecuenciaHoras <= 0)
            {
                await Shell.Current.DisplayAlert("Error", "La frecuencia debe ser mayor a 0", "OK");
                return;
            }

            if (FechaFinTratamiento < FechaInicioTratamiento)
            {
                await Shell.Current.DisplayAlert("Error", "La fecha de fin debe ser posterior a la fecha de inicio", "OK");
                return;
            }

            IsBusy = true;

            try
            {
                // Combinamos la fecha y hora de inicio
                DateTime fechaHoraInicio = FechaInicioTratamiento.Date.Add(HoraInicio);

                // Creamos el objeto alarma
                var nuevaAlarma = new AlarmaModel
                {
                    IdAlarma = null, // Se generará automáticamente en la base de datos
                    NombreMedicamento = NombreMedicamento,
                    IdPaciente = IdPaciente,
                    IdUsuario = "67f3e035c12e1cd1a64c0f1e", // Aquí debes obtener el ID del usuario actual
                    DosisMg = DosisMg,
                    FrecuenciaHoras = FrecuenciaHoras,
                    FechaInicioTratamiento = fechaHoraInicio,
                    FechaFinTratamiento = FechaFinTratamiento,
                    Instrucciones = Instrucciones,
                    EstadoAlarma = EstadoAlarma
                };

                // Guardar en la BD
                var result = await _alarmaService.CreateAlarma(nuevaAlarma);

                if (result != null)
                {
                    await Shell.Current.DisplayAlert("Éxito", "Alarma creada correctamente", "OK");
                    await Shell.Current.GoToAsync("..");
                }
                else
                {
                    await Shell.Current.DisplayAlert("Error", "No se pudo crear la alarma", "OK");
                }
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Error", $"Ocurrió un error: {ex.Message}", "OK");
            }
            finally
            {
                IsBusy = false;
            }
        }

        private async Task Cancelar()
        {
            await Shell.Current.GoToAsync("..");
        }
    }
}