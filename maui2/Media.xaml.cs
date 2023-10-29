using Plugin.Media;

namespace maui2;

public partial class Media : ContentPage
{
	public Media()
	{
		InitializeComponent();
    }
    private async void OnPickMediaClicked(object sender, EventArgs e)
    {
        var result = await CrossMedia.Current.PickVideoAsync();
        if (result is null) return;

        mediaElement.Source = result?.Path;
       
    }

}