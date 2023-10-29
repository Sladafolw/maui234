using Plugin.Maui.Audio;

namespace maui2;

public partial class Music : ContentPage
{
    public Music()
    {
        InitializeComponent();
    }
    public async void PlayAudio(object sender, EventArgs e)
    {
        if (selectedFilePath == null) { DisplayAlert("error", "Не выбрана песня", "Cancel"); return; }
        if (audio == null) { audio = AudioManager.Current.CreatePlayer(File.Open(selectedFilePath, FileMode.Open)); audio.Play(); }
        else
            if (audio.IsPlaying)
        {
            audio.Pause();
            return;
        }
        else { audio.Play();
        }
    }
    IAudioPlayer audio;

    private string selectedFilePath;

    public string SelectedFilePath
    {
        get => selectedFilePath;
        set
        {
            selectedFilePath = value;
        }
    }

    private async void OnChooseButtonClicked(object sender, EventArgs e)
    {
        var result = await FilePicker.PickAsync(new PickOptions
        {
            FileTypes = new FilePickerFileType(new Dictionary<DevicePlatform, IEnumerable<string>>
                {
                    { DevicePlatform.Android, new[] { "audio/*" } },
                    { DevicePlatform.iOS, new[] { "public.audio" } },
                    { DevicePlatform.macOS, new[] { "public.audio" } },
                    { DevicePlatform.UWP, new[] { ".mp3", ".wav", ".wma" } }
                })
        });

        if (result != null)
        {
            SelectedFilePath = result.FullPath;
            songLabel.Text = result.FileName;
        }
    }

}
