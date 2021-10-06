using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.LabServices.v2021_10_01_preview.VirtualMachine
{

    internal class VirtualMachinePropertiesModel
    {
        [JsonPropertyName("claimedByUserId")]
        public string? ClaimedByUserId { get; set; }

        [JsonPropertyName("connectionProfile")]
        public VirtualMachineConnectionProfileModel? ConnectionProfile { get; set; }

        [JsonPropertyName("provisioningState")]
        public ProvisioningStateConstant? ProvisioningState { get; set; }

        [JsonPropertyName("state")]
        public VirtualMachineStateConstant? State { get; set; }

        [JsonPropertyName("vmType")]
        public VirtualMachineTypeConstant? VmType { get; set; }
    }
}
