using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;

namespace Netrilo.Infrastructure.Common.Extensions.JsonConverters
{
    public class MailAddressConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            writer.WriteValue(value is not MailAddress mailAddress ? string.Empty : mailAddress.ToString());
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            string text = reader.Value as string;

            return IsValidMailAddress(text, out MailAddress mailAddress) ? mailAddress : null;
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(MailAddress);
        }

        private static bool IsValidMailAddress(string text, out MailAddress value)
        {
            try
            {
                value = new MailAddress(text);
                return true;
            }
            catch
            {
                value = null;
                return false;
            }
        }
    }
}
