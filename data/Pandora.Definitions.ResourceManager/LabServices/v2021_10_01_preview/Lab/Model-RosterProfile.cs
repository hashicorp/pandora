using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.LabServices.v2021_10_01_preview.Lab
{

    internal class RosterProfileModel
    {
        [JsonPropertyName("activeDirectoryGroupId")]
        public string? ActiveDirectoryGroupId { get; set; }

        [JsonPropertyName("lmsInstance")]
        public string? LmsInstance { get; set; }

        [JsonPropertyName("ltiClientId")]
        public string? LtiClientId { get; set; }

        [JsonPropertyName("ltiContextId")]
        public string? LtiContextId { get; set; }

        [JsonPropertyName("ltiRosterEndpoint")]
        public string? LtiRosterEndpoint { get; set; }
    }
}
