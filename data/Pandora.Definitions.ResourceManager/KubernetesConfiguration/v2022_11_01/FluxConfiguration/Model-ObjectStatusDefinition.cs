using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.KubernetesConfiguration.v2022_11_01.FluxConfiguration;


internal class ObjectStatusDefinitionModel
{
    [JsonPropertyName("appliedBy")]
    public ObjectReferenceDefinitionModel? AppliedBy { get; set; }

    [JsonPropertyName("complianceState")]
    public FluxComplianceStateConstant? ComplianceState { get; set; }

    [JsonPropertyName("helmReleaseProperties")]
    public HelmReleasePropertiesDefinitionModel? HelmReleaseProperties { get; set; }

    [JsonPropertyName("kind")]
    public string? Kind { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("namespace")]
    public string? Namespace { get; set; }

    [JsonPropertyName("statusConditions")]
    public List<ObjectStatusConditionDefinitionModel>? StatusConditions { get; set; }
}
