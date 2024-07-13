
using System.Diagnostics;
using System.IO;
using System.Media;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;


namespace EasyKana
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {   
        public MainWindow()
        {
            InitializeComponent();
            volumeSlider.Value = 100;
        }

        private MediaPlayer currentPlayer;
        private void PlayVoice(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            var uri = new Uri(System.Environment.CurrentDirectory + $@"\Resources\Audio\{button.Tag}.mp3", UriKind.RelativeOrAbsolute);
            var player = new MediaPlayer();
            
            player.MediaFailed += (o, args) =>
            {
                Debug.WriteLine(args.ErrorException);
            };

            // Stop the current player, start the new immediatly
            if (currentPlayer != null)
            {
                currentPlayer.Stop();
            }
            currentPlayer = player;
            currentPlayer.Volume = volumeSlider.Value / 100.0;
            currentPlayer.Open(uri);
            currentPlayer.Play();
        }
    }
}