using System.ComponentModel;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Operations;

namespace Pandora.Definitions.ResourceManager.EventHubs.v2018_01_01_preview.EventHub
{
    internal class Get : GetOperation
    {
        public override object? ResponseObject()
        {
            return new GetEventHub();
        }

        private class GetEventHub
        {
            [JsonPropertyName("properties")]
            [Required]
            public GetEventHubProperties Properties { get; set; }
        }
        
        private class GetEventHubProperties
        {
            [JsonPropertyName("status")]
            public EntityStatus Status { get; set; }
        }

        [ConstantType(ConstantTypeAttribute.ConstantType.String)]
        private enum EntityStatus
        {
            [Description("Active")]
            Active,
            
            [Description("Creating")]
            Creating,
            
            [Description("Deleting")]
            Deleting,
            
            [Description("Disabled")]
            Disabled,
            
            [Description("ReceiveDisabled")]
            ReceiveDisabled,
            
            [Description("Renaming")]
            Renaming,
            
            [Description("Restoring")]
            Restoring,
            
            [Description("SendDisabled")]
            SendDisabled,
            
            [Description("Unknown")]
            Unknown,
        }
    }
}