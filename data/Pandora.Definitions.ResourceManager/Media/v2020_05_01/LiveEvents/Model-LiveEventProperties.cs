using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Media.v2020_05_01.LiveEvents;


internal class LiveEventPropertiesModel
{
    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("created")]
    public DateTime? Created { get; set; }

    [JsonPropertyName("crossSiteAccessPolicies")]
    public CrossSiteAccessPoliciesModel? CrossSiteAccessPolicies { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("encoding")]
    public LiveEventEncodingModel? Encoding { get; set; }

    [JsonPropertyName("hostnamePrefix")]
    public string? HostnamePrefix { get; set; }

    [JsonPropertyName("input")]
    [Required]
    public LiveEventInputModel Input { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("lastModified")]
    public DateTime? LastModified { get; set; }

    [JsonPropertyName("preview")]
    public LiveEventPreviewModel? Preview { get; set; }

    [JsonPropertyName("provisioningState")]
    public string? ProvisioningState { get; set; }

    [JsonPropertyName("resourceState")]
    public LiveEventResourceStateConstant? ResourceState { get; set; }

    [JsonPropertyName("streamOptions")]
    public List<StreamOptionsFlagConstant>? StreamOptions { get; set; }

    [JsonPropertyName("transcriptions")]
    public List<LiveEventTranscriptionModel>? Transcriptions { get; set; }

    [JsonPropertyName("useStaticHostname")]
    public bool? UseStaticHostname { get; set; }
}
