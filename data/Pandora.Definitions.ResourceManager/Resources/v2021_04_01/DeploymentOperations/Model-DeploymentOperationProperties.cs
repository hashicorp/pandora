using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Resources.v2021_04_01.DeploymentOperations;


internal class DeploymentOperationPropertiesModel
{
    [JsonPropertyName("duration")]
    public string? Duration { get; set; }

    [JsonPropertyName("provisioningOperation")]
    public ProvisioningOperationConstant? ProvisioningOperation { get; set; }

    [JsonPropertyName("provisioningState")]
    public string? ProvisioningState { get; set; }

    [JsonPropertyName("request")]
    public HTTPMessageModel? Request { get; set; }

    [JsonPropertyName("response")]
    public HTTPMessageModel? Response { get; set; }

    [JsonPropertyName("serviceRequestId")]
    public string? ServiceRequestId { get; set; }

    [JsonPropertyName("statusCode")]
    public string? StatusCode { get; set; }

    [JsonPropertyName("statusMessage")]
    public StatusMessageModel? StatusMessage { get; set; }

    [JsonPropertyName("targetResource")]
    public TargetResourceModel? TargetResource { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("timestamp")]
    public DateTime? Timestamp { get; set; }
}
