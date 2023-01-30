using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DataBoxEdge.v2020_12_01.Devices;


internal class DataBoxEdgeDevicePropertiesModel
{
    [JsonPropertyName("configuredRoleTypes")]
    public List<RoleTypesConstant>? ConfiguredRoleTypes { get; set; }

    [JsonPropertyName("culture")]
    public string? Culture { get; set; }

    [JsonPropertyName("dataBoxEdgeDeviceStatus")]
    public DataBoxEdgeDeviceStatusConstant? DataBoxEdgeDeviceStatus { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("deviceHcsVersion")]
    public string? DeviceHcsVersion { get; set; }

    [JsonPropertyName("deviceLocalCapacity")]
    public int? DeviceLocalCapacity { get; set; }

    [JsonPropertyName("deviceModel")]
    public string? DeviceModel { get; set; }

    [JsonPropertyName("deviceSoftwareVersion")]
    public string? DeviceSoftwareVersion { get; set; }

    [JsonPropertyName("deviceType")]
    public DeviceTypeConstant? DeviceType { get; set; }

    [JsonPropertyName("edgeProfile")]
    public EdgeProfileModel? EdgeProfile { get; set; }

    [JsonPropertyName("friendlyName")]
    public string? FriendlyName { get; set; }

    [JsonPropertyName("modelDescription")]
    public string? ModelDescription { get; set; }

    [JsonPropertyName("nodeCount")]
    public int? NodeCount { get; set; }

    [JsonPropertyName("resourceMoveDetails")]
    public ResourceMoveDetailsModel? ResourceMoveDetails { get; set; }

    [JsonPropertyName("serialNumber")]
    public string? SerialNumber { get; set; }

    [JsonPropertyName("timeZone")]
    public string? TimeZone { get; set; }
}
