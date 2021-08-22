using Microsoft.UI.Dispatching;
using Microsoft.UI.Xaml;
using System;
using System.Runtime.InteropServices;
using System.Threading;

namespace scratch
{
    public static class Program
    {
        private class NativeMethods
        {
            [DllImport("Microsoft.WindowsAppSDK.Bootstrap", EntryPoint = "MddBootstrapInitialize", ExactSpelling = true, PreserveSig = true)]
            public static extern uint MddBootstrapInitialize(
                uint majorMinorVersion,
                [MarshalAs(UnmanagedType.LPWStr)]
                string versionTag,
                ulong packageVersion);
        }

        [STAThread]
        static void Main(string[] args)
        {
            var hr = NativeMethods.MddBootstrapInitialize(1 << 16 | 0, "experimental1", 0);
            if (hr != 0)
            {
                Marshal.ThrowExceptionForHR(unchecked((int)hr));
            }

            WinRT.ComWrappersSupport.InitializeComWrappers();
            Application.Start((p) =>
            {
                var context = new DispatcherQueueSynchronizationContext(DispatcherQueue.GetForCurrentThread());
                SynchronizationContext.SetSynchronizationContext(context);
                new App();
            });
        }
    }
}
