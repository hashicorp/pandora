// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class TeamworkDeviceConfigurationModel
{
    [JsonPropertyName("cameraConfiguration")]
    public TeamworkCameraConfigurationModel? CameraConfiguration { get; set; }

    [JsonPropertyName("createdBy")]
    public IdentitySetModel? CreatedBy { get; set; }

    [JsonPropertyName("createdDateTime")]
    public DateTime? CreatedDateTime { get; set; }

    [JsonPropertyName("displayConfiguration")]
    public TeamworkDisplayConfigurationModel? DisplayConfiguration { get; set; }

    [JsonPropertyName("hardwareConfiguration")]
    public TeamworkHardwareConfigurationModel? HardwareConfiguration { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("lastModifiedBy")]
    public IdentitySetModel? LastModifiedBy { get; set; }

    [JsonPropertyName("lastModifiedDateTime")]
    public DateTime? LastModifiedDateTime { get; set; }

    [JsonPropertyName("microphoneConfiguration")]
    public TeamworkMicrophoneConfigurationModel? MicrophoneConfiguration { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("softwareVersions")]
    public TeamworkDeviceSoftwareVersionsModel? SoftwareVersions { get; set; }

    [JsonPropertyName("speakerConfiguration")]
    public TeamworkSpeakerConfigurationModel? SpeakerConfiguration { get; set; }

    [JsonPropertyName("systemConfiguration")]
    public TeamworkSystemConfigurationModel? SystemConfiguration { get; set; }

    [JsonPropertyName("teamsClientConfiguration")]
    public TeamworkTeamsClientConfigurationModel? TeamsClientConfiguration { get; set; }
}
