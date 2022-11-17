using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.AzureStackHCI.v2022_10_01.Updates;


internal class UpdatePropertiesModel
{
    [JsonPropertyName("additionalProperties")]
    public string? AdditionalProperties { get; set; }

    [JsonPropertyName("availabilityType")]
    public AvailabilityTypeConstant? AvailabilityType { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("installedDate")]
    public DateTime? InstalledDate { get; set; }

    [JsonPropertyName("packagePath")]
    public string? PackagePath { get; set; }

    [JsonPropertyName("packageSizeInMb")]
    public float? PackageSizeInMb { get; set; }

    [JsonPropertyName("packageType")]
    public string? PackageType { get; set; }

    [JsonPropertyName("prerequisites")]
    public List<UpdatePrerequisiteModel>? Prerequisites { get; set; }

    [JsonPropertyName("provisioningState")]
    public ProvisioningStateConstant? ProvisioningState { get; set; }

    [JsonPropertyName("publisher")]
    public string? Publisher { get; set; }

    [JsonPropertyName("releaseLink")]
    public string? ReleaseLink { get; set; }

    [JsonPropertyName("state")]
    public StateConstant? State { get; set; }

    [JsonPropertyName("updateStateProperties")]
    public UpdateStatePropertiesModel? UpdateStateProperties { get; set; }

    [JsonPropertyName("version")]
    public string? Version { get; set; }
}
