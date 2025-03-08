using Microsoft.Maui.Graphics;

namespace FarmaAlert.Pages;

public partial class Estadisticas : ContentPage
{
    public Estadisticas()
    {
        InitializeComponent();

        //// Asignar los dibujos a las vistas gráficas
        BindingContext = new
        {
            TomadasDrawable = new CircularChartDrawable(64, Colors.Green),
            NoTomadasDrawable = new CircularChartDrawable(40, Colors.Red)
        };
    }
}

public class CircularChartDrawable : IDrawable
{
    private readonly float _percentage;
    private readonly Color _color;

    public CircularChartDrawable(float percentage, Color color)
    {
        _percentage = percentage;
        _color = color;
    }

    public void Draw(ICanvas canvas, RectF dirtyRect)
    {
        // Fondo del círculo
        canvas.StrokeColor = Colors.LightGray;
        canvas.StrokeSize = 20;
        canvas.DrawCircle(dirtyRect.Center, 60);

        // Gráfico del porcentaje
        canvas.StrokeColor = _color;
        canvas.DrawArc(dirtyRect.Center.X - 60, dirtyRect.Center.Y - 60, 120, 120,
                       -90, 360 * (_percentage / 100), true, false);

        // Porcentaje en el centro
        canvas.FontSize = 24;
        canvas.FontColor = Colors.Black;
        //canvas.DrawString($"{_percentage}%",
        //          dirtyRect.Center.X, dirtyRect.Center.Y,
        //          HorizontalAlignment.Center, VerticalAlignment.Center);
    }
}