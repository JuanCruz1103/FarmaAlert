using System.Text.RegularExpressions;

namespace FarmaAlert.Pages;

public partial class Register : ContentPage
{
    public Register()
    {
        InitializeComponent();
    }

    private async void Registerbtn_Clicked(object sender, EventArgs e)
    {
        string userName = EntryUserName.Text?.Trim();
        string email = EntryEmail.Text?.Trim();
        string password = EntryPassword.Text;
        string confirmPassword = EntryConfirmPassword.Text;

        if (string.IsNullOrEmpty(userName) ||
            string.IsNullOrEmpty(email) ||
            string.IsNullOrEmpty(password) ||
            string.IsNullOrEmpty(confirmPassword))
        {
            await DisplayAlert("Error", "Todos los campos son obligatorios.", "OK");
            return;
        }

        if (!IsValidEmail(email))
        {
            await DisplayAlert("Error", "Correo electrónico no válido.", "OK");
            return;
        }

        if (!IsValidPassword(password))
        {
            await DisplayAlert("Error", "La contraseña debe tener al menos 8 caracteres, una mayúscula, un número y un carácter especial.", "OK");
            return;
        }

        if (password != confirmPassword)
        {
            await DisplayAlert("Error", "Las contraseñas no coinciden.", "OK");
            return;
        }

        await DisplayAlert("Éxito", "Registro exitoso.", "OK");
        await Navigation.PopAsync();
    }

    private async void OnBackToLoginClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync(); // Regresar a la página anterior (Login)
    }

    private bool IsValidEmail(string email)
    {
        return Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
    }

    private bool IsValidPassword(string password)
    {
        return Regex.IsMatch(password, @"^(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$");
    }
}
