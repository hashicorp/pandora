using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Logic.v2019_05_01.WorkflowVersions;


internal class WorkflowVersionPropertiesModel
{
    [JsonPropertyName("accessControl")]
    public FlowAccessControlConfigurationModel? AccessControl { get; set; }

    [JsonPropertyName("accessEndpoint")]
    public string? AccessEndpoint { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("changedTime")]
    public DateTime? ChangedTime { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("createdTime")]
    public DateTime? CreatedTime { get; set; }

    [JsonPropertyName("definition")]
    public object? Definition { get; set; }

    [JsonPropertyName("endpointsConfiguration")]
    public FlowEndpointsConfigurationModel? EndpointsConfiguration { get; set; }

    [JsonPropertyName("integrationAccount")]
    public ResourceReferenceModel? IntegrationAccount { get; set; }

    [JsonPropertyName("parameters")]
    public Dictionary<string, WorkflowParameterModel>? Parameters { get; set; }

    [JsonPropertyName("provisioningState")]
    public WorkflowProvisioningStateConstant? ProvisioningState { get; set; }

    [JsonPropertyName("sku")]
    public SkuModel? Sku { get; set; }

    [JsonPropertyName("state")]
    public WorkflowStateConstant? State { get; set; }

    [JsonPropertyName("version")]
    public string? Version { get; set; }
}
