using Microsoft.UI.Xaml;
using WinRT.Interop;

namespace mux_issue_5831
{
    public sealed partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void myButton_Click(object sender, RoutedEventArgs e)
        {
            var hwnd = WindowNative.GetWindowHandle(this);
            
            // Both of these fail. Pick one.

            // _ = await PrintManagerInterop.ShowPrintUIForWindowAsync(hwnd);
            // _ = await PrintManager.ShowPrintUIAsync();
        }
    }
}
