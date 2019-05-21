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

using System.Text.RegularExpressions;

namespace Regex
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            textBlockResult.Text = null;
        }

        private void TextBoxChange(object sender, TextChangedEventArgs e)
        {

            bool? compare = null;
            try
            {
                Match match = Compare(textBoxInput.Text, textBoxPattern.Text);
                String RegexResult = string.Format("Success: {0}\nIndex: {1}\nLength: {2}\nValue: {3}",
                    match.Success.ToString(),
                    match.Index.ToString(),
                    match.Length.ToString(),
                    match.Value .ToString());
                textBlockResult.Text = RegexResult;
                compare = match.Success;
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message,"Error",MessageBoxButton.OK,MessageBoxImage.Error);
                textBlockResult.Text = ex.Message;
                textBlockResult.Background = Brushes.Yellow;
            }

            if (compare == true)
            {
                textBlockResult.Background = Brushes.Green;
            }
            else if (compare == false)
            {
                textBlockResult.Background = Brushes.Red;
            }
        }

        private Match Compare(string stringInput, string stringPattern)
        {
            System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex(stringPattern);
            Match match = regex.Match(stringInput);
            return match;
        }

    }
}
