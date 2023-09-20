// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class OnPremisesDirectorySynchronizationConfigurationModel
{
    [JsonPropertyName("accidentalDeletionPrevention")]
    public OnPremisesAccidentalDeletionPreventionModel? AccidentalDeletionPrevention { get; set; }

    [JsonPropertyName("anchorAttribute")]
    public string? AnchorAttribute { get; set; }

    [JsonPropertyName("applicationId")]
    public string? ApplicationId { get; set; }

    [JsonPropertyName("currentExportData")]
    public OnPremisesCurrentExportDataModel? CurrentExportData { get; set; }

    [JsonPropertyName("customerRequestedSynchronizationInterval")]
    public string? CustomerRequestedSynchronizationInterval { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("synchronizationClientVersion")]
    public string? SynchronizationClientVersion { get; set; }

    [JsonPropertyName("synchronizationInterval")]
    public string? SynchronizationInterval { get; set; }

    [JsonPropertyName("writebackConfiguration")]
    public OnPremisesWritebackConfigurationModel? WritebackConfiguration { get; set; }
}
