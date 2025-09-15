﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Netrilo.Infrastructure.Common.Bus.MessageBrokers
{
    public class MessageBrokersOptions
    {
        public MessageBrokerType MessageBrokerType { get; set; } = MessageBrokerType.RabbitMq;
        public string Host { get; set; } = string.Empty;
        public ushort Port { get; set; }
        public string VirtualHost { get; set; } = "/";
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string ClientName { get; set; } = string.Empty;
        public string Exchange { get; set; } = string.Empty;
        public int RetryCount { get; set; } = 5;
        public int IntervalCount { get; set; } = 10;
    }
}
