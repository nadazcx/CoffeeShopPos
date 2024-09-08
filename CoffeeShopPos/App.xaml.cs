using System.Windows;

namespace CoffeeShopPos
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            // Set the ShutdownMode to ensure the application doesn't close prematurely
            Application.Current.ShutdownMode = ShutdownMode.OnLastWindowClose;
        }
    }
}