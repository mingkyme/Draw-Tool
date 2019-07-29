using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
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
        private Color color;
        public Color Color
        {
            get
            {
                return color;
            }
            set
            {
                color = value;
                PropertyInfo colorProperty = typeof(Colors).GetProperties().FirstOrDefault(p => Color.AreClose((Color)p.GetValue(null), color));
                ColorName = colorProperty != null ? colorProperty.Name : "";
                OnPropertyChanged(nameof(Color));
            }
        }
        private string colorName;
        public string ColorName
        {
            get
            {
                return colorName;
            }
            set
            {
                colorName = value;
                OnPropertyChanged(nameof(ColorName));
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
