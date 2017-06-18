using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Stripe.Client.Sdk.Extensions;

namespace Stripe.Client.Sdk.Converters
{
    public class EpochConverter : DateTimeConverterBase
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var dateTimeValue = (DateTime)value;
            writer.WriteRawValue(@"""\/Date(" + dateTimeValue.ToEpoch() + @")\/""");
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue,
            JsonSerializer serializer)
        {
            if (reader.Value == null)
            {
                return null;
            }

            if (reader.TokenType == JsonToken.Integer)
            {
                var integerValue = (long)reader.Value;
                return integerValue.ToDateTime();
            }
            return DateTime.Parse(reader.Value.ToString());
        }
    }
}