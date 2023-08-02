// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Applications.StableV1.ApplicationSynchronizationTemplateSchema;

internal class ParseSchemaExpressionRequestModel
{
    [JsonPropertyName("expression")]
    public string? Expression { get; set; }

    [JsonPropertyName("targetAttributeDefinition")]
    public AttributeDefinitionModel? TargetAttributeDefinition { get; set; }

    [JsonPropertyName("testInputObject")]
    public ExpressionInputObjectModel? TestInputObject { get; set; }
}
