using MetroRadiance.UI.Controls;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace Reseacher
{
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            InitializeComponent();

            /* ajust logo background color.*/
            Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#201E1E");
        }

        private void MetroWindow_Loaded(object sender, RoutedEventArgs e)
        {
            ver_label.Content = Version.Information;
            Percent();
        }

        async void Percent()
        {
            for (var i = 0; i <= 100; i++)
            {
                label_per.Content = "データベース状態確認中... " + await progress(i);
            }
            for (var i = 0; i <= 100; i++)
            {
                label_per.Content = "メインプロセス起動中 " + await progress(i);
            }
            label_per.Content = "起動設定完了 システム起動";
        }

        async Task<string> progress(int percent)
        {
            await Task.Delay(16);
            return $"{percent}% ";
        }

        private void LogoDrawer_MediaEnded(object sender, RoutedEventArgs e) => Close();
        
    }
}
