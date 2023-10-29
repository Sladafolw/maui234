using Camera.MAUI;
using Plugin.Media;
using Plugin.Media.Abstractions;
using System.IO.Compression;

namespace maui2;

public partial class CameraM : ContentPage
{
	public CameraM()
	{
		InitializeComponent();
    }
    private async void OnPickPhotoClicked(object sender, EventArgs e)
    {
        var result = await CrossMedia.Current.PickPhotoAsync();
        if (result is null) return;

        UploadedOrSelectedImage.Source = result.Path;

        var fileInfo = new FileInfo(result?.Path);
        var fileLength = fileInfo.Length;

        FileSizeLabel.Text = $"Image size: {fileLength / 1000} kB";
    }

    private async void OnTakePhotoClicked(object sender, EventArgs e)
    {
        var options = new StoreCameraMediaOptions { SaveToAlbum = true };
        var result = await CrossMedia.Current.TakePhotoAsync(options);
        if (result is null) return;

        UploadedOrSelectedImage.Source = result?.Path;

        var fileInfo = new FileInfo(result?.Path);
        var fileLength = fileInfo.Length;

        FileSizeLabel.Text = $"Image size: {fileLength / 1000} kB";
    }
   
}