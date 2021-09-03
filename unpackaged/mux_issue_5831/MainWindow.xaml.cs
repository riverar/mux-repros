using Microsoft.UI.Xaml;
using System;
using Windows.Graphics.Printing;
using WinRT.Interop;

namespace mux_issue_5831
{
    public sealed partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void MyButton_Click(object sender, RoutedEventArgs e)
        {
            var hwnd = WindowNative.GetWindowHandle(this);
            _ = await PrintManagerInterop.ShowPrintUIForWindowAsync(hwnd);
        }
    }
}
