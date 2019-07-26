using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace Draw_Tool.Custom
{
    public partial class CustomColorRadioButton : RadioButton, INotifyPropertyChanged
    {
        private Color inkColor;
        public Color InkColor
        {
            get
            {
                return inkColor;
            }
            set
            {
                inkColor = value;
                OnPropertyChanged(nameof(InkColor));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
            
        }
        public CustomColorRadioButton()
        {
            InitializeComponent();
        }
    }
}
