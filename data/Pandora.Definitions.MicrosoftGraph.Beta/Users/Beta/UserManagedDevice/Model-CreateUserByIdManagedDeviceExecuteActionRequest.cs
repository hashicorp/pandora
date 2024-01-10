// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Users.Beta.UserManagedDevice;

internal class CreateUserByIdManagedDeviceExecuteActionRequestModel
{
    [JsonPropertyName("actionName")]
    public CreateUserByIdManagedDeviceExecuteActionRequestActionNameConstant? ActionName { get; set; }

    [JsonPropertyName("carrierUrl")]
    public string? CarrierUrl { get; set; }

    [JsonPropertyName("deprovisionReason")]
    public string? DeprovisionReason { get; set; }

    [JsonPropertyName("deviceIds")]
    public List<string>? DeviceIds { get; set; }

    [JsonPropertyName("deviceName")]
    public string? DeviceName { get; set; }

    [JsonPropertyName("keepEnrollmentData")]
    public bool? KeepEnrollmentData { get; set; }

    [JsonPropertyName("keepUserData")]
    public bool? KeepUserData { get; set; }

    [JsonPropertyName("notificationBody")]
    public string? NotificationBody { get; set; }

    [JsonPropertyName("notificationTitle")]
    public string? NotificationTitle { get; set; }

    [JsonPropertyName("organizationalUnitPath")]
    public string? OrganizationalUnitPath { get; set; }

    [JsonPropertyName("persistEsimDataPlan")]
    public bool? PersistEsimDataPlan { get; set; }
}
