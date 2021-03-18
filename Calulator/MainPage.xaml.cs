using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Calulator
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        int counter = 1;
        char currentOperation;
        double lastResultInOperation;

        public MainPage()
        {
            this.InitializeComponent();
            this.viewModel = new MainResultViewModel();
            ApplicationView.PreferredLaunchViewSize = new Size(700, 600);
            ApplicationView.PreferredLaunchWindowingMode = ApplicationViewWindowingMode.PreferredLaunchViewSize;
        }

        public MainResultViewModel viewModel { get; set; }       

        private void Button4_Click(object sender, RoutedEventArgs e)
        {
            changingResult(4);
        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            changingResult(1);
        }

        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            changingResult(2);
        }

        private void Button3_Click(object sender, RoutedEventArgs e)
        {
            changingResult(3);
        }

        private void Button5_Click(object sender, RoutedEventArgs e)
        {
            changingResult(5);
        }

        private void Button6_Click(object sender, RoutedEventArgs e)
        {
            changingResult(6);
        }
    
        private void Button7_Click(object sender, RoutedEventArgs e)
        {
            changingResult(7);
        }

        private void Button8_Click(object sender, RoutedEventArgs e)
        {
            changingResult(8);
        }

        private void Button9_Click(object sender, RoutedEventArgs e)
        {
            changingResult(9);
        }

        private void Button0_Click(object sender, RoutedEventArgs e)
        {
            changingResult(0);
        }

        private void ButtonMinusPlus_Click(object sender, RoutedEventArgs e)
        {
            viewModel.resultModel.result = CalculatorLogics.CALCULATORLOGICS.minusOrPlus(viewModel.resultModel.result);
            SettingTextBlock(viewModel.resultModel.MainResultString);
        }

        private void ButtonComma_Click(object sender, RoutedEventArgs e)
        {
            viewModel.resultModel.IfAfterComma = true;
        }

        private void SettingTextBlock(string value)
        {
            MainTextBlock.Text = value;
        }

        private void changingResult(float number)
        {
            MainResult resultModel = viewModel.resultModel;
            if (resultModel.IfInserting == true && resultModel.IfAfterComma == false)
            {
                if (resultModel.result >= 0)
                    resultModel.result = resultModel.result * 10 + number;
                else
                    resultModel.result = resultModel.result * 10 + (-1 * number);

                SettingTextBlock(resultModel.MainResultString);
                return;
            }
            if(resultModel.IfAfterComma == true)
            {
                if (resultModel.result >= 0)
                    resultModel.result = (resultModel.result + number * Math.Pow(0.1,counter));                    
                else
                    resultModel.result = resultModel.result + Math.Pow(0.1, 2) * number;
                SettingTextBlock(resultModel.MainResultString);
                counter++;
                return;
            }
                
            resultModel.result = number;
            SettingTextBlock(resultModel.MainResultString);
        }

        private void ButtonC_Click(object sender, RoutedEventArgs e)
        {
            clearingResult();
        }

        private void ButtonSum_Click(object sender, RoutedEventArgs e)
        {
            currentOperation = '+';
            lastResultInOperation = viewModel.resultModel.result;
            clearingResult();
        }

        private void ButtonEqual_Click(object sender, RoutedEventArgs e)
        {
            endingOperation(currentOperation);
        }

        private void ButtonSubstraction_Click(object sender, RoutedEventArgs e)
        {
            currentOperation = '-';
            lastResultInOperation = viewModel.resultModel.result;
            clearingResult();
        }

        private void ButtonMultiply_Click(object sender, RoutedEventArgs e)
        {
            currentOperation = '*';
            lastResultInOperation = viewModel.resultModel.result;
            clearingResult();
        }

        private void ButtonDivision_Click(object sender, RoutedEventArgs e)
        {
            currentOperation = '/';
            lastResultInOperation = viewModel.resultModel.result;
            clearingResult();
        }

        private void ButtonPow_Click(object sender, RoutedEventArgs e)
        {
            viewModel.resultModel.result = CalculatorLogics.CALCULATORLOGICS.upTo2Powers(viewModel.resultModel.result);
            SettingTextBlock(viewModel.resultModel.MainResultString);
       
        }

        private void ButtonFracture_Click(object sender, RoutedEventArgs e)
        {
            viewModel.resultModel.result = 1 / viewModel.resultModel.result;
            SettingTextBlock(viewModel.resultModel.MainResultString);
        }

        private void clearingResult()
        {
            viewModel.resultModel.result = 0;
            SettingTextBlock(viewModel.resultModel.MainResultString);
            viewModel.resultModel.IfAfterComma = false;
            counter = 1;
        }

        private void endingOperation(char operationChar)
        {
            MainResult mainResult = viewModel.resultModel;
            switch (currentOperation)
            {
                case '+':
                    mainResult.result = CalculatorLogics.CALCULATORLOGICS.addding(lastResultInOperation, mainResult.result);
                    break;
                case '-':
                    mainResult.result = CalculatorLogics.CALCULATORLOGICS.substracting(lastResultInOperation, mainResult.result);
                    break;
                case '*':
                    mainResult.result = CalculatorLogics.CALCULATORLOGICS.multiplaying(lastResultInOperation, mainResult.result);
                    break;
                case '/':
                    mainResult.result = CalculatorLogics.CALCULATORLOGICS.dividing(lastResultInOperation, mainResult.result);
                    break;
                case '=':
                    mainResult.result *= 2;
                    break;
            }
            SettingTextBlock(mainResult.MainResultString);
            currentOperation = '=';
        }
    }
}
