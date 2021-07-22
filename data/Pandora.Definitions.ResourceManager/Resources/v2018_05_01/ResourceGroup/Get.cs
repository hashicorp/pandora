using System.Text.Json.Serialization;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Operations;

namespace Pandora.Definitions.ResourceManager.Resources.v2018_05_01.ResourceGroup
{
    internal class Get : GetOperation
    {
        public override object? ResponseObject()
        {
            return new GetResourceGroup();
        }
    }

    public class GetResourceGroup
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("location")]
        public Location Location { get; set; }

        [JsonPropertyName("tags")]
        public Tags Tags { get; set; }
    }
}