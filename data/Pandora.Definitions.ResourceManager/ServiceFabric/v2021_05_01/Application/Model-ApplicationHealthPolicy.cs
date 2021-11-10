using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.ServiceFabric.v2021_05_01.Application
{

    internal class ApplicationHealthPolicyModel
    {
        [JsonPropertyName("considerWarningAsError")]
        [Required]
        public bool ConsiderWarningAsError { get; set; }

        [JsonPropertyName("defaultServiceTypeHealthPolicy")]
        public ServiceTypeHealthPolicyModel? DefaultServiceTypeHealthPolicy { get; set; }

        [JsonPropertyName("maxPercentUnhealthyDeployedApplications")]
        [Required]
        public int MaxPercentUnhealthyDeployedApplications { get; set; }

        [JsonPropertyName("serviceTypeHealthPolicyMap")]
        public Dictionary<string, ServiceTypeHealthPolicyModel>? ServiceTypeHealthPolicyMap { get; set; }
    }
}
