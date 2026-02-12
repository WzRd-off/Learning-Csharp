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

namespace PR3_2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private int _size = 3;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void checkSize() 
        {
            string size = cbSize.SelectedItem.ToString();
            if (size == "3x3")
            {
                _size = 3;
            }
            else if (size == "5x5")
            {
                _size = 5;
            }
            else if (size == "8x8")
            {
                _size = 8;
            }

        }

        private void RefreshGP(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
