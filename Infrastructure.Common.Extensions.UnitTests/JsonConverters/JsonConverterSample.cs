using Infrastructure.Common.Extensions.JsonConverters;
using Newtonsoft.Json;
using System.Net.Mail;

namespace Infrastructure.Common.Extensions.UnitTests.JsonConverters
{
    public class JsonConverterSample
    {
        [JsonProperty("email")]
        [JsonConverter(typeof(MailAddressConverter))]
        public MailAddress Email { get; set; }
    }
}
