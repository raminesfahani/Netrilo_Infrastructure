using MassTransit;
using System;
using System.Linq;
using System.Reflection;

namespace Netrilo.Infrastructure.Common.Bus.MessageBrokers
{
    public static class ConsumersExtension
    {
        public static Type[] All()
        {
            var consumers = Assembly
                .GetExecutingAssembly()
                .GetTypes()
                .Where(x => x.GetInterface(nameof(IConsumer)) is not null)
                .ToArray();

            return consumers;
        }
    }
}
