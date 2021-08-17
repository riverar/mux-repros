using Microsoft.UI.Xaml;
using System;
using System.Runtime.InteropServices;

namespace was_issue_1255
{
    public sealed partial class MainWindow : Window
    {
        [DllImport("Microsoft.UI.Windowing.Core.dll", CharSet = CharSet.Unicode, ExactSpelling = true)]
        private static extern IntPtr GetWindowIdFromWindowHandle(IntPtr hwnd, out Microsoft.UI.WindowId result);

        private void ToggleFullscreen()
        {
            var hwnd = WinRT.Interop.WindowNative.GetWindowHandle(this);
            GetWindowIdFromWindowHandle(hwnd, out var windowId);
            var appWindow = Microsoft.UI.Windowing.AppWindow.GetFromWindowId(windowId);
            System.Diagnostics.Debug.WriteLine($"Presenter: {appWindow.Presenter.Kind} WindowID={windowId.Value} hwnd={hwnd}");

            if (appWindow.Presenter.Kind == Microsoft.UI.Windowing.AppWindowPresenterKind.Overlapped)
            {
                var result = appWindow.TrySetPresenter(Microsoft.UI.Windowing.AppWindowPresenterKind.FullScreen);
                System.Diagnostics.Debug.WriteLine("Entering Fullscreen result: " + result);
            }
            else
            {
                var result = appWindow.TrySetPresenter(Microsoft.UI.Windowing.AppWindowPresenterKind.Overlapped);
                System.Diagnostics.Debug.WriteLine("Exiting Fullscreen result: " + result);
            }
        }

        public MainWindow()
        {
            InitializeComponent();
        }

        private void myButton_Click(object sender, RoutedEventArgs e)
        {
            myButton.Content = "Clicked";
            ToggleFullscreen();
        }
    }
}
