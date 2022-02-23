using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.Storage.v2021_04_01.FileShares;


internal class LeaseShareRequestModel
{
    [JsonPropertyName("action")]
    [Required]
    public LeaseShareActionConstant Action { get; set; }

    [JsonPropertyName("breakPeriod")]
    public int? BreakPeriod { get; set; }

    [JsonPropertyName("leaseDuration")]
    public int? LeaseDuration { get; set; }

    [JsonPropertyName("leaseId")]
    public string? LeaseId { get; set; }

    [JsonPropertyName("proposedLeaseId")]
    public string? ProposedLeaseId { get; set; }
}
