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
    public partial class CustomDrawTypeRadioButton : RadioButton, INotifyPropertyChanged
    {
        private InkCanvasEditingMode drawType;
        public InkCanvasEditingMode DrawType
        {
            get
            {
                return drawType;
            }
            set
            {
                drawType = value;
            }
        }
        private string buttonName;
        public string ButtonName
        {
            get
            {
                return buttonName;
            }
            set
            {
                buttonName = value;
                OnPropertyChanged(nameof(ButtonName));
            }
        }
        private ImageSource imagePath;
        public ImageSource ImagePath
        {
            get
            {
                return imagePath;
            }
            set
            {
                imagePath = value;
                OnPropertyChanged(nameof(ImagePath));

            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name) {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
        public CustomDrawTypeRadioButton()
        {
            InitializeComponent();
            
            drawType = InkCanvasEditingMode.Ink;
        }

        private void RadioButton_Loaded(object sender, RoutedEventArgs e)
        {
            switch (drawType)
            {
                case InkCanvasEditingMode.Ink:
                    ImagePath = new BitmapImage(new Uri("pack://application:,,,/Resources/Pen.png"));
                    ButtonName = "Pen"; 
                    break;
                case InkCanvasEditingMode.EraseByStroke:
                    ImagePath = new BitmapImage(new Uri("pack://application:,,,/Resources/Eraser.png"));
                    ButtonName = "Eraser";
                    break;
            }

        }
    }
}
