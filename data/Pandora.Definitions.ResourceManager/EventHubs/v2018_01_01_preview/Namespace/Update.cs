using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Operations;

namespace Pandora.Definitions.ResourceManager.EventHubs.v2018_01_01_preview.Namespace
{
    internal class Update : PatchOperation
    {
        public override object? RequestObject()
        {
            return new UpdateNamespaceInput();
        }
    }

    internal class UpdateNamespaceInput
    {
        [JsonPropertyName("tags")]
        [Optional]
        [SupportsDeltaUpdate]
        public Tags Tags { get; set; }
    }
}