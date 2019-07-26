using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Draw_Tool
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void DrawTypeRadioButton_Click(object sender, RoutedEventArgs e)
        {
            //(sender as Custom.CustomDrawTypeRadioButtonTest).ImagePath = new BitmapImage(new Uri("pack://siteoforigin:,,,/Resources/Pen.png"));
           XAML_Ink.EditingMode = (sender as Custom.CustomDrawTypeRadioButton).DrawType;
        }

        private void ColorRadioButton_Click(object sender, RoutedEventArgs e)
        {
            XAML_Ink.DefaultDrawingAttributes.Color = (sender as Custom.CustomColorRadioButton).InkColor;
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if(XAML_Ink == null)
            {
                return;
            }
            XAML_Ink.DefaultDrawingAttributes.Width = (sender as Slider).Value * 2;
            XAML_Ink.DefaultDrawingAttributes.Height = (sender as Slider).Value * 2;
        }

        private void OpenButton_Click(object sender, RoutedEventArgs e)
        {
            
            try
            {
                using (FileStream fs = new FileStream("inkstrokes.isf", FileMode.Open))
                {
                    StrokeCollection strokes = new StrokeCollection(fs);
                    XAML_Ink.Strokes = strokes;
                }
            }
            catch
            {
                // 파일이 존재하지 않을 때
                Console.WriteLine("No File");
            }
        }
        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            using(FileStream fs = new FileStream("inkstrokes.isf",FileMode.Create))
            {
                XAML_Ink.Strokes.Save(fs);
                fs.Close();
            }
            
        }
    }
}
