// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class AccessPackageAssignmentWorkflowExtensionModel
{
    [JsonPropertyName("authenticationConfiguration")]
    public CustomExtensionAuthenticationConfigurationModel? AuthenticationConfiguration { get; set; }

    [JsonPropertyName("callbackConfiguration")]
    public CustomExtensionCallbackConfigurationModel? CallbackConfiguration { get; set; }

    [JsonPropertyName("clientConfiguration")]
    public CustomExtensionClientConfigurationModel? ClientConfiguration { get; set; }

    [JsonPropertyName("createdBy")]
    public string? CreatedBy { get; set; }

    [JsonPropertyName("createdDateTime")]
    public DateTime? CreatedDateTime { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    [JsonPropertyName("endpointConfiguration")]
    public CustomExtensionEndpointConfigurationModel? EndpointConfiguration { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("lastModifiedBy")]
    public string? LastModifiedBy { get; set; }

    [JsonPropertyName("lastModifiedDateTime")]
    public DateTime? LastModifiedDateTime { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }
}
