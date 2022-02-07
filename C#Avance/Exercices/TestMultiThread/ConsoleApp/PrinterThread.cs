using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    internal class PrinterThread
    {
        private readonly Thread _thread;

        public PrinterThread()
        {
            _thread = new Thread
                (
               async () =>
                await MyContainer.NotSafeAdd(Thread.CurrentThread.ManagedThreadId)
                ); 
        }

        public async Task Start()
        {
            _thread.Start();
           await MyContainer.NotSafePrint();
        }
    }
}
