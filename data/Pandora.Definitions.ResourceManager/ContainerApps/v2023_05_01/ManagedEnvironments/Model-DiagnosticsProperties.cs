using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ContainerApps.v2023_05_01.ManagedEnvironments;


internal class DiagnosticsPropertiesModel
{
    [JsonPropertyName("dataProviderMetadata")]
    public DiagnosticDataProviderMetadataModel? DataProviderMetadata { get; set; }

    [JsonPropertyName("dataset")]
    public List<DiagnosticsDataApiResponseModel>? Dataset { get; set; }

    [JsonPropertyName("metadata")]
    public DiagnosticsDefinitionModel? Metadata { get; set; }

    [JsonPropertyName("status")]
    public DiagnosticsStatusModel? Status { get; set; }
}
