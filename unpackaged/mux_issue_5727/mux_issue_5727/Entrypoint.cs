using Microsoft.UI.Dispatching;
using Microsoft.UI.Xaml;
using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;

namespace mux_issue_5727
{
    public static class Entrypoint
    {
        [DllImport("Microsoft.WindowsAppSDK.Bootstrap", EntryPoint = "MddBootstrapInitialize", ExactSpelling = true, PreserveSig = true)]
        public static extern uint MddBootstrapInitialize(
            uint majorMinorVersion,
            [MarshalAs(UnmanagedType.LPWStr)]
            string versionTag,
            ulong packageVersion);

        [GeneratedCodeAttribute("Microsoft.UI.Xaml.Markup.Compiler", " 0.0.0.0")]
        [DebuggerNonUserCodeAttribute()]
        [STAThreadAttribute]
        static void Main(string[] args)
        {

            MddBootstrapInitialize(1 << 16 | 0, "experimental1", 0);

            WinRT.ComWrappersSupport.InitializeComWrappers();
            Application.Start((p) => {
                var context = new DispatcherQueueSynchronizationContext(DispatcherQueue.GetForCurrentThread());
                SynchronizationContext.SetSynchronizationContext(context);
                new App();
            });
        }
    }
}
