/*
 * Rozpoczêcie pracy programu
 */
using ConsoleMode;
using GUI;
using ProgramConfiguration;
using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace Przetwarzanie_plikow_PDF {
    internal static class Program {
        [DllImport("kernel32.dll")]
        static extern IntPtr GetConsoleWindow();

        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
        const int SW_HIDE = 0;
        const int SW_SHOW = 5;

        static void Main(string[] args) {
            if(args.Length == 0)
                ProgramSettings.isWindowedApplication = true;
            
            Console.WriteLine("£adowanie ustawieñ programu...");
            ProgramSettings.Init();
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            var handle = GetConsoleWindow();

            //Je¿eli wywo³ano z parametrami program dzia³a w trybie konsoli, je¿eli bez w oknie GUI
            if (args.Length == 0) {
                Console.WriteLine("Nie wprowadzono ¿adnych argumentów");
                Console.WriteLine("Za chwilê poka¿e siê okno programu");
                ShowWindow(handle, SW_HIDE);

                Thread th = new Thread((ThreadStart)(() => {
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new MainWindow());
                }));
                th.SetApartmentState(ApartmentState.STA);
                th.Start();
                th.Join();
            } else {
                ShowWindow(handle, SW_SHOW);
                ProgramSettings.isWindowedApplication = false;
                MainMenuConsole console = new MainMenuConsole();

                Console.ReadLine();
            }

        }
    }
}

