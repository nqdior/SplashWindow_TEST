using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Reseacher
{
    /// <summary>
    /// UserControl1.xaml の相互作用ロジック
    /// </summary>
    public partial class LogoDrawer : UserControl
    {
        // public string LogoLabel { set => label.Content = value; }

        public LogoDrawer()
        {
            InitializeComponent();
        }

        private void MyGif_MediaEnded(object sender, RoutedEventArgs e)
        {
            myGif.Position = new TimeSpan(0, 0, 1);
            myGif.Play();

            MediaEnded(sender, e);
        }
        public delegate void MediaEndedHandler(object sender, RoutedEventArgs e);
        public event MediaEndedHandler MediaEnded;
    }
}
