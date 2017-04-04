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
using CiteThisShit.Data;
using CiteThisShit.NetStandard;

namespace CiteThisShit.Desktop
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

        private async void searchButton_Click(object sender, RoutedEventArgs e)
        {
            if(searchDoiRadioButton.IsChecked.HasValue || searchIsbnRadioButton.IsChecked.HasValue)
            {
                if(searchDoiRadioButton.IsChecked.Value)
                {
                    var referenceGenerator = new ReferencingStringGenerator();
                    var referenceParagraph = await referenceGenerator.GenerateDoiString(searchTextbox.Text);

                    resultTextbox.Document.Blocks.Add(referenceParagraph);
                }
                else
                {
                    var referenceGenerator = new ReferencingStringGenerator();
                    var referenceParagraph = await referenceGenerator.GenerateIsbnString(searchTextbox.Text);

                    resultTextbox.Document.Blocks.Add(referenceParagraph);
                }
            }
        }
    }
}
