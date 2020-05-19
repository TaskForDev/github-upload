using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using V8Features.OrderFactory;

namespace V8Features
{
    class AsyncStream
    {
        const int orders = 6;
        static int ThreadID => System.Threading.Thread.CurrentThread.ManagedThreadId;

        public void DisplayOrders()
        {
           foreach( var order in OrderFactory.OrderFactory.MakeOrders(orders))
            {
                Console.WriteLine($"Thread{ThreadID} Sync streaming order{order}");
            };

        } 

        public async System.Threading.Tasks.Task DisplayOrderAsync()
        {
            await foreach (var order in OrderFactory.OrderFactory.MakeOrdersasyncAsync(orders))
            {
                Console.WriteLine($"Thread{ThreadID} Async Streaming order{order}");
            };
        }
    }
}
