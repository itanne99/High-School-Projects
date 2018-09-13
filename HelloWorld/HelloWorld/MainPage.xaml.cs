using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace HelloWorld
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            
        }
        static Random random = new Random();
        int num = random.Next(1, 100);
        int attempts;
        

        private void btnCheck_Click(object sender, RoutedEventArgs e)
        {
            int userGuess = int.Parse(txtBoxInput.Text);
            if (userGuess == num)
            {
                txtBlockHint.Text = "You Won!! It took you " + attempts + " tries.";
                txtBlockAnswer.Text = num.ToString();

            }
            if(userGuess > num)
            {
                txtBlockHint.Text = "Too High!";
                attempts++;
                txtBlockNumberOfGuess.Text = attempts.ToString() + " attempts";
            }
            if (userGuess < num)
            {
                txtBlockHint.Text = "Too Low!";
                attempts++;
                txtBlockNumberOfGuess.Text = attempts.ToString() + " attempts";
            }
        }
    }
}
