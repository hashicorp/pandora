using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Storage.v2021_04_01.ObjectReplicationPolicies;


internal class ObjectReplicationPolicyPropertiesModel
{
    [JsonPropertyName("destinationAccount")]
    [Required]
    public string DestinationAccount { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("enabledTime")]
    public DateTime? EnabledTime { get; set; }

    [JsonPropertyName("policyId")]
    public string? PolicyId { get; set; }

    [JsonPropertyName("rules")]
    public List<ObjectReplicationPolicyRuleModel>? Rules { get; set; }

    [JsonPropertyName("sourceAccount")]
    [Required]
    public string SourceAccount { get; set; }
}
