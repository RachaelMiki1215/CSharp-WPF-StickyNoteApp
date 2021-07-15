using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace WPFStickyNoteApp
{
    public class ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private SolidColorBrush _TitleBarBrush;
        private SolidColorBrush _MainAreaBrush;
        private System.Windows.Visibility _BGColorPickerVisibility;

        public SolidColorBrush TitleBarBrush
        {
            get => _TitleBarBrush;
            set
            {
                _TitleBarBrush = value;
                OnPropertyChanged();
            }
        }
        public SolidColorBrush MainAreaBrush
        {
            get => _MainAreaBrush;
            set
            {
                _MainAreaBrush = value;
                OnPropertyChanged();
            }
        }
        public System.Windows.Visibility BGColorPickerVisibility
        {
            get => _BGColorPickerVisibility;
            set
            {
                _BGColorPickerVisibility = value;
                OnPropertyChanged();
            }
        }

        public ViewModel()
        {
            TitleBarBrush = new SolidColorBrush(Colors.LightCoral);
            MainAreaBrush = new SolidColorBrush(Colors.White);
            BGColorPickerVisibility = System.Windows.Visibility.Hidden;
        }

    }
}
