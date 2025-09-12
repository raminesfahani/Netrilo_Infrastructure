using Microsoft.Extensions.Logging;
using System;

namespace Infrastructure.Common.Extensions.Logger
{
    public static class AppLogger
    {
        public static ILoggerFactory LoggerFactory { get; set; }
        public static ILogger<T> CreateLogger<T>()
        {
            return LoggerFactory.CreateLogger<T>();
        }

        public static ILogger CreateLogger(string categoryName)
        {
            return LoggerFactory.CreateLogger(categoryName);
        }

        public static ILogger CreateLogger(Type type)
        {
            return LoggerFactory.CreateLogger(type);
        }
    }
}
