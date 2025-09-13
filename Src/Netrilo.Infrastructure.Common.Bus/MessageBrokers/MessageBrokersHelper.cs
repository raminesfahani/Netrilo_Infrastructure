using Netrilo.Infrastructure.Common.Abstractions.Events;

namespace Netrilo.Infrastructure.Common.Bus.MessageBrokers
{
    public static class MessageBrokersHelper
    {
        public static string GetTypeName(Type type)
        {
            var name = type.FullName.ToLower().Replace("+", ".");

            if (type is IEvent)
            {
                name += "_event";
            }

            return name;
        }

        public static string GetTypeName<T>()
        {
            return GetTypeName(typeof(T));
        }
    }
}
