using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace PR2_2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private double area = 0;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void setDefaultStateCb(object sender, SelectionChangedEventArgs e)
        {
            if (cbParamsSelector != null)
            {
                cbParamsSelector.SelectedIndex = 0;
            }
        }

        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e) 
        {
            Regex regex = new Regex("[^0-9,.]+");

            TextBox textBox = sender as TextBox;

            bool hasChar = regex.IsMatch(e.Text);

            bool isSeparator = e.Text == "," || e.Text == ".";

            bool alreadyHasSeparator = (textBox.Text.Contains(",") || textBox.Text.Contains("."));


            if ((hasChar || (isSeparator && alreadyHasSeparator)) || (isSeparator && textBox.CaretIndex == 0))
            {
                e.Handled = true;
            }
        }


        private void btnClearInputs_Click(object sender, RoutedEventArgs e)
        {
            // InputArea - ControlPanel
            // stackPanel - StackPanel(child InputArea)

            StackPanel stackPanel = (InputArea.Content as StackPanel);
            foreach (StackPanel child in stackPanel.Children)
            {
                child.Children.OfType<TextBox>().First().Clear();
            }
        }

        private void btnFindArea_Click(object sender, RoutedEventArgs e)
        {
            StackPanel stackPanel = (InputArea.Content as StackPanel);
            string selectedItemName = (lbShapes.SelectedItem as ListBoxItem).Content.ToString();
            string selectedParamSet = (cbParamsSelector.SelectedItem as ComboBoxItem).Content.ToString();

            var view = InputArea.Content as FrameworkElement;
            if (view == null) return;

            try
            {
                switch (selectedItemName)
                {
                    case "Трикутник":
                        if (selectedParamSet == "Три сторони")
                        {
                            double a = double.Parse(((TextBox)LogicalTreeHelper.FindLogicalNode(view, "tb_tri_a")).Text);
                            double b = double.Parse(((TextBox)LogicalTreeHelper.FindLogicalNode(view, "tb_tri_b")).Text);
                            double c = double.Parse(((TextBox)LogicalTreeHelper.FindLogicalNode(view, "tb_tri_c")).Text);

                            if (a + b <= c || a + c <= b || b + c <= a)
                            {
                                MessageBox.Show("Неможливо побудувати трикутник з такими сторонами.");
                                return;
                            }
 
                            double p = (a + b + c) / 2;
                            area = Math.Sqrt(p * (p - a) * (p - b) * (p - c));
                        }
                        else if (selectedParamSet == "Дві сторони та кут")
                        {
                            double a = double.Parse(((TextBox)LogicalTreeHelper.FindLogicalNode(view, "tb_tri_sa")).Text);
                            double b = double.Parse(((TextBox)LogicalTreeHelper.FindLogicalNode(view, "tb_tri_sb")).Text);
                            double angle = double.Parse(((TextBox)LogicalTreeHelper.FindLogicalNode(view, "tb_tri_angle")).Text);

                            area = 0.5 * a * b * Math.Sin(angle * Math.PI / 180);
                        }
                        break;

                    case "Квадрат":
                        if (selectedParamSet == "Сторона квадрата")
                        {
                            double a = double.Parse(((TextBox)LogicalTreeHelper.FindLogicalNode(view, "tb_sq_a")).Text);
                            area = a * a;
                        }
                        else if (selectedParamSet == "Діагональ квадрата")
                        {
                            double d = double.Parse(((TextBox)LogicalTreeHelper.FindLogicalNode(view, "tb_sq_d")).Text);
                            area = 0.5 * d * d;
                        }
                        break;

                    case "Паралелограм":
                        if (selectedParamSet == "Сторони та кут між ними")
                        {
                            double a = double.Parse(((TextBox)LogicalTreeHelper.FindLogicalNode(view, "tb_par_a")).Text);
                            double b = double.Parse(((TextBox)LogicalTreeHelper.FindLogicalNode(view, "tb_par_b")).Text);
                            double angle = double.Parse(((TextBox)LogicalTreeHelper.FindLogicalNode(view, "tb_par_angle")).Text);

                            area = a * b * Math.Sin(angle * Math.PI / 180);
                        }
                        else if (selectedParamSet == "Сторона та висота")
                        {
                            double b = double.Parse(((TextBox)LogicalTreeHelper.FindLogicalNode(view, "tb_par_w_wh")).Text);
                            double h = double.Parse(((TextBox)LogicalTreeHelper.FindLogicalNode(view, "tb_par_h_wh")).Text);
                            area = b * h;
                        }
                        else if (selectedParamSet == "Діагоналі та кут між ними")
                        {
                            double d1 = double.Parse(((TextBox)LogicalTreeHelper.FindLogicalNode(view, "tb_par_d1")).Text);
                            double d2 = double.Parse(((TextBox)LogicalTreeHelper.FindLogicalNode(view, "tb_par_d2")).Text);
                            double angle = double.Parse(((TextBox)LogicalTreeHelper.FindLogicalNode(view, "tb_par_d_angle")).Text);

                            area = 0.5 * d1 * d2 * Math.Sin(angle * Math.PI / 180);
                        }
                        break;

                    case "Ромб":
                        if (selectedParamSet == "Сторона та кут")
                        {
                            double a = double.Parse(((TextBox)LogicalTreeHelper.FindLogicalNode(view, "tb_rhomb_a")).Text);
                            double angle = double.Parse(((TextBox)LogicalTreeHelper.FindLogicalNode(view, "tb_rhomb_angle")).Text);

                            area = a * a * Math.Sin(angle * Math.PI / 180);
                        }
                        else if (selectedParamSet == "Сторона та висота")
                        {
                            double a = double.Parse(((TextBox)LogicalTreeHelper.FindLogicalNode(view, "tb_rhomb_w_wh")).Text);
                            double h = double.Parse(((TextBox)LogicalTreeHelper.FindLogicalNode(view, "tb_rhomb_h_wh")).Text);
                            area = a * h;
                        }
                        else if (selectedParamSet == "Діагоналі")
                        {
                            double d1 = double.Parse(((TextBox)LogicalTreeHelper.FindLogicalNode(view, "tb_rhomb_d1")).Text);
                            double d2 = double.Parse(((TextBox)LogicalTreeHelper.FindLogicalNode(view, "tb_rhomb_d2")).Text);
                            area = 0.5 * d1 * d2;
                        }
                        break;

                    case "Трапеція":
                        if (selectedParamSet == "Основи та висота")
                        {
                            double a = double.Parse(((TextBox)LogicalTreeHelper.FindLogicalNode(view, "tb_trap_a")).Text);
                            double b = double.Parse(((TextBox)LogicalTreeHelper.FindLogicalNode(view, "tb_trap_b")).Text);
                            double h = double.Parse(((TextBox)LogicalTreeHelper.FindLogicalNode(view, "tb_trap_h")).Text);

                            area = 0.5 * (a + b) * h;
                        }
                        else if (selectedParamSet == "Середня лінія та висота")
                        {
                            double m = double.Parse(((TextBox)LogicalTreeHelper.FindLogicalNode(view, "tb_trap_m")).Text);
                            double h = double.Parse(((TextBox)LogicalTreeHelper.FindLogicalNode(view, "tb_trap_h_m")).Text);
                            area = m * h;
                        }
                        else if (selectedParamSet == "Діагоналі та кут між ними")
                        {
                            double d1 = double.Parse(((TextBox)LogicalTreeHelper.FindLogicalNode(view, "tb_trap_d1")).Text);
                            double d2 = double.Parse(((TextBox)LogicalTreeHelper.FindLogicalNode(view, "tb_trap_d2")).Text);
                            double angle = double.Parse(((TextBox)LogicalTreeHelper.FindLogicalNode(view, "tb_trap_angle")).Text);

                            area = 0.5 * d1 * d2 * Math.Sin(angle * Math.PI / 180);
                        }
                        break;

                    case "Коло":
                        if (selectedParamSet == "Радіус")
                        {
                            double r = double.Parse(((TextBox)LogicalTreeHelper.FindLogicalNode(view, "tb_circle_r")).Text);
                            area = Math.PI * r * r;
                        }
                        else if (selectedParamSet == "Діаметр")
                        {
                            double d = double.Parse(((TextBox)LogicalTreeHelper.FindLogicalNode(view, "tb_circle_d")).Text);
                            area = (Math.PI * d * d) / 4;
                        }
                        else if (selectedParamSet == "Довжина кола")
                        {
                            double l = double.Parse(((TextBox)LogicalTreeHelper.FindLogicalNode(view, "tb_circle_l")).Text);
                            area = (l * l) / (4 * Math.PI);
                        }
                        break;
                }
                foreach (StackPanel child in stackPanel.Children)
                {
                    ComboBox a = child.Children.OfType<ComboBox>().First();
                    if (a.SelectedItem.ToString() == "см") { area *= 0.01; }
                    else if (a.SelectedItem.ToString() == "м") { area *= 1; }
                    else if (a.SelectedItem.ToString() == "мм") { area *= 0.001; }
                }
            }
            catch
            {
                area = 0;
            }
            if      (cbAreaUnit.SelectedItem.ToString() == "см") { area *= 100; }
            else if (cbAreaUnit.SelectedItem.ToString() == "м") { area *= 1; }
            else if (cbAreaUnit.SelectedItem.ToString() == "мм") { area *= 1000; }
            tbAreaResult.Text = Math.Round(area, 2).ToString();
        }
    }
}
