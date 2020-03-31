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

namespace Calculator
{
    public partial class MainWindow : Window
    {
        private Logic calculator = new Logic();
        public MainWindow()
        {
            InitializeComponent();
        }
        //------------------------------<Number Buttons>------------------------------
        private void buttonNumber_Click(object sender, RoutedEventArgs e)
        {
            calculator.Number(((Button)sender).Content.ToString());
            textBlockDisplay.Text = calculator.Display;
            textBlockEquation.Text = calculator.Equation;
        }
        //------------------------------<Operation Buttons>------------------------------
        private void buttonOperation_Click(object sender, RoutedEventArgs e)
        {
            calculator.Operation(((Button)sender).Content.ToString());
            textBlockDisplay.Text = calculator.Display;
            textBlockEquation.Text = calculator.Equation;
        }
        //------------------------------<Clear Buttons>------------------------------
        private void buttonClearAll_Click(object sender, RoutedEventArgs e)
        {
            calculator.ClearAll();
            textBlockDisplay.Text = calculator.Display;
            textBlockEquation.Text = calculator.Equation;
        }
        private void buttonClear_Click(object sender, RoutedEventArgs e)
        {
            calculator.Clear();
            textBlockDisplay.Text = calculator.Display;
        }
        //------------------------------<Other Buttons>------------------------------
        private void buttonPlusMinus_Click(object sender, RoutedEventArgs e)
        {
            calculator.PlusMinus();
            textBlockDisplay.Text = calculator.Display;
        }
        private void buttonComa_Click(object sender, RoutedEventArgs e)
        {
            calculator.Coma();
            textBlockDisplay.Text = calculator.Display;
        }
    }
}
