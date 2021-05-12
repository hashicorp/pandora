using System.ComponentModel;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Operations;

namespace Pandora.Definitions.ResourceManager.Resources.v2018_05_01.ResourceGroup
{
    internal class Update : PatchOperation
    {
        public override object? RequestObject()
        {
            return new UpdateInput();
        }
    }

    internal class UpdateInput
    {
        [JsonPropertyName("tags")]
        [Optional]
        [SupportsDeltaUpdate]
        public Tags Tags { get; set; }
    }
}