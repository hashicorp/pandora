using System;
using System.Net.Http;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;

namespace Pandora.Definitions.ResourceManager.AppConfiguration.v2020_06_01.ConfigurationStores
{
    // hand-written for the moment

    public class ListKeys : ListOperation
    {
        public override object NestedItemType()
        {
            return new AccessKey();
        }

        public override ResourceID? ResourceId()
        {
            return new ConfigurationStoreId();
        }

        public override string? UriSuffix()
        {
            return "/listKeys";
        }
        public override HttpMethod Method()
        {
            return HttpMethod.Post;
        }
    }

    internal class AccessKey
    {
        [JsonPropertyName("id")]
        public string ID { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("value")]
        public string Value { get; set; }

        [JsonPropertyName("connectionString")]
        public string ConnectionString { get; set; }

        [JsonPropertyName("lastModified")]
        [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
        public DateTime LastModified { get; set; }

        [JsonPropertyName("readOnly")]
        public bool ReadOnly { get; set; }
    }
}