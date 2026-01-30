using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private double FirstNum;
        private double SecondNum;
        private string Operation = "";

        private void btnNumberClick(object sender, RoutedEventArgs e)
        {
            if (tbCurrAct.Text == "0") {
                tbCurrAct.Text = "";
            }
            tbCurrAct.Text += (sender as Button).Content;
        }

        private void btnSignClick(object sender, RoutedEventArgs e)
        {
            Operation = (sender as Button).Content.ToString();
            FirstNum = double.Parse(tbCurrAct.Text);

            lblTemp.Content += $"{tbCurrAct.Text} {(sender as Button).Content}";
            tbCurrAct.Text = "";
        }

        private void btnEqualClick(object sender, RoutedEventArgs e) {

            lblTemp.Content = "";

            if (double.TryParse(tbCurrAct.Text, out SecondNum))
            {

                switch (Operation)
                {
                    case "+":
                        tbCurrAct.Text = (FirstNum + SecondNum).ToString();
                        break;
                    case "-":
                        tbCurrAct.Text = (FirstNum - SecondNum).ToString();
                        break;
                    case "*":
                        tbCurrAct.Text = (FirstNum * SecondNum).ToString();
                        break;
                    case "/":
                        tbCurrAct.Text = (FirstNum / SecondNum).ToString();
                        break;
                }

            }
            else { return; }
        }

        private void btnInvClick(object sender, RoutedEventArgs e) {

            FirstNum = double.Parse(tbCurrAct.Text) * -1;
            tbCurrAct.Text = FirstNum.ToString();

        }

        private void btnPointClick(object sender, RoutedEventArgs e) {
            
            if (char.IsDigit(tbCurrAct.Text[tbCurrAct.Text.Length - 1]) && tbCurrAct.Text.Length != 0 && !tbCurrAct.Text.Contains('.')) {
                tbCurrAct.Text += (sender as Button).Content;
            }

        }

        private void btnClearClick(object sender, RoutedEventArgs e) {

            FirstNum = 0;
            SecondNum = 0;
            Operation = "";
            tbCurrAct.Text = "0";
            lblTemp.Content = "";

        }

        private void btnClearEndClick(object sender, RoutedEventArgs e) {

            SecondNum = 0;
            tbCurrAct.Text = "0";

        }

        private void btnBackSpaceClick(object sender, RoutedEventArgs e) {

            if (tbCurrAct.Text.Length != 0)
                tbCurrAct.Text = tbCurrAct.Text.Remove(tbCurrAct.Text.Length - 1);

            else
                return;

        }

        private void btnPercentClick(object sender, RoutedEventArgs e) {

            for (int i = 0; i < 100; i++) 
            MessageBox.Show("НЕ РАБОТАЕТ", "Error evolution", MessageBoxButton.OK, MessageBoxImage.Error);
        
        }

        private void btnSqrtClick(object sender, RoutedEventArgs e) {

            tbCurrAct.Text = (Math.Sqrt(double.Parse(tbCurrAct.Text))).ToString();

        }

        private void btnPowClick(object sender, RoutedEventArgs e) {

            tbCurrAct.Text = (Math.Pow(double.Parse(tbCurrAct.Text), 2)).ToString();

        }

        private void btnFractionClick(object sender, RoutedEventArgs e) {

            tbCurrAct.Text = (1/double.Parse(tbCurrAct.Text)).ToString();

        }

    }
}