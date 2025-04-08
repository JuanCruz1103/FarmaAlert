// Models/Requests/LoginRequest.cs
public class LoginRequest
{
    public string email { get; set; }
    public string Contrasena { get; set; }
}

// Models/Requests/RegisterRequest.cs
public class RegisterRequest
{
    public string Nombre { get; set; }
    public string email { get; set; }
    public string Contrasena { get; set; }
    public string ConfirmarContrasena { get; set; }
}

// Models/Requests/CreateUsuarioDto.cs
public class CreateUsuarioDto
{
    public string Nombre { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Contrasena { get; set; }
    public string Rol { get; set; } = "Trabajador"; // Valor por defecto
    public string FechaCreacionUsuario { get; set; } 
    // Agrega cualquier otro campo necesario
}

// Models/Requests/RestablecerContrasenaRequest.cs
public class RestablecerContrasenaRequest
{
    public string Token { get; set; }
    public string NuevaContrasena { get; set; }
    public string ConfirmarContrasena { get; set; }
}

// Models/Requests/ValidarTokenRequest.cs
public class ValidarTokenRequest
{
    public string Token { get; set; }
}

// Models/Responses/AuthResponse.cs
public class AuthResponse
{
    public string Token { get; set; }
}