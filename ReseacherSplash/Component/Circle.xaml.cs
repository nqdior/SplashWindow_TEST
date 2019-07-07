using System.Threading;
using System.Windows.Controls;

namespace Reseacher
{
    public partial class Circle : UserControl
    {
        private double _value = 0;

        public double Value
        {
            get => _value;
            set
            {
                _value = value;
                ValueChanged();
            }
        }

        public Circle()
        {
            InitializeComponent();

            double value = 0;
            CircleProgressBar.SetValue(ref foreroundBar, value, true);
            CircleProgressBar.SetValue(ref backgroundBar, value, false);
        }

        private void ValueChanged()
        {
            value_label.Text = Value.ToString();
            if (Value == 100)
            {
                value_label.Text = "Complate.";
            }
            double value = Value;
            CircleProgressBar.SetValue(ref foreroundBar, value, true);
            CircleProgressBar.SetValue(ref backgroundBar, value, false);
        }

        private void UserControl_SizeChanged(object sender, System.Windows.SizeChangedEventArgs e)
        {
            Height = Width;
            circleProgressBar.Width = Width;
            circleProgressBar.Height = Width;
        }
    }
}
