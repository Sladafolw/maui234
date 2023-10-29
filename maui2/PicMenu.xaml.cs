using Microsoft.Maui.Controls;

namespace maui2;

public partial class PicMenu : ContentPage
{
	public PicMenu()
	{
		InitializeComponent();
		BackgroundColor = Colors.DarkKhaki;
	}

    private async void Graphic_Clicked(object sender, EventArgs e)=>await Navigation.PushAsync(new Grapic());

    private async  void Music_Clicked(object sender, EventArgs e)=> await Navigation.PushAsync(new Music());

    private async void About_Clicked(object sender, EventArgs e) => await Navigation.PushAsync(new AboutMe());
    private async void AboutApp_Clicked(object sender, EventArgs e) => await Navigation.PushAsync(new AboutApp());
}