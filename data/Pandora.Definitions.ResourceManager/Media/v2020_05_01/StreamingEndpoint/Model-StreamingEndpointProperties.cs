using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Media.v2020_05_01.StreamingEndpoint;


internal class StreamingEndpointPropertiesModel
{
    [JsonPropertyName("accessControl")]
    public StreamingEndpointAccessControlModel? AccessControl { get; set; }

    [JsonPropertyName("availabilitySetName")]
    public string? AvailabilitySetName { get; set; }

    [JsonPropertyName("cdnEnabled")]
    public bool? CdnEnabled { get; set; }

    [JsonPropertyName("cdnProfile")]
    public string? CdnProfile { get; set; }

    [JsonPropertyName("cdnProvider")]
    public string? CdnProvider { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("created")]
    public DateTime? Created { get; set; }

    [JsonPropertyName("crossSiteAccessPolicies")]
    public CrossSiteAccessPoliciesModel? CrossSiteAccessPolicies { get; set; }

    [JsonPropertyName("customHostNames")]
    public List<string>? CustomHostNames { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("freeTrialEndTime")]
    public DateTime? FreeTrialEndTime { get; set; }

    [JsonPropertyName("hostName")]
    public string? HostName { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("lastModified")]
    public DateTime? LastModified { get; set; }

    [JsonPropertyName("maxCacheAge")]
    public int? MaxCacheAge { get; set; }

    [JsonPropertyName("provisioningState")]
    public string? ProvisioningState { get; set; }

    [JsonPropertyName("resourceState")]
    public StreamingEndpointResourceStateConstant? ResourceState { get; set; }

    [JsonPropertyName("scaleUnits")]
    [Required]
    public int ScaleUnits { get; set; }
}
