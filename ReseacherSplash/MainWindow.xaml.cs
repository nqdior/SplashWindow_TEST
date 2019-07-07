using MetroRadiance.UI;
using MetroRadiance.UI.Controls;
using Reseacher.Properties;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace Reseacher
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        MainViewModel model = new MainViewModel();

        public MainWindow()
        {
            InitializeComponent();

            drawer.MediaEnded += LogoDrawer_MediaEnded;
            Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#201E1E");

            DataContext = model;
            ThemeService.Current.ChangeAccent(Accent.Purple);
        }

        private void MetroWindow_Loaded(object sender, RoutedEventArgs e)
        {
            ver_label.Content = Version.Information;

            Main();
            Percent();
        }

        async void Main()
        {
            foreach (var index in Enumerable.Range(1, 2))
            {
                if (index == 1)
                {
                    var heavyResult = await RunTask(index);
                    model.BindText1 = heavyResult;
                }
                else
                {
                    var heavyResult = await RunTask(index);
                    model.BindText2 = heavyResult;
                }
            }
        }
        async Task<string> RunTask(int index)
        {
            await Task.Delay(1000 * index); // 2.
            return "hogehoge"; // 3.
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
