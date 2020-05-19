using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using V8Features.Models;

namespace V8Features.OrderFactory
{
    public static class OrderFactory
    {
        public static IEnumerable<Order> MakeOrders(int count)
        {
            for (var i = 0; i < count; i++)
            {
                // Pretend to call some expensive process to build up the order.
                Task.Delay(1000).Wait();

                yield return new Order { Id = i + 1 };
            }
        }
        public static async IAsyncEnumerable<Order> MakeOrdersasyncAsync(int count)
        {
            for (var i = 0; i < count; i++)
            {
                // Pretend to call some expensive process to build up the order.
                await Task.Delay(1000);
                yield return new Order { Id = i + 1 };
            }
        }
    }
}
