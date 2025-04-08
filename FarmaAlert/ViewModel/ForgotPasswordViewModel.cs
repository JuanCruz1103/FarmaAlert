using FarmaAlert.Services;
using System.Windows.Input;

namespace FarmaAlert.ViewModels
{
    public class ForgotPasswordViewModel : BaseViewModel
    {
        private readonly AuthService _authService;
        private string _email;

        public string Email
        {
            get => _email;
            set => SetProperty(ref _email, value);
        }

        public ICommand RecoverPasswordCommand { get; }
        public ICommand BackToLoginCommand { get; }

        public ForgotPasswordViewModel(AuthService authService)
        {
            _authService = authService;
            RecoverPasswordCommand = new Command(async () => await RecoverPassword());
            BackToLoginCommand = new Command(async () => await GoBackToLogin());
        }

        private async Task RecoverPassword()
        {
            if (IsBusy) return;

            try
            {
                SetBusy(true);

                if (string.IsNullOrEmpty(Email))
                {
                    ErrorMessage = "Por favor, ingresa tu email electrónico.";
                    return;
                }

                bool result = await _authService.ForgotPassword(Email.Trim());

                if (result)
                {
                    await Shell.Current.DisplayAlert("Éxito", "Se ha enviado un email de recuperación a tu dirección de email.", "OK");
                    await GoBackToLogin();
                }
                else
                {
                    ErrorMessage = "No se pudo procesar la solicitud. Verifica tu email e intenta nuevamente.";
                }
            }
            catch (KeyNotFoundException)
            {
                ErrorMessage = "No se encontró una cuenta con ese email electrónico.";
            }
            catch (Exception ex)
            {
                ErrorMessage = $"Error: {ex.Message}";
            }
            finally
            {
                SetBusy(false);
            }
        }

        private async Task GoBackToLogin()
        {
            await Shell.Current.GoToAsync("..");
        }
    }
}