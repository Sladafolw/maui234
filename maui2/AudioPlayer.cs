using Microsoft.Maui.Controls;

namespace MusicPlayer
{
    public class AudioPlayer : View
    {
        public static readonly BindableProperty SourceProperty = BindableProperty.Create(
            nameof(Source),
            typeof(string),
            typeof(AudioPlayer),
            null);

        public string Source
        {
            get => (string)GetValue(SourceProperty);
            set => SetValue(SourceProperty, value);
        }
    }
}