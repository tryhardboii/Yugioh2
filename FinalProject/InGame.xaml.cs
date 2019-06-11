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
using System.Windows.Shapes;

namespace FinalProject
{
    /// <summary>
    /// Interaction logic for InGame.xaml
    /// </summary>
    public partial class InGame : Window
    {
        public InGame()
        {
            InitializeComponent();
        }
        //scale ui part
        public static readonly DependencyProperty ScaleValueProperty = DependencyProperty.Register("ScaleValue", typeof(double), typeof(InGame), new UIPropertyMetadata(1.0, new PropertyChangedCallback(OnScaleValueChanged), new CoerceValueCallback(OnCoerceScaleValue)));
        private static object OnCoerceScaleValue(DependencyObject o, object value)
        {
            InGame inGame = o as InGame;
            if (inGame != null)
                return inGame.OnCoerceScaleValue((double)value);
            else
                return value;
        }
        public static void OnScaleValueChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
        {
            InGame inGame = o as InGame;
            if (inGame != null)
                inGame.OnScaleValueChanged((double)e.OldValue, (double)e.NewValue);
        }
        protected virtual double OnCoerceScaleValue(double value)
        {
            if (double.IsNaN(value))
                return 1.0f;
            value = Math.Max(0.1, value);
            return value;
        }
        protected virtual void OnScaleValueChanged(double oldValue, double newValue)
        {

        }
        public double ScaleValue
        {
            get
            {
                return (double)GetValue(ScaleValueProperty);

            }
            set
            {
                SetValue(ScaleValueProperty, value);
            }
        }
        private void MainGrid_SizeChanged(object sender, EventArgs e)
        {
            CalculateScale();
        }
        private void CalculateScale()
        {
            double yScale = ActualHeight / 768f;//250 initially
            double xScale = ActualWidth / 1366f;//200 initially
            double value = Math.Min(xScale, yScale);
            ScaleValue = (double)OnCoerceScaleValue(myInGame, value);

            //MessageBox.Show(System.IO.Path.GetDirectoryName(System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName));
            //Uri path = new Uri(@".\data\monster1", UriKind.Absolute);
            //Image1.Source = new BitmapImage(path);

        }//scale ui part ends
        

        private void InfoBarScroll_Scroll(object sender, System.Windows.Controls.Primitives.ScrollEventArgs e)
        {
            
        }
    }
}
