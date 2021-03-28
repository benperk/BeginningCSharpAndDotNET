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

using System.ServiceModel;
using System.Windows.Media.Animation;

namespace Ch20Ex05
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private AppControlService service;
        private ServiceHost host;
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            service = new AppControlService(this);
            host = new ServiceHost(service);
            host.Open();
        }
        private void Window_Closing(object sender,
           System.ComponentModel.CancelEventArgs e)
        {
            host.Close();
        }
        internal void SetRadius(double radius, string foreTo,
           TimeSpan duration)
        {
            if (radius > 200)
            {
                radius = 200;
            }
            Color foreToColor = Colors.Red;
            try
            {
                foreToColor = (Color)ColorConverter.ConvertFromString(foreTo);
            }
            catch
            {
                // Ignore color conversion failure.
            }
            Duration animationLength = new Duration(duration);
            DoubleAnimation radiusAnimation = new DoubleAnimation(
               radius * 2, animationLength);
            ColorAnimation colorAnimation = new ColorAnimation(
               foreToColor, animationLength);
            AnimatableEllipse.BeginAnimation(Ellipse.HeightProperty,
               radiusAnimation);
            AnimatableEllipse.BeginAnimation(Ellipse.WidthProperty,
               radiusAnimation);
            ((RadialGradientBrush)AnimatableEllipse.Fill).GradientStops[1]
               .BeginAnimation(GradientStop.ColorProperty, colorAnimation);
        }
    }

}
