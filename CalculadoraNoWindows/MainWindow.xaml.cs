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

namespace CalculadoraNoWindows
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private bool SUMA = false;
        private bool RESTA = false;
        private bool MULT = false;
        private bool DIV = false;


        public MainWindow()
        {
            InitializeComponent();
        }

        private void exitButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Radio_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton radioButton = (RadioButton)sender;

            SUMA = false; RESTA = false; MULT = false; DIV = false;

            switch (radioButton.Name)
            {
                case "sumaRadio":
                    SUMA = true;
                    break;
                case "restaRadio":
                    RESTA = true;
                    break;
                case "multRadio":
                    MULT = true;
                    break;
                case "divRadio":
                    DIV = true;
                    break;
            }
        }

        private void calculateButton_Click(object sender, RoutedEventArgs e)
        {
            if (Input1.Text == "" || Input2.Text == "")
            {
                Resultado.Text = "ERROR";
            } else
            {
                double result = 0;
                double num1 = double.Parse(Input1.Text);
                double num2 = double.Parse(Input2.Text);

                if (SUMA)
                {
                    result = num1 + num2;
                }
                else if (RESTA)
                {
                    result = num1 - num2;
                }
                else if (MULT)
                {
                    result = num1 * num2;
                }
                else if (DIV)
                {
                    if (num2 != 0)
                    {
                        try
                        {
                            result = num1 / num2;
                        }
                        catch (DivideByZeroException exception)
                        {
                            throw exception;
                        }
                    }
                    else
                    {
                        Resultado.Text = "ERROR";
                        return;

                    }
                }
                Resultado.Text = result.ToString();
            }            
        }

        private void clearButton_Click(object sender, RoutedEventArgs e)
        {
            Input1.Text = "0";
            Input2.Text = "0";
        }
    }
}
