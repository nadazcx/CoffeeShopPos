using CoffeeShopPos.ViewModels;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace CoffeeShopPos
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        private int pinLength = 0;
        private readonly Ellipse[] bubbles;
        private string enteredPin = "";
        public LoginWindow()

        {
            InitializeComponent();
            bubbles = new Ellipse[] { Bubble1, Bubble2, Bubble3, Bubble4 };
            DataContext = new LoginViewModel(); 
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (pinLength < bubbles.Length)
            {
                Button clickedButton = sender as Button;
                if (clickedButton != null)
                {
                    // Update the bubbles
                    bubbles[pinLength].Fill = Brushes.White;
                    pinLength++;

                    // Store the entered digit if needed (e.g., for validation)
                    enteredPin += clickedButton.Content.ToString();
                }
            }

            // Validate the PIN if it's complete
            if (pinLength == bubbles.Length)
            {
                ValidatePin();
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if(enteredPin == "1234")
            {
                // Close the login window after the main window is shown
            }
        }

        private void ValidatePin()
        {
            if (enteredPin == "1234") // Replace with actual PIN check logic
            {
                // Correct PIN logic
                //MessageBox.Show("PIN correct!");
                this.Close();
               
            }
            else
            {
                // Incorrect PIN, reset bubbles
                foreach (var bubble in bubbles)
                {
                    bubble.Fill = Brushes.Gray;
                }
                pinLength = 0;
                enteredPin = ""; // Clear the enteredPin string
                MessageBox.Show("Incorrect PIN. Try again.");
            }
        }
    }
}

