using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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

namespace WPFStickyNoteApp
{
    /// <summary>
    /// Interaction logic for RBColorPicker.xaml
    /// </summary>
    public partial class RBColorPicker : UserControl
    {

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #region Color Properties
        public static readonly DependencyProperty ColorProperty_01 =
            DependencyProperty.Register("Color_01", typeof(Color), typeof(RBColorPicker), new PropertyMetadata());
        public static readonly DependencyProperty ColorProperty_02 =
            DependencyProperty.Register("Color_02", typeof(Color), typeof(RBColorPicker), new PropertyMetadata());
        public static readonly DependencyProperty ColorProperty_03 =
            DependencyProperty.Register("Color_03", typeof(Color), typeof(RBColorPicker), new PropertyMetadata());
        public static readonly DependencyProperty ColorProperty_04 =
            DependencyProperty.Register("Color_04", typeof(Color), typeof(RBColorPicker), new PropertyMetadata());
        public static readonly DependencyProperty ColorProperty_05 =
            DependencyProperty.Register("Color_05", typeof(Color), typeof(RBColorPicker), new PropertyMetadata());
        public static readonly DependencyProperty ColorProperty_06 =
            DependencyProperty.Register("Color_06", typeof(Color), typeof(RBColorPicker), new PropertyMetadata());
        public static readonly DependencyProperty ColorProperty_07 =
            DependencyProperty.Register("Color_07", typeof(Color), typeof(RBColorPicker), new PropertyMetadata());
        public static readonly DependencyProperty ColorProperty_08 =
            DependencyProperty.Register("Color_08", typeof(Color), typeof(RBColorPicker), new PropertyMetadata());
        public static readonly DependencyProperty ColorProperty_09 =
            DependencyProperty.Register("Color_09", typeof(Color), typeof(RBColorPicker), new PropertyMetadata());
        public static readonly DependencyProperty ColorProperty_10 =
            DependencyProperty.Register("Color_10", typeof(Color), typeof(RBColorPicker), new PropertyMetadata());
        public static readonly DependencyProperty ColorProperty_11 =
            DependencyProperty.Register("Color_11", typeof(Color), typeof(RBColorPicker), new PropertyMetadata());
        public static readonly DependencyProperty ColorProperty_12 =
            DependencyProperty.Register("Color_12", typeof(Color), typeof(RBColorPicker), new PropertyMetadata());
        #endregion

        #region Color Property Getter-Setters
        public Color Color_01
        {
            get { return (Color)GetValue(ColorProperty_01); }
            set { SetValue(ColorProperty_01, value); }
        }
        public Color Color_02
        {
            get { return (Color)GetValue(ColorProperty_02); }
            set { SetValue(ColorProperty_02, value); }
        }
        public Color Color_03
        {
            get { return (Color)GetValue(ColorProperty_03); }
            set { SetValue(ColorProperty_03, value); }
        }
        public Color Color_04
        {
            get { return (Color)GetValue(ColorProperty_04); }
            set { SetValue(ColorProperty_04, value); }
        }
        public Color Color_05
        {
            get { return (Color)GetValue(ColorProperty_05); }
            set { SetValue(ColorProperty_05, value); }
        }
        public Color Color_06
        {
            get { return (Color)GetValue(ColorProperty_06); }
            set { SetValue(ColorProperty_06, value); }
        }
        public Color Color_07
        {
            get { return (Color)GetValue(ColorProperty_07); }
            set { SetValue(ColorProperty_07, value); }
        }
        public Color Color_08
        {
            get { return (Color)GetValue(ColorProperty_08); }
            set { SetValue(ColorProperty_08, value); }
        }
        public Color Color_09
        {
            get { return (Color)GetValue(ColorProperty_09); }
            set { SetValue(ColorProperty_09, value); }
        }
        public Color Color_10
        {
            get { return (Color)GetValue(ColorProperty_10); }
            set { SetValue(ColorProperty_10, value); }
        }
        public Color Color_11
        {
            get { return (Color)GetValue(ColorProperty_11); }
            set { SetValue(ColorProperty_11, value); }
        }
        public Color Color_12
        {
            get { return (Color)GetValue(ColorProperty_05); }
            set { SetValue(ColorProperty_12, value); }
        }
        #endregion

        public static readonly DependencyProperty SelColorProperty =
            DependencyProperty.Register("SelColor", typeof(Color), typeof(RBColorPicker), new PropertyMetadata());
        public Color SelColor
        {
            get { return (Color)GetValue(SelColorProperty); }
            set { SetValue(SelColorProperty, value); }
        }

        public static readonly DependencyProperty TextAreaColorProperty = 
            DependencyProperty.Register("TextAreaColor", typeof(Color), typeof(RBColorPicker), new PropertyMetadata());
        public Color TextAreaColor
        {
            get { return (Color)GetValue(TextAreaColorProperty); }
            set { SetValue(TextAreaColorProperty, value); }
        }

        public void SetColorPropertyDefaults()
        {
            Color_01 = (Color)ColorConverter.ConvertFromString("#C70039");
            Color_02 = (Color)ColorConverter.ConvertFromString("#FF5733");
            Color_03 = (Color)ColorConverter.ConvertFromString("#FF8D1A");
            Color_04 = (Color)ColorConverter.ConvertFromString("#FFC300");
            Color_05 = (Color)ColorConverter.ConvertFromString("#EDDD53");
            Color_06 = (Color)ColorConverter.ConvertFromString("#ADD45C");
            Color_07 = (Color)ColorConverter.ConvertFromString("#57C785");
            Color_08 = (Color)ColorConverter.ConvertFromString("#00BAAD");
            Color_09 = (Color)ColorConverter.ConvertFromString("#2A7B9B");
            Color_10 = (Color)ColorConverter.ConvertFromString("#3D3D6B");
            Color_11 = (Color)ColorConverter.ConvertFromString("#511849");
            Color_12 = (Color)ColorConverter.ConvertFromString("#900C3F");
        }

        private void RBPieGeometry_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var sourcePie = e.Source as RBPieGeometry;
            SelColor = ((SolidColorBrush)sourcePie.Fill).Color;
            TextAreaColor = ICustomColor.ChangeColorBrightness(SelColor, (float)0.8);
        }
 
        public RBColorPicker()
        {
            DataContext = this;

            SetColorPropertyDefaults();
            SelColor = Color_01;
            TextAreaColor = ICustomColor.ChangeColorBrightness(SelColor, (float)0.8);

            InitializeComponent();
        }
    }
}
