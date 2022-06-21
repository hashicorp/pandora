using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Orbital.v2022_03_01.ContactProfile;


internal class ContactProfilesPropertiesModel
{
    [JsonPropertyName("autoTrackingConfiguration")]
    public AutoTrackingConfigurationConstant? AutoTrackingConfiguration { get; set; }

    [JsonPropertyName("eventHubUri")]
    public string? EventHubUri { get; set; }

    [JsonPropertyName("links")]
    [Required]
    public List<ContactProfileLinkModel> Links { get; set; }

    [JsonPropertyName("minimumElevationDegrees")]
    public float? MinimumElevationDegrees { get; set; }

    [JsonPropertyName("minimumViableContactDuration")]
    public string? MinimumViableContactDuration { get; set; }

    [JsonPropertyName("networkConfiguration")]
    [Required]
    public ContactProfilesPropertiesNetworkConfigurationModel NetworkConfiguration { get; set; }

    [JsonPropertyName("provisioningState")]
    public ProvisioningStateConstant? ProvisioningState { get; set; }
}
