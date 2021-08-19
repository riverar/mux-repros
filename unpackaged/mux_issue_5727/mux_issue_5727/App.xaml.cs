using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media.Imaging;
using Microsoft.UI.Xaml.Shapes;

namespace mux_issue_5727
{
    public partial class App : Application
    {
        public App()
        {
            this.InitializeComponent();
        }

        protected override void OnLaunched(Microsoft.UI.Xaml.LaunchActivatedEventArgs args)
        {
            var shape = new Rectangle();
            shape.Width = 20f;
            shape.Height = 20f;

            var canvas = new Canvas();
            canvas.Children.Add(shape);

            var render_target = new RenderTargetBitmap();
            render_target.RenderAsync(canvas).GetResults();
        }
    }
}
