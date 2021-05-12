using System.Text.Json.Serialization;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;

namespace Pandora.Definitions.ResourceManager.AppConfiguration.v2020_06_01.Store
{
    public class List : ListOperation
    {
        public override object NestedItemType()
        {
            return new ApiKey();
        }

        public override ResourceID? ResourceId()
        {
            return new ConfigurationStoreId();
        }

        private class ApiKey
        {
            [JsonPropertyName("id")]
            public string Id { get; set; }
            
            [JsonPropertyName("name")]
            public string Name { get; set; }
            
            [JsonPropertyName("value")]
            public string Value { get; set; }
            
            [JsonPropertyName("connectionString")]
            public string ConnectionString { get; set; }
            
            [JsonPropertyName("readOnly")]
            public bool ReadOnly { get; set; }
        }
    }
}