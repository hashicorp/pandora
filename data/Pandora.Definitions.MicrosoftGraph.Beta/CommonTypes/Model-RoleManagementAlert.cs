// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class RoleManagementAlertModel
{
    [JsonPropertyName("alertConfigurations")]
    public List<UnifiedRoleManagementAlertConfigurationModel>? AlertConfigurations { get; set; }

    [JsonPropertyName("alertDefinitions")]
    public List<UnifiedRoleManagementAlertDefinitionModel>? AlertDefinitions { get; set; }

    [JsonPropertyName("alerts")]
    public List<UnifiedRoleManagementAlertModel>? Alerts { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("operations")]
    public List<LongRunningOperationModel>? Operations { get; set; }
}
