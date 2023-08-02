using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ContainerApps.v2022_11_01_preview.ManagedEnvironments;


internal class DiagnosticDataProviderMetadataModel
{
    [JsonPropertyName("propertyBag")]
    public List<DiagnosticDataProviderMetadataPropertyBagInlinedModel>? PropertyBag { get; set; }

    [JsonPropertyName("providerName")]
    public string? ProviderName { get; set; }
}
