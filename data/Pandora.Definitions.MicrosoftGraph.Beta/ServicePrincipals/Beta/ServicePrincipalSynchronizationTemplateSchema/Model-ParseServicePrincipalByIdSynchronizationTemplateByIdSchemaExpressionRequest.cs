// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

namespace Pandora.Definitions.MicrosoftGraph.Beta.ServicePrincipals.Beta.ServicePrincipalSynchronizationTemplateSchema;

internal class ParseServicePrincipalByIdSynchronizationTemplateByIdSchemaExpressionRequestModel
{
    [JsonPropertyName("expression")]
    public string? Expression { get; set; }

    [JsonPropertyName("targetAttributeDefinition")]
    public AttributeDefinitionModel? TargetAttributeDefinition { get; set; }

    [JsonPropertyName("testInputObject")]
    public ExpressionInputObjectModel? TestInputObject { get; set; }
}
