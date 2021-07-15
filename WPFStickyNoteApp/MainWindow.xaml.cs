using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        ViewModel vm;

        public MainWindow()
        {
            InitializeComponent();

            vm = new ViewModel();
            this.DataContext = vm;

            ConsoleAllocator.ShowConsoleWindow();
        }

        private void Button_Close_Click(object sender, RoutedEventArgs e)
        {
            if(Application.Current.Windows.Count == 1)
            {
                Application.Current.Shutdown();
            }
            else
            {
                this.Close();
            }
        }

        private void Button_NewWindow_Click(object sender, RoutedEventArgs e)
        {
            MainWindow newWindow = new MainWindow();
            newWindow.Show();
        }

        private void Button_PinWindowToTopToggle_Click(object sender, RoutedEventArgs e)
        {
            if (this.Topmost)
            {
                this.Topmost = false;
            }
            else
            {
                this.Topmost = true;
            }
        }

        private void DockPanel_MouseDown(object sender, MouseButtonEventArgs e)
        {
            switch (e.ChangedButton)
            {
                case MouseButton.Left:
                    if (e.ClickCount == 1)
                    {
                        this.DragMove();
                    }
                    else if (e.ClickCount == 2)
                    {
                        ShowBGColorPicker();
                    }
                    break;
                case MouseButton.Middle:
                    break;
                case MouseButton.Right:
                    vm.TitleBarBrush = new SolidColorBrush(Colors.LightYellow);
                    // TODO: Add logic to open right click menu
                    break;
                case MouseButton.XButton1:
                    break;
                case MouseButton.XButton2:
                    break;
                default:
                    break;
            }
        }

        private void ColorPickerWheel_LostFocus(object sender, RoutedEventArgs e)
        {
            if (vm.BGColorPickerVisibility == Visibility.Visible)
            {
                vm.BGColorPickerVisibility = Visibility.Hidden;
            }
        }

        private void ShowBGColorPicker()
        {
            vm.BGColorPickerVisibility = Visibility.Visible;
            ColorPickerWheel.Focus();
        }
    }

    // From https://stackoverflow.com/questions/31978826/is-it-possible-to-have-a-wpf-application-print-console-output/31978833
    // Class to show/hide console for Windows Forms and/or WPF-type platforms which hide it when debugging
    internal static class ConsoleAllocator
    {
        [DllImport(@"kernel32.dll", SetLastError = true)]
        static extern bool AllocConsole();

        [DllImport(@"kernel32.dll")]
        static extern IntPtr GetConsoleWindow();

        [DllImport(@"user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        const int SwHide = 0;
        const int SwShow = 5;


        public static void ShowConsoleWindow()
        {
            var handle = GetConsoleWindow();

            if (handle == IntPtr.Zero)
            {
                AllocConsole();
            }
            else
            {
                ShowWindow(handle, SwShow);
            }
        }

        public static void HideConsoleWindow()
        {
            var handle = GetConsoleWindow();

            ShowWindow(handle, SwHide);
        }
    }
}
