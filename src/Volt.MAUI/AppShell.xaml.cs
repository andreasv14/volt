using Volt.MAUI.Pages;

namespace Volt.MAUI
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {   
            InitializeComponent();

            Routing.RegisterRoute("register", typeof(RegisterPage));
            Routing.RegisterRoute("home", typeof(HomePage));
            Routing.RegisterRoute("settings", typeof(SettingsPage));
            Routing.RegisterRoute("login", typeof(LoginPage));
        }
    }
}