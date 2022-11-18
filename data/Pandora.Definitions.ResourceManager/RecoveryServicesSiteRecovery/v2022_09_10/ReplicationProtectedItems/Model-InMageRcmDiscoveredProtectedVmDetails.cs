using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.RecoveryServicesSiteRecovery.v2022_09_10.ReplicationProtectedItems;


internal class InMageRcmDiscoveredProtectedVmDetailsModel
{
    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("createdTimestamp")]
    public DateTime? CreatedTimestamp { get; set; }

    [JsonPropertyName("datastores")]
    public List<string>? DataStores { get; set; }

    [JsonPropertyName("ipAddresses")]
    public List<string>? IPAddresses { get; set; }

    [JsonPropertyName("isDeleted")]
    public bool? IsDeleted { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("lastDiscoveryTimeInUtc")]
    public DateTime? LastDiscoveryTimeInUtc { get; set; }

    [JsonPropertyName("osName")]
    public string? OsName { get; set; }

    [JsonPropertyName("powerStatus")]
    public string? PowerStatus { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("updatedTimestamp")]
    public DateTime? UpdatedTimestamp { get; set; }

    [JsonPropertyName("vCenterFqdn")]
    public string? VCenterFqdn { get; set; }

    [JsonPropertyName("vCenterId")]
    public string? VCenterId { get; set; }

    [JsonPropertyName("vmFqdn")]
    public string? VmFqdn { get; set; }

    [JsonPropertyName("vmwareToolsStatus")]
    public string? VmwareToolsStatus { get; set; }
}
