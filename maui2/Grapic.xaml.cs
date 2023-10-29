using _2DGraphicsDrawing;

namespace maui2;

public partial class Grapic : ContentPage
{
	public Grapic()
	{
		InitializeComponent();
   
    }
    string x1;
    string x2;
    private void Points((double aI, double bI, double cI) data)
    {
        GraphicsDrawable.points.Clear();
        for (int i = -10; i <= 10; i++)
        {
            GraphicsDrawable.points.Add(new Point(i, (data.aI * Math.Pow(i, 2) + data.bI * i + data.cI) / 30));
        }
        GraphicsDrawable.points = GraphicsDrawable.points.Normalize();
    }
    private void Coordinates()
    {
        GraphicsDrawable.coordinates.Clear();
        GraphicsDrawable.coordinates.Add(new Point(100, 100));
        GraphicsDrawable.coordinates.Add(new Point(100, 200));
        GraphicsDrawable.coordinates.Add(new Point(100, 0));
        GraphicsDrawable.coordinates.Add(new Point(100, 100));
        GraphicsDrawable.coordinates.Add(new Point(0, 100));
        GraphicsDrawable.coordinates.Add(new Point(200, 100));

    }
    private void CalculateD((double aI, double bI, double cI) data)
    {
        if (data.aI < 0)
        {
            data.aI *= -1;
            data.bI *= -1;
            data.cI *= -1;
        }
        double D = Math.Pow(data.bI, 2) - 4 * data.aI * data.cI;
        if (D < 0)
        {
            x1 = (-data.bI / (2 * data.aI)).ToString();
            x2 = "нету";
        }
        else
        {
            x1 = (-(data.bI + Math.Sqrt(D)) / (2 * data.aI)).ToString();
            x2 = (-(data.bI - Math.Sqrt(D)) / (2 * data.aI)).ToString();
        }
        Result.IsVisible = true;
        Result.Text = $"x1= {x1},x2= {x2},D={D}";
        DisplayAlert("Посчитано", $"x1= {x1},x2= {x2},D={D}", "Ок");
    }
    private bool TryParseData(out (double aI, double bI, double cI) result)
    {
        result = default;
        if (!double.TryParse(a.Text, out var aI) ||
            !double.TryParse(b.Text, out var bI) ||
        !double.TryParse(c.Text, out var cI))
        {
            return false;
        }

        result = (aI, bI, cI);
        return true;
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        try
        {
            if (!TryParseData(out var data))
            {

                return;
            }

            Points(data);
            Coordinates();
            CalculateD(data);
            MyGrid.Children.Clear();
            GraphicsView graphicsView = new GraphicsView();
            graphicsView.Drawable = new GraphicsDrawable();
            graphicsView.HeightRequest = 200; graphicsView.WidthRequest = 200;
            MyGrid.Children.Add(graphicsView);

        }
        catch (Exception ex)
        {
            DisplayAlert("error", "Check your numbers", "Cancel");
        }
    }
}
