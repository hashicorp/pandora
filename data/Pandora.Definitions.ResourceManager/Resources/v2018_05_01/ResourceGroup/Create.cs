using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Operations;

namespace Pandora.Definitions.ResourceManager.Resources.v2018_05_01.ResourceGroup
{
    internal class Create : PutOperation
    {
        public override object? RequestObject()
        {
            return new CreateInput();
        }
    }

    internal class CreateInput
    {
        [JsonPropertyName("location")]
        [Required]
        public Location Location { get; set; }
            
        [JsonPropertyName("tags")]
        [Optional]
        public Tags Tags { get; set; }
    }
}