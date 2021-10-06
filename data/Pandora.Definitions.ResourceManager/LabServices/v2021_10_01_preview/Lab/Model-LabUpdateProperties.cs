using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.LabServices.v2021_10_01_preview.Lab
{

    internal class LabUpdatePropertiesModel
    {
        [JsonPropertyName("autoShutdownProfile")]
        public AutoShutdownProfileModel? AutoShutdownProfile { get; set; }

        [JsonPropertyName("connectionProfile")]
        public ConnectionProfileModel? ConnectionProfile { get; set; }

        [JsonPropertyName("description")]
        public string? Description { get; set; }

        [JsonPropertyName("labPlanId")]
        public string? LabPlanId { get; set; }

        [JsonPropertyName("rosterProfile")]
        public RosterProfileModel? RosterProfile { get; set; }

        [JsonPropertyName("securityProfile")]
        public SecurityProfileModel? SecurityProfile { get; set; }

        [JsonPropertyName("title")]
        public string? Title { get; set; }

        [JsonPropertyName("virtualMachineProfile")]
        public VirtualMachineProfileModel? VirtualMachineProfile { get; set; }
    }
}
