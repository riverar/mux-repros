using Microsoft.UI.Xaml;

namespace scratch
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
        }

        protected override void OnLaunched(Microsoft.UI.Xaml.LaunchActivatedEventArgs args)
        {
            _window = new MainWindow();
            _window.Title = "Unpackaged WinUI 3 application";
            _window.Activate();
        }

        private Window _window;
    }
}
