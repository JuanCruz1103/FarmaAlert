using FarmaAlert.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
namespace FarmaAlert.Services
{
    public class PacienteService
    {
        private readonly HttpClient _httpClient;

        public PacienteService()
        {
            _httpClient = new HttpClient()
            {
                BaseAddress = new Uri("https://x05r82zb-44398.usw3.devtunnels.ms")
            };
        }

        public async Task<List<PacientesModel>> GetAllPacientes()
        {
            var endpoint = "api/Paciente"; // Asegúrate de que este path sea correcto
            Console.WriteLine($"Consultando API en: {_httpClient.BaseAddress}{endpoint}");
            try
            {
                // Usa la variable endpoint aquí
                var response = await _httpClient.GetAsync(endpoint);

                if (!response.IsSuccessStatusCode)
                {
                    Console.WriteLine($"Error en la API: {response.StatusCode}");
                    return new List<PacientesModel>();
                }

                var pacientes = await response.Content.ReadFromJsonAsync<List<PacientesModel>>();
                if (pacientes == null || pacientes.Count == 0)
                {
                    Console.WriteLine("La API no devolvió pacientes.");
                }
                else
                {
                    Console.WriteLine($"Pacientes obtenidos: {pacientes.Count}");
                }
                return pacientes ?? new List<PacientesModel>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener pacientes: {ex.Message} catch");
                return new List<PacientesModel>();
            }
        }
    }
}
